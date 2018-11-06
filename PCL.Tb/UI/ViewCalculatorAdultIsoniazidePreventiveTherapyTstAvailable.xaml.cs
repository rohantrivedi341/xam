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
    public partial class ViewCalculatorAdultIsoniazidePreventiveTherapyTstAvailable : ContentPageBase
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

        public ViewCalculatorAdultIsoniazidePreventiveTherapyTstAvailable()
        {
            this.InitializeComponent();

            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof(TextDefaultCell));

            this.Title = TbResources.CalculatorAdultIsoniazidePreventiveTherapySelectTstAvailble;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof(CalculatorAdultIsoniazidePreventiveTherapyView))
            {
                this.View.CalculatorAdultIsoniazidePreventiveTherapyView = (CalculatorAdultIsoniazidePreventiveTherapyView)this.BindingContext;
                this.View.CalculatorAdultIsoniazidePreventiveTherapyView.TstAvailable = false;
                this.View.CalculatorAdultIsoniazidePreventiveTherapyView.Therapy = null;
                this.View.CalculatorAdultIsoniazidePreventiveTherapyView.Size = null;

                this.View.ListView.ItemTemplate = new DataTemplate(typeof(TextDefaultCell));

                List<String> artTreatments = new List<string>();
                artTreatments.Add(TbResources.CalculatorAdultIsoniazidePreventiveTherapyTstAvailable);
                artTreatments.Add(TbResources.CalculatorAdultIsoniazidePreventiveTherapyTstAvailableNot);

                this.View.ListView.ItemsSource = artTreatments;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            this.View.CalculatorAdultIsoniazidePreventiveTherapyView.TstAvailable = e.Item.ToString().Equals(TbResources.CalculatorAdultIsoniazidePreventiveTherapyTstAvailable);

            this.View.CalculatorAdultIsoniazidePreventiveTherapyView.Therapy = this.View.RepositoryCalculatorAdultIsoniazidePreventiveTherapy.Get(this.View.CalculatorAdultIsoniazidePreventiveTherapyView.ArtTreatment, this.View.CalculatorAdultIsoniazidePreventiveTherapyView.TstAvailable);

            List<CalculatorAdultIsoniazidePreventiveTherapySize> calculatorAdultIsoniazidePreventiveTherapySizes = this.View.RepositoryCalculatorAdultIsoniazidePreventiveTherapySize.GetByCalculatorAdultIsoniazidePreventiveTherapy(this.View.CalculatorAdultIsoniazidePreventiveTherapyView.Therapy.Id);

            if (calculatorAdultIsoniazidePreventiveTherapySizes.Any())
            {
                this.Navigation.PushAsync(new ViewCalculatorAdultIsoniazidePreventiveTherapySize()
                {
                    BindingContext = this.View.CalculatorAdultIsoniazidePreventiveTherapyView
                }, true);
            }
            else
            {
                this.Navigation.PushAsync(new ViewCalculatorAdultIsoniazidePreventiveTherapyResult()
                {
                    BindingContext = this.View.CalculatorAdultIsoniazidePreventiveTherapyView
                }, true);
            }

            ((ListView)sender).SelectedItem = null;
        }
    }
}