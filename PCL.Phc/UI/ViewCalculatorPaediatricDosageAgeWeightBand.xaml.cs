using System.Collections.Generic;
using PCL.Phc.Common;
using PCL.Phc.Common.View;
using PCL.UI.CustomViews;
using PCL.UI.Helpers;
using PCL.UI.Templates.Cells;
using Xamarin.Forms;
using ContentPageBase = PCL.Phc.UI.Helpers.ContentPageBase;

namespace PCL.Phc.UI
{
    public partial class ViewCalculatorPaediatricDosageAgeWeightBand : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public CV_ListView ListView;

            public CalculatorPaediatricDosageView CalculatorPaediatricDosageView;

            public List<CalculatorPaediatricDosageAgeWeightGroup> CalculatorPaediatricDosageWeightGroups;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorPaediatricDosageAgeWeightBand()
        {
            this.InitializeComponent();

            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

            this.Title = PhcResources.CalculatorPaediatricDosageSelectAgeWeightBand;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorPaediatricDosageView))
            {
                this.View.CalculatorPaediatricDosageView = (CalculatorPaediatricDosageView) this.BindingContext;
                this.View.CalculatorPaediatricDosageView.AgeWeightGroup = null;

                this.View.CalculatorPaediatricDosageWeightGroups = this.View.RepositoryCalculatorPaediatricDosageAgeWeightGroup.GetByCalculatorPaediatricDrugDosageDrug(this.View.CalculatorPaediatricDosageView.Drug.Id);

                this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

                this.View.ListView.ItemsSource = this.View.CalculatorPaediatricDosageWeightGroups;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorPaediatricDosageAgeWeightGroup calculatorPaediatricDrugDosageWeightGroup = (CalculatorPaediatricDosageAgeWeightGroup) e.Item;

            this.View.CalculatorPaediatricDosageView.AgeWeightGroup = calculatorPaediatricDrugDosageWeightGroup;

            this.Navigation.PushAsync(new ViewCalculatorPaediatricDosageResult
            {
                BindingContext = this.View.CalculatorPaediatricDosageView
            }, true);

            ((ListView) sender).SelectedItem = null;
        }
    }
}