using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Phc.Common;
using PCL.Phc.Common.View;
using PCL.UI.CustomViews;
using PCL.UI.Helpers;
using PCL.UI.Templates.Cells;
using Xamarin.Forms;
using ContentPageBase = PCL.Phc.UI.Helpers.ContentPageBase;

namespace PCL.Phc.UI
{
    public partial class ViewCalculatorPaediatricDosageMedicine : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public SearchBar SearchBar;

            public CV_ListView ListView;

            public CalculatorPaediatricDosageView CalculatorPaediatricDosageView;

            public List<CalculatorPaediatricDosageDrug> CalculatorPaediatricDosageDrugs;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorPaediatricDosageMedicine()
        {
            this.InitializeComponent();

            this.View.SearchBar = this.searchBar;
            this.View.SearchBar.BackgroundColor = Color.FromHex("#adadad");
            this.View.SearchBar.TextChanged += this.OnSearchQueryChanged;

            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

            this.Title = PhcResources.CalculatorPaediatricDosageSelectMedicine;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorPaediatricDosageView))
            {
                this.View.CalculatorPaediatricDosageView = (CalculatorPaediatricDosageView) this.BindingContext;
                this.View.CalculatorPaediatricDosageView.Drug = null;
                this.View.CalculatorPaediatricDosageView.AgeWeightGroup = null;

                this.View.CalculatorPaediatricDosageDrugs = this.View.RepositoryCalculatorPaediatricDosageDrug.Get();

                this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

                this.View.ListView.ItemsSource = this.View.CalculatorPaediatricDosageDrugs;
            }
        }

        private void OnSearchQueryChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(e.NewTextValue))
            {
                this.View.ListView.ItemsSource = this.View.CalculatorPaediatricDosageDrugs;

                return;
            }

            this.View.ListView.ItemsSource = this.View.CalculatorPaediatricDosageDrugs.Where(x => x.Title.ToLower().StartsWith(e.NewTextValue.ToLower().Trim()));
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorPaediatricDosageDrug calculatorPaediatricDrugDosageDrug = (CalculatorPaediatricDosageDrug) e.Item;

            this.View.CalculatorPaediatricDosageView.Drug = calculatorPaediatricDrugDosageDrug;

            this.Navigation.PushAsync(new ViewCalculatorPaediatricDosageAgeWeightBand
            {
                BindingContext = this.View.CalculatorPaediatricDosageView
            }, true);

            ((ListView) sender).SelectedItem = null;
        }
    }
}