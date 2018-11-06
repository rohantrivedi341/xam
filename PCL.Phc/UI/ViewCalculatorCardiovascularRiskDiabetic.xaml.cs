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
    public partial class ViewCalculatorCardiovascularRiskDiabetic : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public CV_ListView ListView;

            public CalculatorCardiovascularRiskView CalculatorCardiovascularRiskView;

            public List<CalculatorCardiovascularRiskDiabetic> CalculatorCardiovascularRiskDiabetics;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorCardiovascularRiskDiabetic()
        {
            this.InitializeComponent();

            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

            this.Title = PhcResources.CalculatorCardiovascularRiskSelectDiabetic;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorCardiovascularRiskView))
            {
                this.View.CalculatorCardiovascularRiskView = (CalculatorCardiovascularRiskView) this.BindingContext;
                this.View.CalculatorCardiovascularRiskView.Diabetic = null;
                this.View.CalculatorCardiovascularRiskView.BpTreatment = null;
                this.View.CalculatorCardiovascularRiskView.SystolicBp = null;

                this.View.CalculatorCardiovascularRiskDiabetics = this.View.RepositoryCalculatorCardiovascularRiskDiabetic.Get();

                this.View.ListView.ItemsSource = this.View.CalculatorCardiovascularRiskDiabetics;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorCardiovascularRiskDiabetic calculatorCardiovascularRiskDiabetic = (CalculatorCardiovascularRiskDiabetic) e.Item;

            this.View.CalculatorCardiovascularRiskView.Diabetic = calculatorCardiovascularRiskDiabetic;

            this.Navigation.PushAsync(new ViewCalculatorCardiovascularRiskBpTreatment()
            {
                BindingContext = this.View.CalculatorCardiovascularRiskView
            }, true);

            ((ListView) sender).SelectedItem = null;
        }
    }
}