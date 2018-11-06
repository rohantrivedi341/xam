using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;
using PCL.Common;
using PCL.Common.Enum;
using PCL.Database;
using PCL.DependencyServices;
using PCL.Repository;
using PCL.UI;
using PCL.UI.Helpers;
using PCL.ViewModels;
using Plugin.Connectivity;
using Xamarin.Forms;
using Label = PCL.Common.Label;

namespace PCL.Services
{
    public class UpdateContentService
    {
        public Int32 SectionId = 1;
        public Int32 StructureItemId = 1;
        public Int32 ItemPageId = 1;
        public Int32 ItemContactId = 1;
        public Int32 ItemContactNumberId = 1;
        public Int32 ItemCalculatorId = 1;
        public Int32 ItemCalculatorLinkId = 1;
        public Int32 LabelId = 1;
        public Int32 SpecialPageId = 1;

        public List<Section> Sections = new List<Section>();
        public List<StructureItem> StructureItems = new List<StructureItem>();
        public List<ItemPage> ItemPages = new List<ItemPage>();
        public List<ItemContact> ItemContacts = new List<ItemContact>();
        public List<ItemContactNumber> ItemContactNumbers = new List<ItemContactNumber>();
        public List<ItemCalculatorLink> ItemCalculatorLinks = new List<ItemCalculatorLink>();
        public List<Label> Labels = new List<Label>();
        public List<SpecialPage> SpecialPages = new List<SpecialPage>();

        public List<Favorite> OldFavorites = new List<Favorite>();
        public List<Favorite> Favorites = new List<Favorite>();

        private class ViewModel
        {
            public SQLiteConnectionDatabase SqLiteConnectionDatabase { get; set; }

            public Boolean Running { get; set; }

            public TaskCompletionSource<Boolean> TcsInternetConnectionRequired = new TaskCompletionSource<Boolean>();
            public TaskCompletionSource<Boolean> TcsDownloadLatestFile = new TaskCompletionSource<Boolean>();
            public TaskCompletionSource<Boolean> TcsApplicationUpdateRequired = new TaskCompletionSource<Boolean>();
            public TaskCompletionSource<Boolean> TcsApplicationUpdateAvailable = new TaskCompletionSource<Boolean>();
            public TaskCompletionSource<Boolean> TcsContentUpdateUnknown = new TaskCompletionSource<Boolean>();
            public TaskCompletionSource<Boolean> TcsContentUpdateRequired = new TaskCompletionSource<Boolean>();
            public TaskCompletionSource<Boolean> TcsContentUpdateAvailable = new TaskCompletionSource<Boolean>();

            public Int32 GeneralBuildNumber { get; set; }

            public Int32 GeneralApplicationVersion { get; set; }

            public Int32 GeneralContentVersion { get; set; }

            public Boolean ProcessStop { get; set; }

            public Boolean RepeaterDownloadLatestFile { get; set; }

            public Boolean RepeaterUpdateApplicationRequired { get; set; }

            public Boolean RepeaterUpdateContentUnknown { get; set; }

            public List<UpdateContentLatest> UpdateContentLatests { get; set; }

            public UpdateContentLatest UpdateContentLatestCurrent { get; set; }
        }

        private static UpdateContentService _updateContentService;

        private ViewModel View = new ViewModel();

        public static UpdateContentService CurrentInstance
        {
            get
            {
                return UpdateContentService._updateContentService ?? (UpdateContentService._updateContentService = new UpdateContentService());
            }
        }

        public UpdateContentService()
        {
            // Subscribe to communication channel of ViewSplash
            MessagingCenter.Subscribe<ViewSplash, MessagingCenterMessage>(this, MessagingCenterConstants.UpdateContentSplash, (s, message) => this.MessagingCenterUpdate(message));
        }

        private void MessagingCenterUpdate(MessagingCenterMessage message)
        {
            if (message.Key.Equals(MessagingCenterConstants.UpdateContentSplashResponseInternetConnectionRequired))
            {
                this.View.TcsInternetConnectionRequired.SetResult(true);
            }
            else if (message.Key.Equals(MessagingCenterConstants.UpdateContentSplashResponseDownloadLatestFileFailed))
            {
                this.View.TcsDownloadLatestFile.SetResult(true);
            }
            else if (message.Key.Equals(MessagingCenterConstants.UpdateContentSplashResponseApplicationUpdateRequired))
            {
                this.View.TcsApplicationUpdateRequired.SetResult(true);
            }
            else if (message.Key.Equals(MessagingCenterConstants.UpdateContentSplashResponseApplicationUpdateAvailable))
            {
                this.View.TcsApplicationUpdateAvailable.SetResult(true);
            }
            else if (message.Key.Equals(MessagingCenterConstants.UpdateContentSplashResponseContentUpdateUnknown))
            {
                this.View.TcsContentUpdateUnknown.SetResult(true);
            }
            else if (message.Key.Equals(MessagingCenterConstants.UpdateContentSplashResponseContentUpdateRequired))
            {
                this.View.TcsContentUpdateRequired.SetResult(true);
            }
            else if (message.Key.Equals(MessagingCenterConstants.UpdateContentSplashResponseContentUpdateAvailable))
            {
                this.View.TcsContentUpdateAvailable.SetResult((Boolean)message.Value);
            }
        }

