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
    public partial class ViewCalculatorAdultDsTbDosageWeightGroup : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public CV_ListView ListView;

            public CalculatorAdultDsTbDosageView CalculatorAdultDsTbDosageView;
            
            public List<CalculatorAdultDsTbDosageWeightGroup> CalculatorAdultDsTbDosageWeightGroups;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorAdultDsTbDosageWeightGroup()
        {
            this.InitializeComponent();
            
            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof(TextDefaultCell));

            this.Title = TbResources.CalculatorAdultDsTbDosageSelectWeightGroup;
            
            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof(CalculatorAdultDsTbDosageView))
            {
                this.View.CalculatorAdultDsTbDosageView = (CalculatorAdultDsTbDosageView)this.BindingContext;
                this.View.CalculatorAdultDsTbDosageView.WeightGroup = null;
                
                this.View.CalculatorAdultDsTbDosageWeightGroups = this.View.RepositoryCalculatorAdultDsTbDosageWeightGroup.GetByCalculatorAdultDsTbDosageDrug(this.View.CalculatorAdultDsTbDosageView.Drug.Id);
                
                this.View.ListView.ItemTemplate = new DataTemplate(typeof(TextDefaultCell));

                this.View.ListView.ItemsSource = this.View.CalculatorAdultDsTbDosageWeightGroups;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorAdultDsTbDosageWeightGroup calculatorAdultDsTbDosageWeightGroup = (CalculatorAdultDsTbDosageWeightGroup)e.Item;
            
            this.View.CalculatorAdultDsTbDosageView.WeightGroup = calculatorAdultDsTbDosageWeightGroup;
            
            this.Navigation.PushAsync(new ViewCalculatorAdultDsTbDosageResult()
            {
                BindingContext = this.View.CalculatorAdultDsTbDosageView
            }, true);

            ((ListView)sender).SelectedItem = null;
        }
    }
}