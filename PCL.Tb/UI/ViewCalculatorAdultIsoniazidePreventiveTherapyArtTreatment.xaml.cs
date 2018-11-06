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
    public partial class ViewCalculatorAdultIsoniazidePreventiveTherapyArtTreatment : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public CV_ListView ListView;

            public CalculatorAdultIsoniazidePreventiveTherapyView CalculatorAdultIsoniazidePreventiveTherapyView;
            
            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorAdultIsoniazidePreventiveTherapyArtTreatment()
        {
            this.InitializeComponent();
            
            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof(TextDefaultCell));

            this.Title = TbResources.CalculatorAdultIsoniazidePreventiveTherapySelectArtTreatment;
            
            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof(CalculatorAdultIsoniazidePreventiveTherapyView))
            {
                this.View.CalculatorAdultIsoniazidePreventiveTherapyView = (CalculatorAdultIsoniazidePreventiveTherapyView)this.BindingContext;
                this.View.CalculatorAdultIsoniazidePreventiveTherapyView.ArtTreatment = false;
                this.View.CalculatorAdultIsoniazidePreventiveTherapyView.TstAvailable = false;
                this.View.CalculatorAdultIsoniazidePreventiveTherapyView.Therapy = null;
                this.View.CalculatorAdultIsoniazidePreventiveTherapyView.Size = null;
                
                this.View.ListView.ItemTemplate = new DataTemplate(typeof(TextDefaultCell));

                List<String> artTreatments = new List<string>();
                artTreatments.Add(TbResources.CalculatorAdultIsoniazidePreventiveTherapyArtTreatment);
                artTreatments.Add(TbResources.CalculatorAdultIsoniazidePreventiveTherapyArtTreatmentNot);
                
                this.View.ListView.ItemsSource = artTreatments;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            this.View.CalculatorAdultIsoniazidePreventiveTherapyView.ArtTreatment = e.Item.ToString().Equals(TbResources.CalculatorAdultIsoniazidePreventiveTherapyArtTreatment);
            
            this.Navigation.PushAsync(new ViewCalculatorAdultIsoniazidePreventiveTherapyTstAvailable()
            {
                BindingContext = this.View.CalculatorAdultIsoniazidePreventiveTherapyView
            }, true);

            ((ListView)sender).SelectedItem = null;
        }
    }
}