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
    public partial class ViewCalculatorCardiovascularRiskTotalCholesterol : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public CV_ListView ListView;

            public CalculatorCardiovascularRiskView CalculatorCardiovascularRiskView;

            public List<CalculatorCardiovascularRiskTotalCholesterol> CalculatorCardiovascularRiskTotalCholesterols;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorCardiovascularRiskTotalCholesterol()
        {
            this.InitializeComponent();

            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

            this.Title = PhcResources.CalculatorCardiovascularRiskSelectTotalCholesterol;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorCardiovascularRiskView))
            {
                this.View.CalculatorCardiovascularRiskView = (CalculatorCardiovascularRiskView) this.BindingContext;
                this.View.CalculatorCardiovascularRiskView.TotalCholesterol = null;
                this.View.CalculatorCardiovascularRiskView.HdlCholesterol = null;
                this.View.CalculatorCardiovascularRiskView.Smoker = null;
                this.View.CalculatorCardiovascularRiskView.Diabetic = null;
                this.View.CalculatorCardiovascularRiskView.BpTreatment = null;
                this.View.CalculatorCardiovascularRiskView.SystolicBp = null;

                this.View.CalculatorCardiovascularRiskTotalCholesterols = this.View.RepositoryCalculatorCardiovascularRiskTotalCholesterol.Get();

                this.View.ListView.ItemsSource = this.View.CalculatorCardiovascularRiskTotalCholesterols;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorCardiovascularRiskTotalCholesterol calculatorCardiovascularRiskTotalCholesterol = (CalculatorCardiovascularRiskTotalCholesterol) e.Item;

            this.View.CalculatorCardiovascularRiskView.TotalCholesterol = calculatorCardiovascularRiskTotalCholesterol;

            this.Navigation.PushAsync(new ViewCalculatorCardiovascularRiskHdlCholesterol()
            {
                BindingContext = this.View.CalculatorCardiovascularRiskView
            }, true);

            ((ListView) sender).SelectedItem = null;
        }
    }
}