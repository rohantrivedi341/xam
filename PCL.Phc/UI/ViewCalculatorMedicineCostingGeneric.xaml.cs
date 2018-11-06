using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Phc.Common;
using PCL.Phc.Common.View;
using PCL.UI.CustomViews;
using PCL.UI.Helpers;
using Xamarin.Forms;
using ContentPageBase = PCL.Phc.UI.Helpers.ContentPageBase;

namespace PCL.Phc.UI
{
    public partial class ViewCalculatorMedicineCostingGeneric : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public SearchBar SearchBar;

            public CV_ListView ListView;

            public CalculatorMedicineCostingView CalculatorMedicineCostingView;

            public List<CalculatorMedicineCostingGeneric> CalculatorMedicineCostingGenerics;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorMedicineCostingGeneric()
        {
            this.InitializeComponent();

            this.View.SearchBar = this.searchBar;
            this.View.SearchBar.BackgroundColor = Color.FromHex("#adadad");
            this.View.SearchBar.TextChanged += this.OnSearchQueryChanged;

            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextCell));
            this.View.ListView.ItemTemplate.SetBinding(TextCell.TextProperty, "Title");
            this.View.ListView.ItemTemplate.SetBinding(TextCell.DetailProperty, "Labels");
            this.View.ListView.ItemTemplate.SetValue(TextCell.TextColorProperty, Color.Black);
            this.View.ListView.ItemTemplate.SetValue(TextCell.DetailColorProperty, Color.Gray);

            this.Title = PhcResources.CalculatorMedicineCostingSelectGenericName;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorMedicineCostingView))
            {
                this.View.CalculatorMedicineCostingView = (CalculatorMedicineCostingView) this.BindingContext;
                this.View.CalculatorMedicineCostingView.Generic = null;

                this.View.CalculatorMedicineCostingGenerics = this.View.RepositoryCalculatorMedicineCostingGeneric.Get();

                this.View.ListView.ItemsSource = this.View.CalculatorMedicineCostingGenerics;
            }
        }

        private void OnSearchQueryChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(e.NewTextValue))
            {
                this.View.ListView.ItemsSource = this.View.CalculatorMedicineCostingGenerics;

                return;
            }

            this.View.ListView.ItemsSource = this.View.CalculatorMedicineCostingGenerics.Where(x => x.Title.ToLower().StartsWith(e.NewTextValue.ToLower().Trim()) || x.Labels.ToLower().Contains(e.NewTextValue.ToLower().Trim()));
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorMedicineCostingGeneric calculatorMedicineCostingGeneric = (CalculatorMedicineCostingGeneric) e.Item;

            this.View.CalculatorMedicineCostingView.Generic = calculatorMedicineCostingGeneric;

            this.Navigation.PushAsync(new ViewCalculatorMedicineCostingResults()
            {
                BindingContext = this.View.CalculatorMedicineCostingView
            }, true);

            ((ListView) sender).SelectedItem = null;
        }
    }
}