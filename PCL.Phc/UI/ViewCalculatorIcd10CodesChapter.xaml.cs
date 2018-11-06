using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PCL.Phc.Common;
using PCL.Phc.Common.View;
using PCL.UI.CustomViews;
using PCL.UI.Helpers;
using PCL.UI.Templates.Cells;
using Xamarin.Forms;
using ContentPageBase = PCL.Phc.UI.Helpers.ContentPageBase;

namespace PCL.Phc.UI
{
    public partial class ViewCalculatorIcd10CodesChapter : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public SearchBar SearchBar;

            public CV_ListView ListView;

            public CalculatorIcd10View CalculatorIcd10View;

            public List<CalculatorIcd10CodesChapter> CalculatorWhoDiseasesChapters;
            public List<CalculatorIcd10CodesCode> CalculatorWhoDiseasesCodes;

            public TaskCompletionSource<Boolean> SearchItemsQueried = new TaskCompletionSource<Boolean>();

            public Boolean Searching;
            public String QueryTyped = String.Empty;
            public String QuerySeached = String.Empty;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorIcd10CodesChapter()
        {
            this.InitializeComponent();

            this.View.SearchBar = this.searchBar;
            this.View.SearchBar.BackgroundColor = Color.FromHex("#adadad");
            this.View.SearchBar.TextChanged += this.OnSearchQueryChanged;

            this.View.ListView = this.listView;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));
            this.View.ListView.ItemTapped += this.OnItemTapped;

            this.Title = PhcResources.CalculatorIcd10CodesSelectChapter;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorIcd10View))
            {
                this.View.CalculatorIcd10View = (CalculatorIcd10View) this.BindingContext;
                this.View.CalculatorIcd10View.Chapter = null;
                this.View.CalculatorIcd10View.Block = null;
                this.View.CalculatorIcd10View.Code = null;

                this.View.CalculatorWhoDiseasesChapters = this.View.RepositoryCalculatorIcd10CodesChapter.Get();

                this.View.ListView.ItemsSource = this.View.CalculatorWhoDiseasesChapters;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Get search items in different task
            Task.Run(() =>
                     {
                         this.View.CalculatorWhoDiseasesCodes = this.View.RepositoryCalculatorIcd10CodesCode.Get().Where(x => x.Code.Length > 3).ToList();
                         
                         // Set result for delay finished task
                         this.View.SearchItemsQueried.SetResult(true);
                     });
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();

            await this.View.SearchItemsQueried.Task;
        }

        private void OnSearchQueryChanged(object sender, TextChangedEventArgs e)
        {
            // Set query
            this.View.QueryTyped = e.NewTextValue;

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
                    itemSource = this.View.CalculatorWhoDiseasesChapters;
                }
                else
                {
                    itemSource = this.View.CalculatorWhoDiseasesCodes.Where(x => x.Code.ToLower().StartsWith(this.View.QuerySeached.ToLower().Trim()) || x.Title.ToLower().Contains(this.View.QuerySeached.ToLower().Trim()));
                }

                Device.BeginInvokeOnMainThread(() => { this.View.ListView.ItemsSource = itemSource; });

                this.View.Searching = false;

                if (this.View.QuerySeached != this.View.QueryTyped)
                {
                    this.Query();
                }
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.View.SearchBar.Text))
            {
                CalculatorIcd10CodesChapter calculatorWhoDiseasesChapter = (CalculatorIcd10CodesChapter) e.Item;

                this.View.CalculatorIcd10View.Chapter = calculatorWhoDiseasesChapter;

                this.Navigation.PushAsync(new ViewCalculatorIcd10CodesBlock()
                {
                    BindingContext = this.View.CalculatorIcd10View
                }, true);

                ((ListView) sender).SelectedItem = null;
            }
            else
            {
                CalculatorIcd10CodesCode calculatorWhoDiseasesCode = (CalculatorIcd10CodesCode) e.Item;

                this.View.CalculatorIcd10View.Chapter = this.View.RepositoryCalculatorIcd10CodesChapter.Get(calculatorWhoDiseasesCode.Chapter);
                this.View.CalculatorIcd10View.Block = this.View.RepositoryCalculatorIcd10CodesBlock.GetByNumber(calculatorWhoDiseasesCode.Block);
                this.View.CalculatorIcd10View.Code = this.View.RepositoryCalculatorIcd10CodesCode.GetByCode(calculatorWhoDiseasesCode.Code.Substring(0, 3));

                this.Navigation.PushAsync(new ViewCalculatorIcd10CodesResult()
                {
                    BindingContext = this.View.CalculatorIcd10View
                }, true);

                ((ListView) sender).SelectedItem = null;
            }
        }
    }
}