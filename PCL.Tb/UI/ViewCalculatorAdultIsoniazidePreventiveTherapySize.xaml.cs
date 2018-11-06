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
    public partial class ViewCalculatorAdultIsoniazidePreventiveTherapySize : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public CV_ListView ListView;

            public CalculatorAdultIsoniazidePreventiveTherapyView CalculatorAdultIsoniazidePreventiveTherapyView;
            
            public List<CalculatorAdultIsoniazidePreventiveTherapySize> CalculatorAdultIsoniazidePreventiveTherapySizes;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorAdultIsoniazidePreventiveTherapySize()
        {
            this.InitializeComponent();
            
            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof(TextDefaultCell));

            this.Title = TbResources.CalculatorAdultIsoniazidePreventiveTherapySelectSize;
            
            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof(CalculatorAdultIsoniazidePreventiveTherapyView))
            {
                this.View.CalculatorAdultIsoniazidePreventiveTherapyView = (CalculatorAdultIsoniazidePreventiveTherapyView)this.BindingContext;
                this.View.CalculatorAdultIsoniazidePreventiveTherapyView.Size = null;
                
                this.View.CalculatorAdultIsoniazidePreventiveTherapySizes = this.View.RepositoryCalculatorAdultIsoniazidePreventiveTherapySize.GetByCalculatorAdultIsoniazidePreventiveTherapy(this.View.CalculatorAdultIsoniazidePreventiveTherapyView.Therapy.Id);
                
                this.View.ListView.ItemTemplate = new DataTemplate(typeof(TextDefaultCell));

                this.View.ListView.ItemsSource = this.View.CalculatorAdultIsoniazidePreventiveTherapySizes;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorAdultIsoniazidePreventiveTherapySize calculatorAdultIsoniazidePreventiveTherapySize = (CalculatorAdultIsoniazidePreventiveTherapySize)e.Item;
            
            this.View.CalculatorAdultIsoniazidePreventiveTherapyView.Size = calculatorAdultIsoniazidePreventiveTherapySize;
            
            this.Navigation.PushAsync(new ViewCalculatorAdultIsoniazidePreventiveTherapyResult()
            {
                BindingContext = this.View.CalculatorAdultIsoniazidePreventiveTherapyView
            }, true);

            ((ListView)sender).SelectedItem = null;
        }
    }
}