using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Tb.Common;
using PCL.Tb.Common.View;
using PCL.UI.CustomViews;
using PCL.UI.Helpers;
using PCL.UI.Templates.Cells;
using Xamarin.Forms;
using ContentPageBase = PCL.Tb.UI.Helpers.ContentPageBase;

namespace PCL.Tb.UI
{
    public partial class ViewCalculatorPaediatricDsTbDosageCategory : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public CV_ListView ListView;

            public CalculatorPaediatricDsTbDosageView CalculatorPaediatricDsTbDosageView;
            
            public List<CalculatorPaediatricDsTbDosageCategory> CalculatorPaediatricDsTbDosageCategories;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorPaediatricDsTbDosageCategory()
        {
            this.InitializeComponent();
            
            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof(TextDefaultCell));

            this.Title = TbResources.CalculatorPaediatricDsTbDosageSelectCategory;
            
            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof(CalculatorPaediatricDsTbDosageView))
            {
                this.View.CalculatorPaediatricDsTbDosageView = (CalculatorPaediatricDsTbDosageView)this.BindingContext;
                this.View.CalculatorPaediatricDsTbDosageView.Category = null;
                this.View.CalculatorPaediatricDsTbDosageView.WeightGroup = null;
                
                this.View.CalculatorPaediatricDsTbDosageCategories = this.View.RepositoryCalculatorPaediatricDsTbDosageCategory.Get();
                
                this.View.ListView.ItemTemplate = new DataTemplate(typeof(TextDefaultCell));

                this.View.ListView.ItemsSource = this.View.CalculatorPaediatricDsTbDosageCategories;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorPaediatricDsTbDosageCategory calculatorPaediatricDsTbDosageCategory = (CalculatorPaediatricDsTbDosageCategory)e.Item;

            this.View.CalculatorPaediatricDsTbDosageView.Category = calculatorPaediatricDsTbDosageCategory;

            List<CalculatorPaediatricDsTbDosagePhase> calculatorPaediatricDsTbDosagePhases = this.View.RepositoryCalculatorPaediatricDsTbDosagePhase.GetByCalculatorPaediatricDsTbDosageCategory(this.View.CalculatorPaediatricDsTbDosageView.Category.Id);

            if (calculatorPaediatricDsTbDosagePhases.Any())
            {
                this.Navigation.PushAsync(new ViewCalculatorPaediatricDsTbDosagePhase()
                {
                    BindingContext = this.View.CalculatorPaediatricDsTbDosageView
                }, true);
            }
            else
            {
                this.Navigation.PushAsync(new ViewCalculatorPaediatricDsTbDosageWeightGroup()
                {
                    BindingContext = this.View.CalculatorPaediatricDsTbDosageView
                }, true);
            }

            ((ListView)sender).SelectedItem = null;
        }
    }
}