        #region Synchronisation

        public void Start()
        {
            if (!this.View.Running)
            {
                Task.Run(() => this.Run());

                this.View.Running = true;
            }
        }

        private async void Run()
        {
            // Check if permissions are granted
            //await this.PermissionsCheck();

            // Initialize
            await this.Initializing();

            // Check if internetconnection is available and if it is needed
            await this.InternetConnectionCheck();

            if (this.View.ProcessStop)
            {
                await this.Done();

                return;
            }

            await this.DownloadLatestFile();

            if (this.View.ProcessStop)
            {
                await this.Done();

                return;
            }

            await this.ApplicationUpdate();

            await this.ContentUpdate();

#if !DEBUG
            if (this.View.ProcessStop)
            {
                await this.Done();

                return;
            }
#endif

            await this.ContentInitializing();

            await this.ContentDownloading();

            await this.ContentExtracting();

            await this.ContentProcessing();

            await this.ContentCompleting();

            await this.Done();
        }

        //private async Task PermissionsCheck()
        //{
        //    // Ask platform for permissions
        //    App.CurrentInstance.DependencyPlatformGeneral.HandlePermissions(this.View.TcsPermissionsRequired);
        //
        //    // Wait for task result
        //    await this.View.TcsPermissionsRequired.Task;
        //}

        private async Task Initializing()
        {
            this.View.SqLiteConnectionDatabase = SQLiteConnectionDatabase.NewConnection();

            // Get build number
            this.View.GeneralBuildNumber = App.CurrentInstance.DependencyPlatformGeneral.GetBuildNumber();

            // Get application version
            this.View.GeneralApplicationVersion = App.CurrentInstance.DependencyPlatformPersistentStorage.GetValueOrDefaultInt32(DependencyPlatformPersistentStorageConstants.ApplicationVersion, 0);

            // Current number is not equal to saved version
            if (this.View.GeneralBuildNumber != this.View.GeneralApplicationVersion)
            {
                this.View.GeneralApplicationVersion = this.View.GeneralBuildNumber;

                // Save build number
                App.CurrentInstance.DependencyPlatformPersistentStorage.AddOrUpdateValueInt32(DependencyPlatformPersistentStorageConstants.ApplicationVersion, this.View.GeneralApplicationVersion);

                // Reset content version
                App.CurrentInstance.DependencyPlatformPersistentStorage.AddOrUpdateValueInt32(DependencyPlatformPersistentStorageConstants.ContentVersion, 0);

                // Save changes in persistent storage
                App.CurrentInstance.DependencyPlatformPersistentStorage.Save();
            }

            // Get content version
            this.View.GeneralContentVersion = App.CurrentInstance.DependencyPlatformPersistentStorage.GetValueOrDefaultInt32(DependencyPlatformPersistentStorageConstants.ContentVersion, 0);
        }

        private async Task InternetConnectionCheck()
        {
            // No connection available but content is available
            if (!CrossConnectivity.Current.IsConnected && this.View.GeneralContentVersion > 0)
            {
                // Stop process
                this.View.ProcessStop = true;

                return;
            }

            // Repeat to check if there is an internet connection
            while (!CrossConnectivity.Current.IsConnected)
            {
                this.View.TcsInternetConnectionRequired = new TaskCompletionSource<Boolean>();

                // Send message
                MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentService, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentServiceRequestInternetConnectionRequired));

