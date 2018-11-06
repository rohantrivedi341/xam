using System.Collections.Generic;
using PCL.Hiv.Common;
using PCL.Hiv.Common.View;
using PCL.UI.CustomViews;
using PCL.UI.Helpers;
using PCL.UI.Templates.Cells;
using Xamarin.Forms;
using ContentPageBase = PCL.Hiv.UI.Helpers.ContentPageBase;

namespace PCL.Hiv.UI
{
    public partial class ViewCalculatorPaediatricArvDosageWeightGroup : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public CV_ListView ListView;

            public CalculatorPaediatricArvDosageView CalculatorPaediatricArvDosageView;

            public List<CalculatorPaediatricArvDosageWeightGroup> CalculatorPaediatricArvDosageWeightGroups;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }
        
        public ViewCalculatorPaediatricArvDosageWeightGroup()
        {
            this.InitializeComponent();

            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

            this.Title = HivResources.CalculatorPaediatricArvDosageSelectWeightGroup;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorPaediatricArvDosageView))
            {
                this.View.CalculatorPaediatricArvDosageView = (CalculatorPaediatricArvDosageView) this.BindingContext;
                this.View.CalculatorPaediatricArvDosageView.WeightGroup = null;

                this.View.CalculatorPaediatricArvDosageWeightGroups = this.View.RepositoryCalculatorPaediatricArvDosageWeightGroup.GetByCalculatorPaedatircArvDosageArv(this.View.CalculatorPaediatricArvDosageView.Arv.Id);
                
                this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

                this.View.ListView.ItemsSource = this.View.CalculatorPaediatricArvDosageWeightGroups;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorPaediatricArvDosageWeightGroup calculatorPaediatricArvDosageWeightGroup = (CalculatorPaediatricArvDosageWeightGroup) e.Item;

            this.View.CalculatorPaediatricArvDosageView.WeightGroup = calculatorPaediatricArvDosageWeightGroup;

            this.Navigation.PushAsync(new ViewCalculatorPaediatricArvDosageResult
            {
                BindingContext = this.View.CalculatorPaediatricArvDosageView
            }, true);

            ((ListView) sender).SelectedItem = null;
        }
    }
}