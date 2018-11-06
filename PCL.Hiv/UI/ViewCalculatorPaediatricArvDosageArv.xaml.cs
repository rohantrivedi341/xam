using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Hiv.Common;
using PCL.Hiv.Common.View;
using PCL.UI.CustomViews;
using PCL.UI.Helpers;
using PCL.UI.Templates.Cells;
using Xamarin.Forms;
using ContentPageBase = PCL.Hiv.UI.Helpers.ContentPageBase;

namespace PCL.Hiv.UI
{
    public partial class ViewCalculatorPaediatricArvDosageArv : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public SearchBar SearchBar;

            public CV_ListView ListView;

            public CalculatorPaediatricArvDosageView CalculatorPaediatricArvDosageView;

            public List<CalculatorPaediatricArvDosageArv> CalculatorPaediatricArvDosageArvs;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }
        
        public ViewCalculatorPaediatricArvDosageArv()
        {
            this.InitializeComponent();

            this.View.SearchBar = this.searchBar;
            this.View.SearchBar.BackgroundColor = Color.FromHex("#adadad");
            this.View.SearchBar.TextChanged += this.OnSearchQueryChanged;

            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

            this.Title = HivResources.CalculatorPaediatricArvDosageSelectArv;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorPaediatricArvDosageView))
            {
                this.View.CalculatorPaediatricArvDosageView = (CalculatorPaediatricArvDosageView) this.BindingContext;
                this.View.CalculatorPaediatricArvDosageView.Arv = null;
                this.View.CalculatorPaediatricArvDosageView.WeightGroup = null;

                this.View.CalculatorPaediatricArvDosageArvs = this.View.RepositoryCalculatorPaediatricArvDosageArv.Get();
                
                this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

                this.View.ListView.ItemsSource = this.View.CalculatorPaediatricArvDosageArvs;
            }
        }

        private void OnSearchQueryChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(e.NewTextValue))
            {
                this.View.ListView.ItemsSource = this.View.CalculatorPaediatricArvDosageArvs;

                return;
            }

            this.View.ListView.ItemsSource = this.View.CalculatorPaediatricArvDosageArvs.Where(x => x.Title.ToLower().StartsWith(e.NewTextValue.ToLower().Trim()));
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorPaediatricArvDosageArv calculatorPaediatricArvDosageArv = (CalculatorPaediatricArvDosageArv) e.Item;

            this.View.CalculatorPaediatricArvDosageView.Arv = calculatorPaediatricArvDosageArv;

            this.Navigation.PushAsync(new ViewCalculatorPaediatricArvDosageWeightGroup
            {
                BindingContext = this.View.CalculatorPaediatricArvDosageView
            }, true);

            ((ListView) sender).SelectedItem = null;
        }
    }
}