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
    public partial class ViewCalculatorArvRenalDosageArv : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public SearchBar SearchBar;
            public CV_ListView ListView;

            public CalculatorArvRenalDosageView CalculatorArvRenalDosageView;

            public List<CalculatorArvRenalDosageArv> CalculatorArvRenalDosageArvs;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorArvRenalDosageArv()
        {
            this.InitializeComponent();

            this.View.SearchBar = this.searchBar;
            this.View.SearchBar.BackgroundColor = Color.FromHex("#adadad");
            this.View.SearchBar.TextChanged += this.OnSearchQueryChanged;

            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

            this.Title = HivResources.CalculatorArvRenalDosageSelectArv;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorArvRenalDosageView))
            {
                this.View.CalculatorArvRenalDosageView = (CalculatorArvRenalDosageView) this.BindingContext;
                this.View.CalculatorArvRenalDosageView.Arv = null;
                this.View.CalculatorArvRenalDosageView.Dosage = null;
                this.View.CalculatorArvRenalDosageView.DosageItem = null;
                this.View.CalculatorArvRenalDosageView.CreatinineClearance = null;

                this.View.CalculatorArvRenalDosageArvs = this.View.RepositoryCalculatorArvRenalDosageArv.Get();

                this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

                this.View.ListView.ItemsSource = this.View.CalculatorArvRenalDosageArvs;
            }
        }

        private void OnSearchQueryChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(e.NewTextValue))
            {
                this.View.ListView.ItemsSource = this.View.CalculatorArvRenalDosageArvs;

                return;
            }

            this.View.ListView.ItemsSource = this.View.CalculatorArvRenalDosageArvs.Where(x => x.Title.ToLower().StartsWith(e.NewTextValue.ToLower().Trim()));
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorArvRenalDosageArv calculatorArvRenalDosageArv = (CalculatorArvRenalDosageArv) e.Item;

            this.View.CalculatorArvRenalDosageView.Arv = calculatorArvRenalDosageArv;

            List<CalculatorArvRenalDosageDosage> calculatorArvRenalDosageDosages = this.View.RepositoryCalculatorArvRenalDosageDosage.GetByCalculatorArvRenalDosageArv(this.View.CalculatorArvRenalDosageView.Arv.Id);

            if (calculatorArvRenalDosageDosages.Count > 1)
            {
                this.Navigation.PushAsync(new ViewCalculatorArvRenalDosageDosage
                {
                    BindingContext = this.View.CalculatorArvRenalDosageView
                }, true);
            }
            else
            {
                this.View.CalculatorArvRenalDosageView.Dosage = calculatorArvRenalDosageDosages.First();

                this.Navigation.PushAsync(new ViewCalculatorArvRenalDosageResult()
                {
                    BindingContext = this.View.CalculatorArvRenalDosageView
                }, true);
            }

            ((ListView) sender).SelectedItem = null;
        }
    }
}