using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using PCL.Common;
using PCL.UI.Helpers;
using PCL.UI.Templates;
using PCL.UI.Templates.Views;
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace PCL.UI
{
    public partial class ViewItemContact : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private new class ViewModel : ContentPageBase.ViewModel
        {
            public StackLayout StackLayout;

            public Section Section;
            public StructureItem StructureItem;
            public ItemContact ItemContact;
            public List<ItemContactNumber> ItemContactNumbers;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewItemContact()
        {
            this.InitializeComponent();

            // Get StackLayout
            this.View.StackLayout = this.stackLayout;

            // Create Search toolbar item
            ToolbarCommand.Search(this);

            // Create Home toolbar item
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (StructureItem))
            {
                this.View.StructureItem = (StructureItem) this.BindingContext;

                // Get Section
                this.View.Section = this.View.RepositorySection.Get(this.View.StructureItem.SectionId);

                // Log screen view
                App.CurrentInstance.DependencyPlatformGoogleAnalytics.LogScreen(String.Format("{0} - {1}", this.View.Section.Title, this.View.StructureItem.Title));

                // Get ItemContact
                this.View.ItemContact = this.View.RepositoryItemContact.GetByStructureItem(this.View.StructureItem.Id);

                // Get ItemContactNumbers
                this.View.ItemContactNumbers = this.View.RepositoryItemContactNumber.GetByItemContact(this.View.ItemContact.Id);

                // Add PhysicalAddress when this property has a value
                if (!String.IsNullOrWhiteSpace(this.View.ItemContact.PhysicalAddress))
                {
                    this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(PCLResources.ItemContactPhysicalAddress).Bold(), new LabelView(this.View.ItemContact.PhysicalAddress)));
                }

                // Add PostalAddress when this property has a value
                if (!String.IsNullOrWhiteSpace(this.View.ItemContact.PostalAddress))
                {
                    this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(PCLResources.ItemContactPostalAddress).Bold(), new LabelView(this.View.ItemContact.PostalAddress)));
                }

                // Add WebsiteUrl when this property has a value
                if (!String.IsNullOrWhiteSpace(this.View.ItemContact.WebsiteUrl))
                {
                    this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(PCLResources.ItemContactWebsite).Bold(), new LabelView(this.View.ItemContact.WebsiteUrl).InteractionBrowser()));
                }

                // Add EmailAddress when this property has a value
                if (!String.IsNullOrWhiteSpace(this.View.ItemContact.EmailAddress))
                {
                    this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(PCLResources.ItemContactEmailAddress).Bold(), new LabelView(this.View.ItemContact.EmailAddress).InteractionEmail()));
                }

                // Add WorkingHours when this property has a value
                if (!String.IsNullOrWhiteSpace(this.View.ItemContact.WorkingHours))
                {
                    this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(PCLResources.ItemContactWorkingHours).Bold(), new LabelView(this.View.ItemContact.WorkingHours)));
                }

                // Add Facility title
                if (!String.IsNullOrWhiteSpace(this.View.ItemContact.FacilityClassification) || !String.IsNullOrWhiteSpace(this.View.ItemContact.FacilityManager) || !String.IsNullOrWhiteSpace(this.View.ItemContact.FacilityManagerEmailAddress))
                {
                    this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(PCLResources.ItemContactFacility).Bold()));
                }

                // Add FacilityClassification when this property has a value
                if (!String.IsNullOrWhiteSpace(this.View.ItemContact.FacilityClassification))
                {
                    this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(PCLResources.ItemContactFacilityClassification).Bold(), new LabelView(this.View.ItemContact.FacilityClassification)));
                }

                // Add FacilityManager when this property has a value
                if (!String.IsNullOrWhiteSpace(this.View.ItemContact.FacilityManager))
                {
                    this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(PCLResources.ItemContactFacilityManager).Bold(), new LabelView(this.View.ItemContact.FacilityManager)));
                }

                // Add FacilityManager when this property has a value
                if (!String.IsNullOrWhiteSpace(this.View.ItemContact.FacilityManagerEmailAddress))
                {
                    this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(PCLResources.ItemContactFacilityManagerEmailAddress).Bold(), new LabelView(this.View.ItemContact.FacilityManagerEmailAddress).InteractionEmail()));
                }

                // ItemContactNumbers for this ItemContact exists
                if (this.View.ItemContactNumbers.Any())
                {
                    // Add ItemContactNubmers title
                    this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(PCLResources.ItemContactContactNumbers).Bold()));

                    // Add each ItemContactNumber
                    foreach (ItemContactNumber itemContactNumber in this.View.ItemContactNumbers)
                    {
                        this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(itemContactNumber.Title), new LabelView(itemContactNumber.Telephone).InteractionPhone()));
                    }
                }

                // Add map when geolocation is available
                if (this.View.ItemContact.Latitude != null && this.View.ItemContact.Longitude != null)
                {
                    this.AddMap();
                }

                // Set title
                this.Title = this.View.StructureItem.Title;

                // Create Favorite toolbar item
                ToolbarCommand.Favorite(this, this.View.RepositoryFavorite, this.View.StructureItem);
            }
        }

        private void AddMap()
        {
            // Show map when connected to the internet 
            if (CrossConnectivity.Current.IsConnected)
            {
                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(PCLResources.ItemContactMap).Bold()));

                // Formate map position
                Position mapPosition = new Position(Double.Parse(this.View.ItemContact.Latitude, CultureInfo.InvariantCulture), Double.Parse(this.View.ItemContact.Longitude, CultureInfo.InvariantCulture));

                // Create map
                Map map = new Map(MapSpan.FromCenterAndRadius(mapPosition, Distance.FromKilometers(2.0)))
                {
                    HeightRequest = 300,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HasScrollEnabled = false,
                    MapType = MapType.Street
                };

                Pin pin = new Pin
                {
                    Type = PinType.Place,
                    Position = mapPosition,
                    Label = this.View.ItemContact.Title,
                    Address = this.View.ItemContact.PhysicalAddress,
                };

                //pin.Clicked += async (s, e) =>
                //{

                //};

                // Add pin for current location
                map.Pins.Add(pin);

                this.View.StackLayout.Children.Add(map);
            }

            // Show text when not connected to the internet
            else
            {
                this.View.StackLayout.Children.Add(TemplateSpace.Create());

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(PCLResources.ItemContactMap).Bold(), new LabelView(PCLResources.ItemContactMapNoInternetConnection).XAlign(TextAlignment.Center).TextColor(Color.Gray)));
            }

            this.View.StackLayout.Children.Add(TemplateSpace.Create());

            // Add link to open location in navigation application
            this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(PCLResources.ItemContactOpenThisLocationInMapApplication).XAlign(TextAlignment.Center).InteractionMap(this.View.ItemContact)));

            this.View.StackLayout.Children.Add(TemplateSpace.Create());
        }
    }
}