using System;
using System.Threading.Tasks;

using PCL.Services;
using PCL.UI.Helpers;
using Xamarin.Forms;

namespace PCL.UI
{
    public partial class ViewSplash : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private new class ViewModel : ContentPageBase.ViewModel
        {
            public RelativeLayout RelativeLayout;

            public StackLayout StackLayoutTop;
            public StackLayout StackLayoutMiddle;
            public StackLayout StackLayoutBottom;

            public Double StackLayoutYTop;
            public Double StackLayoutYMiddle;
            public Double StackLayoutYBottom;

            public Label LabelProgressTitle;
            public Label LabelProgressMessage;

            public TaskCompletionSource<Boolean> DelayFinished = new TaskCompletionSource<Boolean>();

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewSplash()
        {
            this.InitializeComponent();

            // Get RelativeLayout
            this.View.RelativeLayout = this.relativeLayout;

            // Create stacklayouts for different parts of the splash screen
            this.View.StackLayoutTop = new StackLayout();
            this.View.StackLayoutTop.WidthRequest = App.ScreenSize.Width;
            this.View.StackLayoutMiddle = new StackLayout();
            this.View.StackLayoutMiddle.WidthRequest = App.ScreenSize.Width;
            this.View.StackLayoutBottom = new StackLayout();
            this.View.StackLayoutBottom.WidthRequest = App.ScreenSize.Width;

            // Fill application specific splash screen
            App.CurrentInstance.DependencyApplicationUI.SplashScreenFill(this.View.StackLayoutTop, ref this.View.StackLayoutYTop, this.View.StackLayoutMiddle, ref this.View.StackLayoutYMiddle, this.View.StackLayoutBottom, ref this.View.StackLayoutYBottom, ImageSource.FromResource("PCL.Assets.ic_logo_omp.png"));

            // Add stacklayouts to layout
            this.View.RelativeLayout.Children.Add(this.View.StackLayoutTop, yConstraint: Constraint.RelativeToParent(parent => this.View.RelativeLayout.Height * this.View.StackLayoutYTop));
            this.View.RelativeLayout.Children.Add(this.View.StackLayoutMiddle, yConstraint: Constraint.RelativeToParent(parent => this.View.RelativeLayout.Height * this.View.StackLayoutYMiddle));
            this.View.RelativeLayout.Children.Add(this.View.StackLayoutBottom, yConstraint: Constraint.RelativeToParent(parent => this.View.RelativeLayout.Height * this.View.StackLayoutYBottom));

            // Subscribe to communication channel of UpdateContentService
            MessagingCenter.Subscribe<UpdateContentService, MessagingCenterMessage>(this, MessagingCenterConstants.UpdateContentService, (s, message) => Device.BeginInvokeOnMainThread(() => this.MessagingCenterUpdate(message)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Start update content
            UpdateContentService.CurrentInstance.Start();

            // Show splash with delay
            this.DelayedSplashScreen();
        }

        public async void DelayedSplashScreen()
        {
            // Splash screen needs to be shown for 2 seconds
            await Task.Delay(2000);

            // Update middle layout
            this.UpdateLayoutMiddle();

            // Set result for delay finished task
            this.View.DelayFinished.SetResult(true);
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            this.View.StackLayoutTop.WidthRequest = App.ScreenSize.Width;
            this.View.StackLayoutMiddle.WidthRequest = App.ScreenSize.Width;
            this.View.StackLayoutBottom.WidthRequest = App.ScreenSize.Width;

            App.CurrentInstance.DependencyApplicationUI.SplashScreenSizeAllocated();
        }

        private async void MessagingCenterUpdate(MessagingCenterMessage message)
        {
            // Wait for splash screen delay
            await this.View.DelayFinished.Task;

            if (message.Key.Equals(MessagingCenterConstants.UpdateContentServiceRequestInternetConnectionRequired))
            {
                // Alert user
                await this.DisplayAlert(PCLResources.NoInternetConnection, PCLResources.NoInternetConnectionMessage, PCLResources.OK);

                MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentSplash, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentSplashResponseInternetConnectionRequired));
            }
            else if (message.Key.Equals(MessagingCenterConstants.UpdateContentServiceRequestDownloadLatestFileFailed))
            {
                // Alert user
                await this.DisplayAlert(PCLResources.ImportantInformation, PCLResources.DownloadLatestFileFailed, PCLResources.OK);

                // Send message
                MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentSplash, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentSplashResponseDownloadLatestFileFailed));
            }
            else if (message.Key.Equals(MessagingCenterConstants.UpdateContentServiceRequestApplicationUpdateRequired))
            {
                // Alert user
                await this.DisplayAlert(PCLResources.ImportantInformation, PlatformStrings.GetApplicationUpdateRequired(), PCLResources.OK);

                // Send message
                MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentSplash, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentSplashResponseApplicationUpdateRequired));
            }
            else if (message.Key.Equals(MessagingCenterConstants.UpdateContentServiceRequestApplicationUpdateAvailable))
            {
                // Alert user
                await this.DisplayAlert(PCLResources.ImportantInformation, PlatformStrings.GetApplicationUpdateAvailable(), PCLResources.OK);

                // Send message
                MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentSplash, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentSplashResponseApplicationUpdateAvailable));
            }
            else if (message.Key.Equals(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateUnknown))
            {
                // Alert user
                await this.DisplayAlert(PCLResources.ImportantInformation, PCLResources.ContentUpdateUnknown, PCLResources.OK);

                // Send message
                MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentSplash, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentSplashResponseContentUpdateUnknown));
            }
            else if (message.Key.Equals(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateRequired))
            {
                // Alert user
                await this.DisplayAlert(PCLResources.ImportantInformation, PCLResources.ContentUpdateRequired, PCLResources.DownloadNow);

                // Send message
                MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentSplash, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentSplashResponseContentUpdateRequired));
            }
            else if (message.Key.Equals(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateAvailable))
            {
                // Alert user
                Boolean downloadNow = await this.DisplayAlert(PCLResources.ImportantInformation, PCLResources.ContentUpdateAvailable, PCLResources.DownloadNow, PCLResources.DownloadLater);

                // Send message
                MessagingCenter.Send(this, MessagingCenterConstants.UpdateContentSplash, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentSplashResponseContentUpdateAvailable, downloadNow));
            }
            else if (message.Key.Equals(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateStarting))
            {
                // Update labels
                this.View.LabelProgressTitle.Text = message.Value.ToString();
                this.View.LabelProgressMessage.Text = String.Empty;
            }
            else if (message.Key.Equals(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateDownloading))
            {
                // Update labels
                this.View.LabelProgressTitle.Text = PCLResources.Downloading;
                this.View.LabelProgressMessage.Text = message.Value.ToString();
            }
            else if (message.Key.Equals(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateExtracting))
            {
                // Update labels
                this.View.LabelProgressTitle.Text = PCLResources.Extracting;
                this.View.LabelProgressMessage.Text = message.Value.ToString();
            }
            else if (message.Key.Equals(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateProcessing))
            {
                // Update labels
                this.View.LabelProgressTitle.Text = PCLResources.Processing;
                this.View.LabelProgressMessage.Text = message.Value.ToString();
            }
            else if (message.Key.Equals(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateCompleting))
            {
                // Update labels
                this.View.LabelProgressTitle.Text = message.Value.ToString();
                this.View.LabelProgressMessage.Text = String.Empty;
            }
            else if (message.Key.Equals(MessagingCenterConstants.UpdateContentServiceRequestDone))
            {
                // Redirect to ViewMain
                this.Redirect();
            }
        }

        private void Redirect()
        {
            Application.Current.MainPage = new NavigationPage(new ViewMain().SetTitle(App.CurrentInstance.DependencyApplicationGeneral.GetApplicationName()))
            {
            };
        }

        private void UpdateLayoutMiddle()
        {
            // Clear elements in the middle of the splash screen
            this.View.StackLayoutMiddle.Children.Clear();

            // Create label for progress text
            this.View.LabelProgressTitle = new Label()
            {
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
                Text = PCLResources.CheckingForUpdate,
                FontSize = 24,
                FontAttributes = FontAttributes.Bold,
            };

            // Add progress text
            this.View.StackLayoutMiddle.Children.Add(this.View.LabelProgressTitle);

            // Create label for progress dots
            this.View.LabelProgressMessage = new Label()
            {
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
            };

            // Add progress dots
            this.View.StackLayoutMiddle.Children.Add(this.View.LabelProgressMessage);
        }
    }
}