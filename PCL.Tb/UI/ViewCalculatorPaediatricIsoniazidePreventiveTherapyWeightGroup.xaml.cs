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
    public partial class ViewCalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public CV_ListView ListView;

            public CalculatorPaediatricIsoniazidePreventiveTherapyView CalculatorPaediatricIsoniazidePreventiveTherapyView;
            
            public List<CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup> CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroups;
            
            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup()
        {
            this.InitializeComponent();
            
            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof(TextDefaultCell));

            this.Title = TbResources.CalculatorPaediatricIsoniazidePreventiveTherapySelectWeightGroup;
            
            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof(CalculatorPaediatricIsoniazidePreventiveTherapyView))
            {
                this.View.CalculatorPaediatricIsoniazidePreventiveTherapyView = (CalculatorPaediatricIsoniazidePreventiveTherapyView)this.BindingContext;
                this.View.CalculatorPaediatricIsoniazidePreventiveTherapyView.Therapy = this.View.RepositoryCalculatorPaediatricIsoniazidePreventiveTherapy.Get().First();
                this.View.CalculatorPaediatricIsoniazidePreventiveTherapyView.WeightGroup = null;

                this.View.CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroups = this.View.RepositoryCalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup.GetByCalculatorPaediatricIsoniazidePreventiveTherapy(this.View.CalculatorPaediatricIsoniazidePreventiveTherapyView.Therapy.Id);
                
                this.View.ListView.ItemTemplate = new DataTemplate(typeof(TextDefaultCell));

                this.View.ListView.ItemsSource = this.View.CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroups;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup calculatorPaediatricIsoniazidePreventiveTherapyWeightGroup = (CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup)e.Item;

            this.View.CalculatorPaediatricIsoniazidePreventiveTherapyView.WeightGroup = calculatorPaediatricIsoniazidePreventiveTherapyWeightGroup;
            
            this.Navigation.PushAsync(new ViewCalculatorPaediatricIsoniazidePreventiveTherapyResult()
            {
                BindingContext = this.View.CalculatorPaediatricIsoniazidePreventiveTherapyView
            }, true);

            ((ListView)sender).SelectedItem = null;
        }
    }
}