                // Wait for task result
                await this.View.TcsInternetConnectionRequired.Task;
            }
        }

        private async Task DownloadLatestFile()
        {
            // Repeat to download latest file (in case of exception)
            while (!this.View.RepeaterDownloadLatestFile)
            {
                try
                {
                    String latestUrl = App.CurrentInstance.DependencyApplicationGeneral.GetBackendUrlLastest();

                    // Create cancellation token
                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

                    // Set timeout when there is already content
                    if (this.View.GeneralContentVersion > 0)
                        cancellationTokenSource.CancelAfter(3000);

                    // Wait for request result
                    HttpResponseMessage requestTask = await new HttpClient().GetAsync(latestUrl, cancellationTokenSource.Token);

                    // Wait for content
                    String responseString = await requestTask.Content.ReadAsStringAsync();

                    // Get file from web with the latest info about this application
                    JArray jArrayLatest = JArray.Parse(responseString);

                    // Get all json objects as UpdateContentLatest
                    this.View.UpdateContentLatests = jArrayLatest.Select(jTokenLatest => jTokenLatest.ToObject<UpdateContentLatest>()).ToList();

                    // Download latest file is done, so repeater is not necessary (any more)
                    this.View.RepeaterDownloadLatestFile = true;
                }
                catch (OperationCanceledException)
                {
                    // Stop process
                    this.View.ProcessStop = true;

                    // Download latest file takes to long, so repeating is not necessary
                    this.View.RepeaterDownloadLatestFile = true;
                }
                catch (Exception)
                {
                    this.View.TcsDownloadLatestFile = new TaskCompletionSource<Boolean>();

                    // Send message
                    MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentService, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentServiceRequestDownloadLatestFileFailed));

                    // Wait for task result
                    await this.View.TcsDownloadLatestFile.Task;
                }
            }
        }

        private async Task ApplicationUpdate()
        {
            // Get persistent values for application
            Boolean updateApplicationAvailable = App.CurrentInstance.DependencyPlatformPersistentStorage.GetValueOrDefaultBoolean(DependencyPlatformPersistentStorageConstants.UpdateAvailableApplication, false);
            DateTime updateApplicationAvailableDateTime = App.CurrentInstance.DependencyPlatformPersistentStorage.GetValueOrDefaultDateTime(DependencyPlatformPersistentStorageConstants.UpdateAvailableApplicationDateTime, DateTime.MinValue);

            // Get all UpdateContentLatest with a higher version than the current application version
            List<UpdateContentLatest> newerVersions = this.View.UpdateContentLatests.Where(x => x.ApplicationVersion > this.View.GeneralApplicationVersion).ToList();

            UpdateContentLatest updateContentLatest = null;

            // Select the update object where there is a store date time which needs to be more than a day ago (because of store delays worldwide)
            switch (Device.OS)
            {
                case TargetPlatform.iOS:
                    updateContentLatest = newerVersions.Where(x => x.Store.iOS.HasValue).Where(x => x.Store.iOS.Value < DateTime.Now.AddDays(-1)).OrderBy(x => x.ApplicationVersion).LastOrDefault();
                    break;
                case TargetPlatform.Android:
                    updateContentLatest = newerVersions.Where(x => x.Store.Android.HasValue).Where(x => x.Store.Android.Value < DateTime.Now.AddDays(-1)).OrderBy(x => x.ApplicationVersion).LastOrDefault();
                    break;
                case TargetPlatform.WinPhone:
                    updateContentLatest = newerVersions.Where(x => x.Store.WindowsPhone.HasValue).Where(x => x.Store.WindowsPhone.Value < DateTime.Now.AddDays(-1)).OrderBy(x => x.ApplicationVersion).LastOrDefault();
                    break;
                default:
                    break;
            }

            // Reset persistent storage when there is no update available anymore. This makes it possible to revert an update of the application
            if (updateContentLatest == null)
            {
                App.CurrentInstance.DependencyPlatformPersistentStorage.AddOrUpdateValueBoolean(DependencyPlatformPersistentStorageConstants.UpdateAvailableApplication, false);
                App.CurrentInstance.DependencyPlatformPersistentStorage.AddOrUpdateValueDateTime(DependencyPlatformPersistentStorageConstants.UpdateAvailableApplicationDateTime, DateTime.MinValue);
                App.CurrentInstance.DependencyPlatformPersistentStorage.Save();

                updateApplicationAvailable = false;
            }

            // Already an application update available
            if (updateApplicationAvailable)
            {
                if (DateTime.Now.AddMonths(-1) > updateApplicationAvailableDateTime)
                {
                    while (!this.View.RepeaterUpdateApplicationRequired)
                    {
                        this.View.TcsApplicationUpdateRequired = new TaskCompletionSource<Boolean>();

                        // Send message
                        MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentService, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentServiceRequestApplicationUpdateRequired));

                        // Wait for task result
                        await this.View.TcsApplicationUpdateRequired.Task;
                    }
                }
                else
                {
                    // Send message
                    MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentService, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentServiceRequestApplicationUpdateAvailable));

                    // Wait for task result
                    await this.View.TcsApplicationUpdateAvailable.Task;
                }
            }
            // First notice of newer application version
            else if (updateContentLatest != null)
            {
                // Save this to peristent storage
                App.CurrentInstance.DependencyPlatformPersistentStorage.AddOrUpdateValueBoolean(DependencyPlatformPersistentStorageConstants.UpdateAvailableApplication, true);
                App.CurrentInstance.DependencyPlatformPersistentStorage.AddOrUpdateValueDateTime(DependencyPlatformPersistentStorageConstants.UpdateAvailableApplicationDateTime, DateTime.Now);
                App.CurrentInstance.DependencyPlatformPersistentStorage.Save();

                // Send message
                MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentService, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentServiceRequestApplicationUpdateAvailable));

                // Wait for task result
                await this.View.TcsApplicationUpdateAvailable.Task;
            }
        }

        private async Task ContentUpdate()
        {
            // Get persistent values for content
            Boolean updateContentAvailable = App.CurrentInstance.DependencyPlatformPersistentStorage.GetValueOrDefaultBoolean(DependencyPlatformPersistentStorageConstants.UpdateAvailableContent, false);
            DateTime updateContentAvailableDateTime = App.CurrentInstance.DependencyPlatformPersistentStorage.GetValueOrDefaultDateTime(DependencyPlatformPersistentStorageConstants.UpdateAvailableContentDateTime, DateTime.MinValue);

            // Select the object that is equal to the current application version
            this.View.UpdateContentLatestCurrent = this.View.UpdateContentLatests.Where(x => x.ApplicationVersion.Equals(this.View.GeneralApplicationVersion)).SingleOrDefault();

            // Reset persistent storage when the there is no result found with this application number and a different content version. This makes it possible to revert an update of the content
            if (this.View.UpdateContentLatestCurrent == null || this.View.UpdateContentLatestCurrent.ContentVersion == this.View.GeneralContentVersion)
            {
                App.CurrentInstance.DependencyPlatformPersistentStorage.AddOrUpdateValueBoolean(DependencyPlatformPersistentStorageConstants.UpdateAvailableContent, false);
                App.CurrentInstance.DependencyPlatformPersistentStorage.AddOrUpdateValueDateTime(DependencyPlatformPersistentStorageConstants.UpdateAvailableContentDateTime, DateTime.Now);
                App.CurrentInstance.DependencyPlatformPersistentStorage.Save();

                updateContentAvailable = false;
            }

            // No content yet
            if (this.View.GeneralContentVersion == 0)
            {
                // Latest data file not usable
                if (this.View.UpdateContentLatestCurrent == null)
                {
                    while (!this.View.RepeaterUpdateContentUnknown)
                    {
                        this.View.TcsContentUpdateUnknown = new TaskCompletionSource<Boolean>();

                        // Send message
                        MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentService, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateUnknown));

                        // Wait for task result
                        await this.View.TcsContentUpdateUnknown.Task;
                    }
                }
            }
            // Content exists
            else
            {
                // Already a content update available
                if (updateContentAvailable)
                {
                    // Longer than 7 days agoupdate
                    if (DateTime.Now.AddMonths(-1) > updateContentAvailableDateTime)
                    {
                        // Send message
                        MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentService, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateRequired));

                        // Wait for task result
                        await this.View.TcsContentUpdateRequired.Task;
                    }
                    else
                    {
                        // Send message
                        MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentService, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateAvailable));

                        // Wait for task result
                        await this.View.TcsContentUpdateAvailable.Task;

                        // Stop process when user does not want to update
                        this.View.ProcessStop = !this.View.TcsContentUpdateAvailable.Task.Result;
                    }
                }

                // First notice of newer content version
                else if (this.View.UpdateContentLatestCurrent != null && this.View.UpdateContentLatestCurrent.ContentVersion != this.View.GeneralContentVersion)
                {
                    // Save this to peristent storage
                    App.CurrentInstance.DependencyPlatformPersistentStorage.AddOrUpdateValueBoolean(DependencyPlatformPersistentStorageConstants.UpdateAvailableContent, true);
                    App.CurrentInstance.DependencyPlatformPersistentStorage.AddOrUpdateValueDateTime(DependencyPlatformPersistentStorageConstants.UpdateAvailableContentDateTime, DateTime.Now);
                    App.CurrentInstance.DependencyPlatformPersistentStorage.Save();

                    // Send message
                    MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentService, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateAvailable));

                    // Wait for task result
                    await this.View.TcsContentUpdateAvailable.Task;

                    // Stop process when user does not want to update
                    this.View.ProcessStop = !this.View.TcsContentUpdateAvailable.Task.Result;
                }
                else
                {
                    // Stop process when there is no update
                    this.View.ProcessStop = true;
                }
            }
        }

        public class TableName
        {
            public String Name { get; set; }
        }

        private async Task ContentInitializing()
        {
            // Send message
            MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentService, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateStarting, PCLResources.UpdateStarting));

            // Initialize dependency service
            App.CurrentInstance.DependencyApplicationUpdateContent.Initialize(this);

            try
            {
                // Get current favorites
                this.OldFavorites = new FavoriteRepository(this.View.SqLiteConnectionDatabase).Get();
            }
            catch (Exception)
            {
                // Ignore because table did not exist
            }

            // Delete and recreate SQLiteConnectionDatabase
            this.View.SqLiteConnectionDatabase.Recreate();

            // Clear output directory
            App.CurrentInstance.DependencyPlatformIO.ClearDirectory(App.CurrentInstance.DependencyPlatformIO.ExternalApplicationDirectory());
        }

        private async Task ContentDownloading()
        {
            // Send message
            MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentService, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateDownloading, String.Format(PCLResources.ProgressPercentage, 0)));

            // Create url where to download the zip file
            String url = String.Format(App.CurrentInstance.DependencyApplicationGeneral.GetBackendUrlContent(), this.View.UpdateContentLatestCurrent.ContentVersion);

            // Start stream to zip file
            Stream zipStream = await new HttpClient().GetStreamAsync(url);

            // Save zip
            App.CurrentInstance.DependencyPlatformIO.SaveFile(this, zipStream, this.GetZipLocation());
        }

        private async Task ContentExtracting()
        {
            // Send message
            MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentService, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateExtracting, String.Format(PCLResources.ProgressPercentage, 0)));

            // Unzip file to destination
            App.CurrentInstance.DependencyPlatformIO.Unzip(this, this.GetZipLocation(), App.CurrentInstance.DependencyPlatformIO.ExternalApplicationDirectory());
        }

        private async Task ContentProcessing()
        {
            // Send message
            MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentService, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateProcessing, String.Format(PCLResources.ProgressPercentage, 0)));

            this.Sections.Add(new Section(this.SectionId, SectionType.Favorites, "Favorites", "Favorites", "tab_favorites.png", null, true));
            this.SectionId++;

            // Add sections of application
            App.CurrentInstance.DependencyApplicationUpdateContent.AddSections();

            foreach (Section section in this.Sections)
            {
                try
                {
                    switch (section.Type)
                    {
                        case SectionType.Favorites:
                            break;
                        case SectionType.Pages:
                            this.ProcessItemPages(section, JArray.Parse(this.GetSectionFile(section.Location)), null);
                            break;
                        case SectionType.Calculators:
                            this.ProcessItemCalculators(section, JArray.Parse(this.GetSectionFile(section.Location)));
                            break;
                        case SectionType.Directory:
                            this.ProcessItemContacts(section, JArray.Parse(this.GetSectionFile(section.Location)), null);
                            break;
                        case SectionType.SpecialPages:
                            this.ProcessSpecialPages(section, JArray.Parse(this.GetSectionFile(section.Location)));
                            break;
                    }
                }
                catch (Exception)
                {
                    // Ignore exception
                }
            }
        }

        private async Task ContentCompleting()
        {
            // Send message
            MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentService, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateCompleting, PCLResources.UpdateCompleting));

            // Check favorites
            foreach (Favorite favorite in this.OldFavorites)
            {
                if (this.StructureItems.Where(x => favorite.Uuid.Equals(x.Uuid)).SingleOrDefault() != null)
                    this.Favorites.Add(favorite);
            }

            // Start transaction
            this.View.SqLiteConnectionDatabase.BeginTransaction();

            // Save objects to general repositories
            new SectionRepository(this.View.SqLiteConnectionDatabase).Save(this.Sections);
            new StructureItemRepository(this.View.SqLiteConnectionDatabase).Save(this.StructureItems);
            new ItemPageRepository(this.View.SqLiteConnectionDatabase).Save(this.ItemPages);
            new ItemContactRepository(this.View.SqLiteConnectionDatabase).Save(this.ItemContacts);
            new ItemContactNumberRepository(this.View.SqLiteConnectionDatabase).Save(this.ItemContactNumbers);
            new ItemCalculatorLinkRepository(this.View.SqLiteConnectionDatabase).Save(this.ItemCalculatorLinks);
            new LabelRepository(this.View.SqLiteConnectionDatabase).Save(this.Labels);
            new SpecialPageRepository(this.View.SqLiteConnectionDatabase).Save(this.SpecialPages);
            new FavoriteRepository(this.View.SqLiteConnectionDatabase).Save(this.Favorites);

            // Save objects to application specific repositories
            App.CurrentInstance.DependencyApplicationUpdateContent.Save(this.View.SqLiteConnectionDatabase);

            // Commit transaction
            this.View.SqLiteConnectionDatabase.Commit();

            // Save content version
            App.CurrentInstance.DependencyPlatformPersistentStorage.AddOrUpdateValueInt32(DependencyPlatformPersistentStorageConstants.ContentVersion, this.View.UpdateContentLatestCurrent.ContentVersion);

            // Save changes in persistent storage
            App.CurrentInstance.DependencyPlatformPersistentStorage.Save();
        }

        private async Task Done()
        {
            // Send message
            MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentService, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentServiceRequestDone));

            this.View.Running = false;
        }

        #endregion

        #region Processing

        public void ProcessItemPages(Section section, JArray jsonStructureItems, StructureItem parentStructureItem)
        {
            Int32 oldPercentage = -1;

            for (int indexStructureItems = 0; indexStructureItems < jsonStructureItems.Count; indexStructureItems++)
            {
                if (parentStructureItem == null)
                {
                    Int32 percentage = (Int32)(indexStructureItems / (Double)jsonStructureItems.Count * 100.0);

                    if (percentage != oldPercentage)
                    {
                        MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentService, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateProcessing, String.Format(PCLResources.ProgressPercentageExtended, section.Title, percentage)));

                        oldPercentage = percentage;
                    }
                }

                JObject jsonStructureItem = jsonStructureItems[indexStructureItems].ToObject<JObject>();

                Boolean hasContent = jsonStructureItem.GetValue("file_name") != null && (jsonStructureItem.Property("children") == null || !(jsonStructureItem.GetValue("children") is JArray));

                StructureItem structureItem = new StructureItem(this.StructureItemId, section.Id, parentStructureItem?.Id, jsonStructureItem.GetValue("title").Value<String>(), !hasContent ? StructureItemType.Category : StructureItemType.Page, indexStructureItems);

                if (jsonStructureItem.Property("uuid") != null)
                    structureItem.Uuid = Guid.Parse(jsonStructureItem.GetValue("uuid").Value<String>());

                structureItem.SubTitle = parentStructureItem != null ? $"{parentStructureItem.Title} ({section.Title})" : section.Title;
                
                this.StructureItems.Add(structureItem);
                this.StructureItemId++;
                
                if (hasContent)
                {
                    this.ItemPages.Add(new ItemPage(this.ItemPageId, structureItem.Id, jsonStructureItem.GetValue("file_name").Value<String>()));
                    this.ItemPageId++;
                }

                if (structureItem.Type == StructureItemType.Category)
                {
                    this.Labels.Add(new Label(this.LabelId, StructureItemType.Category, structureItem.Id, structureItem.Title, structureItem.SubTitle));
                    this.LabelId++;
                }

                if (structureItem.Type == StructureItemType.Page && parentStructureItem != null)
                {
                    this.Labels.Add(new Label(this.LabelId, StructureItemType.Page, structureItem.Id, structureItem.Title, $"{parentStructureItem.Title} ({section.Title})"));
                    this.LabelId++;
                }

                if (jsonStructureItem.Property("labels") != null && jsonStructureItem.GetValue("labels") is JArray)
                {
                    JArray jsonLabels = jsonStructureItem.GetValue("labels").Value<JArray>();

                    for (int indexLabels = 0; indexLabels < jsonLabels.Count; indexLabels++)
                    {
                        this.Labels.Add(new Label(this.LabelId, StructureItemType.Page, structureItem.Id, jsonLabels[indexLabels].ToString(), $"{structureItem.Title} ({section.Title})"));
                        this.LabelId++;
                    }
                }

                if (jsonStructureItem.Property("children") != null && jsonStructureItem.GetValue("children") is JArray)
                {
                    this.ProcessItemPages(section, jsonStructureItem.GetValue("children").Value<JArray>(), structureItem);
                }
            }
        }

        public void ProcessItemContacts(Section section, JArray jsonStructureItems, StructureItem parentStructureItem)
        {
            Int32 oldPercentage = -1;

            for (int indexStructureItems = 0; indexStructureItems < jsonStructureItems.Count; indexStructureItems++)
            {
                if (parentStructureItem == null)
                {
                    Int32 percentage = (Int32)(indexStructureItems / (Double)jsonStructureItems.Count * 100.0);

                    if (percentage != oldPercentage)
                    {
                        MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentService, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateProcessing, String.Format(PCLResources.ProgressPercentageExtended, section.Title, percentage)));

                        oldPercentage = percentage;
                    }
                }

                JObject jsonStructureItem = jsonStructureItems[indexStructureItems].ToObject<JObject>();

                StructureItem structureItem = new StructureItem(this.StructureItemId, section.Id, parentStructureItem?.Id, jsonStructureItem.GetValue("title").Value<String>(), StructureItemType.Category, 1);

                if (jsonStructureItem.Property("uuid") != null)
                    structureItem.Uuid = Guid.Parse(jsonStructureItem.GetValue("uuid").Value<String>());

                structureItem.SubTitle = parentStructureItem != null ? $"{parentStructureItem.Title} ({section.Title})" : section.Title;

                this.StructureItems.Add(structureItem);
                this.StructureItemId++;

                this.Labels.Add(new Label(this.LabelId, StructureItemType.Category, structureItem.Id, structureItem.Title, structureItem.SubTitle));
                this.LabelId++;

                if (jsonStructureItem.Property("categories") != null && jsonStructureItem.GetValue("categories") is JArray)
                {
                    this.ProcessItemContacts(section, jsonStructureItem.GetValue("categories").Value<JArray>(), structureItem);
                }
                else if (jsonStructureItem.Property("contacts") != null && jsonStructureItem.GetValue("contacts") is JArray)
                {
                    JArray jsonItemContacts = jsonStructureItem.GetValue("contacts").Value<JArray>();

                    for (int indexContacts = 0; indexContacts < jsonItemContacts.Count; indexContacts++)
                    {
                        JObject jsonItemContact = jsonItemContacts[indexContacts].ToObject<JObject>();

                        StructureItem structureItemContact = new StructureItem(this.StructureItemId, section.Id, structureItem.Id, jsonItemContact.GetValue("title").Value<String>(), StructureItemType.Contact, indexContacts);

                        if (jsonItemContact.Property("uuid") != null)
                            structureItemContact.Uuid = Guid.Parse(jsonItemContact.GetValue("uuid").Value<String>());

                        structureItemContact.SubTitle = parentStructureItem != null ? $"{parentStructureItem.Title} ({section.Title})" : section.Title;

                        this.StructureItems.Add(structureItemContact);
                        this.StructureItemId++;

                        this.Labels.Add(new Label(this.LabelId, StructureItemType.Contact, structureItemContact.Id, structureItemContact.Title, structureItemContact.SubTitle));
                        this.LabelId++;


                        if (jsonItemContact.Property("labels") != null && jsonItemContact.GetValue("labels") is JArray)
                        {
                            JArray jsonLabels = jsonItemContact.GetValue("labels").Value<JArray>();

                            for (int indexLabels = 0; indexLabels < jsonLabels.Count; indexLabels++)
                            {
                                this.Labels.Add(new Label(this.LabelId, StructureItemType.Contact, structureItemContact.Id, jsonLabels[indexLabels].ToString(), structureItemContact.SubTitle));
                                this.LabelId++;
                            }
                        }

                        ItemContact itemContact = new ItemContact(this.ItemContactId, structureItemContact.Id, structureItemContact.Title);

                        if (jsonItemContact.Property("physical_address") != null)
                        {
                            itemContact.PhysicalAddress = jsonItemContact.GetValue("physical_address").Value<String>();
                        }

                        if (jsonItemContact.Property("postal_address") != null)
                        {
                            itemContact.PostalAddress = jsonItemContact.GetValue("postal_address").Value<String>();
                        }

                        if (jsonItemContact.Property("website_url") != null)
                        {
                            itemContact.WebsiteUrl = jsonItemContact.GetValue("website_url").Value<String>();
                        }

                        if (jsonItemContact.Property("email_address") != null)
                        {
                            itemContact.EmailAddress = jsonItemContact.GetValue("email_address").Value<String>();
                        }

                        if (jsonItemContact.Property("working_hours") != null)
                        {
                            itemContact.WorkingHours = jsonItemContact.GetValue("working_hours").Value<String>();
                        }

                        if (jsonItemContact.Property("facility_classification") != null)
                        {
                            itemContact.FacilityClassification = jsonItemContact.GetValue("facility_classification").Value<String>();
                        }

                        if (jsonItemContact.Property("facility_manager") != null)
                        {
                            itemContact.FacilityManager = jsonItemContact.GetValue("facility_manager").Value<String>();
                        }

                        if (jsonItemContact.Property("facility_manager_email") != null)
                        {
                            itemContact.FacilityManagerEmailAddress = jsonItemContact.GetValue("facility_manager_email").Value<String>();
                        }

                        if (jsonItemContact.Property("gps_latitude") != null)
                        {
                            itemContact.Latitude = jsonItemContact.GetValue("gps_latitude").Value<String>();
                        }

                        if (jsonItemContact.Property("gps_longitude") != null)
                        {
                            itemContact.Longitude = jsonItemContact.GetValue("gps_longitude").Value<String>();
                        }

                        this.ItemContacts.Add(itemContact);
                        this.ItemContactId++;

                        if (jsonItemContact.Property("contact_numbers") != null && jsonItemContact.GetValue("contact_numbers") is JArray)
                        {
                            JArray jsonItemContactNumbers = jsonItemContact.GetValue("contact_numbers").Value<JArray>();

                            for (int indexContactNumbers = 0; indexContactNumbers < jsonItemContactNumbers.Count; indexContactNumbers++)
                            {
                                JObject jsonItemContactNumber = jsonItemContactNumbers[indexContactNumbers].ToObject<JObject>();

                                ItemContactNumber itemContactNumber = new ItemContactNumber(this.ItemContactNumberId, itemContact.Id, jsonItemContactNumber.GetValue("title").Value<String>(), jsonItemContactNumber.GetValue("telephone").Value<String>(), indexContactNumbers);

                                this.ItemContactNumbers.Add(itemContactNumber);
                                this.ItemContactNumberId++;
                            }
                        }
                    }
                }
            }
        }

        public void ProcessSpecialPages(Section section, JArray jsonStructureItems)
        {
            Int32 oldPercentage = -1;

            for (int indexStructureItems = 0; indexStructureItems < jsonStructureItems.Count; indexStructureItems++)
            {
                Int32 percentage = (Int32)(indexStructureItems / (Double)jsonStructureItems.Count * 100.0);

                if (percentage != oldPercentage)
                {
                    MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentService, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateProcessing, String.Format(PCLResources.ProgressPercentageExtended, section.Title, percentage)));

                    oldPercentage = percentage;
                }

                JObject jsonStructureItem = jsonStructureItems[indexStructureItems].ToObject<JObject>();

                SpecialPageType specialPageType = SpecialPage.IdentifyType(jsonStructureItem.GetValue("identifier").Value<String>());

                if (specialPageType == SpecialPageType.Unknown)
                {
                    continue;
                }

                SpecialPage specialPage = new SpecialPage(this.SpecialPageId, section.Id, jsonStructureItem.GetValue("title").Value<String>(), specialPageType, jsonStructureItem.GetValue("file_name").Value<String>());

                this.SpecialPages.Add(specialPage);
                this.SpecialPageId++;
            }
        }

        public void ProcessItemCalculators(Section section, JArray jsonStructureItems)
        {
            Int32 oldPercentage = -1;

            for (int indexStructureItems = 0; indexStructureItems < jsonStructureItems.Count; indexStructureItems++)
            {
                Int32 percentage = (Int32)(indexStructureItems / (Double)jsonStructureItems.Count * 100.0);

                if (percentage != oldPercentage)
                {
                    MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentService, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateProcessing, String.Format(PCLResources.ProgressPercentageExtended, section.Title, percentage)));

                    oldPercentage = percentage;
                }

                JObject jsonStructureItem = jsonStructureItems[indexStructureItems].ToObject<JObject>();

                StructureItem structureItemCalculator = new StructureItem(this.StructureItemId, section.Id, null, jsonStructureItem.GetValue("title").Value<String>(), StructureItemType.Calculator, indexStructureItems);

                if (jsonStructureItem.Property("information") != null)
                {
                    structureItemCalculator.Information = jsonStructureItem.GetValue("information").Value<String>();
                }

                this.StructureItems.Add(structureItemCalculator);
                this.StructureItemId++;

                ItemCalculator itemCalculator = new ItemCalculator(this.ItemCalculatorId, structureItemCalculator.Id, jsonStructureItem.GetValue("identifier").Value<String>());

                if (jsonStructureItem.Property("folder") != null)
                {
                    itemCalculator.Folder = jsonStructureItem.GetValue("folder").Value<String>();
                }

                if (jsonStructureItem.Property("file_name") != null)
                {
                    itemCalculator.FileName = jsonStructureItem.GetValue("file_name").Value<String>();
                }

                if (jsonStructureItem.Property("url") != null)
                {
                    itemCalculator.Url = jsonStructureItem.GetValue("url").Value<String>();
                }

                if (jsonStructureItem.Property("pdf") != null)
                {
                    itemCalculator.Pdf = jsonStructureItem.GetValue("pdf").Value<String>();
                }

                App.CurrentInstance.DependencyApplicationUpdateContent.ProcessCalculator(section, itemCalculator);

                this.ItemCalculatorId++;
            }
        }

        public void ProcessItemCalculatorFolder(ItemCalculator itemCalculator, String folder)
        {
            ItemCalculatorLink itemCalculatorLink = new ItemCalculatorLink(this.ItemCalculatorLinkId, itemCalculator.Id, ItemCalculatorLinkType.Folder, folder);

            this.ItemCalculatorLinks.Add(itemCalculatorLink);
            this.ItemCalculatorLinkId++;
        }

        public void ProcessItemCalculatorUrl(ItemCalculator itemCalculator, String url)
        {
            ItemCalculatorLink itemCalculatorLink = new ItemCalculatorLink(this.ItemCalculatorLinkId, itemCalculator.Id, ItemCalculatorLinkType.Url, url);

            this.ItemCalculatorLinks.Add(itemCalculatorLink);
            this.ItemCalculatorLinkId++;
        }

        #endregion

        public String GetZipLocation()
        {
            return App.CurrentInstance.DependencyPlatformIO.ExternalApplicationDirectory() + "Content.zip";
        }

        public String GetSectionFile(String location, String defaultFile = "index.json")
        {
            return App.CurrentInstance.DependencyPlatformIO.GetFileContent(String.Format("{0}/{1}/{2}", App.CurrentInstance.DependencyPlatformIO.ExternalApplicationDirectory(), location, defaultFile));
        }
    }
}