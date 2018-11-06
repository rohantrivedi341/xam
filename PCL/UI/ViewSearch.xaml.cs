using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PCL.Common;
using PCL.Common.Enum;
using PCL.UI.CustomViews;
using PCL.UI.Helpers;
using Xamarin.Forms;
using Label = PCL.Common.Label;

namespace PCL.UI
{
    public partial class ViewSearch : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private new class ViewModel : ContentPageBase.ViewModel
        {
            public SearchBar SearchBar;
            public CV_ListView ListView;

            public List<Label> Labels;

            public TaskCompletionSource<Boolean> SearchItemsQueried = new TaskCompletionSource<Boolean>();

            public Boolean Searching;
            public String QueryTyped = String.Empty;
            public String QuerySeached = String.Empty;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewSearch()
        {
            this.InitializeComponent();

            // Get SerarchBar
            this.View.SearchBar = this.searchBar;
            this.View.SearchBar.BackgroundColor = Color.FromHex("#adadad");
            this.View.SearchBar.TextChanged += this.OnSearchQueryChanged;
            this.View.SearchBar.SearchButtonPressed += this.OnSearchButtonPressed;

            // Get ListView
            this.View.ListView = this.listView;

            // Set item template
            this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextCell));

            // Set bindings
            this.View.ListView.ItemTemplate.SetBinding(TextCell.TextProperty, "Title");
            this.View.ListView.ItemTemplate.SetBinding(TextCell.DetailProperty, "SubTitle");
            this.View.ListView.ItemTemplate.SetValue(TextCell.TextColorProperty, Color.Black);
            this.View.ListView.ItemTemplate.SetValue(TextCell.DetailColorProperty, Color.Gray);

            // Set ItemTapped handler
            this.View.ListView.ItemTapped += this.OnItemTapped;

            // Set title
            this.Title = PCLResources.Search;

            // Create Home toolbar item
            ToolbarCommand.Home(this);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Focus SearchBar automatically
            this.View.SearchBar.Focus();

            // Get search items in different task
            Task.Run(() =>
                     {
                         this.View.Labels = this.View.RepositoryLabel.Get().ToList();

                         // Set result for delay finished task
                         this.View.SearchItemsQueried.SetResult(true);
                     });
        }

        private void OnSearchQueryChanged(object sender, TextChangedEventArgs e)
        {
            // Set query
            this.View.QueryTyped = e.NewTextValue;

            // Process query change async
            this.Query();
        }

        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
            // Set query
            this.View.QueryTyped = this.View.SearchBar.Text;

            // Process query change async
            this.Query();
        }

        private async void Query()
        {
            // Not searching already
            if (!this.View.Searching)
            {
                this.View.Searching = true;

                this.View.QuerySeached = this.View.QueryTyped;

                await this.View.SearchItemsQueried.Task;

                IEnumerable itemSource;

                if (String.IsNullOrWhiteSpace(this.View.QuerySeached))
                {
                    itemSource = new List<Label>();
                }
                else
                {
                    itemSource = this.View.Labels.Where(x => x.Title.ToLower().Contains(this.View.QuerySeached.ToLower().Trim())).ToList();
                }

                Device.BeginInvokeOnMainThread(() => { this.View.ListView.ItemsSource = itemSource; });

                this.View.Searching = false;

                if (this.View.QuerySeached != this.View.QueryTyped)
                {
                    this.Query();
                }
            }
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Label label = (Label) e.Item;

            StructureItem structureItem = this.View.RepositoryStructureItem.Get(label.StructureItemId);

            switch (label.Type)
            {
                case StructureItemType.Category:

                    // Show children
                    await this.Navigation.PushAsync(new ViewStructureItemList
                    {
                        BindingContext = structureItem
                    }, true);
                    break;
                case StructureItemType.Page:

                    // Show page
                    await this.Navigation.PushAsync(new ViewItemPage
                    {
                        BindingContext = structureItem
                    }, true);
                    break;
                case StructureItemType.Contact:

                    // Show contact
                    await this.Navigation.PushAsync(new ViewItemContact
                    {
                        BindingContext = structureItem
                    }, true);
                    break;
            }

            // Deselect item
            ((ListView) sender).SelectedItem = null;
        }
    }
}