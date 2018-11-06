using System.Collections.Generic;
using PCL.Tb.Common;
using PCL.Tb.Common.View;
using PCL.UI.CustomViews;
using PCL.UI.Helpers;
using PCL.UI.Templates.Cells;
using Xamarin.Forms;
using ContentPageBase = PCL.Tb.UI.Helpers.ContentPageBase;

namespace PCL.Tb.UI
{
    public partial class ViewCalculatorPaediatricDsTbDosageWeightGroup : Tb.UI.Helpers.ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public CV_ListView ListView;

            public CalculatorPaediatricDsTbDosageView CalculatorPaediatricDsTbDosageView;

            public List<CalculatorPaediatricDsTbDosageWeightGroup> CalculatorPaediatricArvDosageWeightGroups;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }
        
        public ViewCalculatorPaediatricDsTbDosageWeightGroup()
        {
            this.InitializeComponent();

            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

            this.Title = TbResources.CalculatorPaediatricDsTbDosageSelectWeightGroup;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorPaediatricDsTbDosageView))
            {
                this.View.CalculatorPaediatricDsTbDosageView = (CalculatorPaediatricDsTbDosageView) this.BindingContext;
                this.View.CalculatorPaediatricDsTbDosageView.WeightGroup = null;

                if(this.View.CalculatorPaediatricDsTbDosageView.Phase == null)
                {
                    this.View.CalculatorPaediatricArvDosageWeightGroups = this.View.RepositoryCalculatorPaediatricDsTbDosageWeightGroup.GetByCalculatorPaediatricDsTbDosageCategory(this.View.CalculatorPaediatricDsTbDosageView.Category.Id);
                }
                else
                {
                    this.View.CalculatorPaediatricArvDosageWeightGroups = this.View.RepositoryCalculatorPaediatricDsTbDosageWeightGroup.GetByCalculatorPaediatricDsTbDosagePhase(this.View.CalculatorPaediatricDsTbDosageView.Phase.Id);
                }

                this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

                this.View.ListView.ItemsSource = this.View.CalculatorPaediatricArvDosageWeightGroups;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorPaediatricDsTbDosageWeightGroup calculatorPaediatricArvDosageWeightGroup = (CalculatorPaediatricDsTbDosageWeightGroup) e.Item;

            this.View.CalculatorPaediatricDsTbDosageView.WeightGroup = calculatorPaediatricArvDosageWeightGroup;

            this.Navigation.PushAsync(new ViewCalculatorPaediatricDsTbDosageResult
            {
                BindingContext = this.View.CalculatorPaediatricDsTbDosageView
            }, true);

            ((ListView) sender).SelectedItem = null;
        }
    }
}