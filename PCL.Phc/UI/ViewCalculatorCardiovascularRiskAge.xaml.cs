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
    public partial class ViewCalculatorCardiovascularRiskAge : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public CV_ListView ListView;

            public CalculatorCardiovascularRiskView CalculatorCardiovascularRiskView;

            public List<CalculatorCardiovascularRiskAge> CalculatorCardiovascularRiskAges;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorCardiovascularRiskAge()
        {
            this.InitializeComponent();

            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

            this.Title = PhcResources.CalculatorCardiovascularRiskSelectAge;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorCardiovascularRiskView))
            {
                this.View.CalculatorCardiovascularRiskView = (CalculatorCardiovascularRiskView) this.BindingContext;
                this.View.CalculatorCardiovascularRiskView.Age = null;
                this.View.CalculatorCardiovascularRiskView.TotalCholesterol = null;
                this.View.CalculatorCardiovascularRiskView.HdlCholesterol = null;
                this.View.CalculatorCardiovascularRiskView.Smoker = null;
                this.View.CalculatorCardiovascularRiskView.Diabetic = null;
                this.View.CalculatorCardiovascularRiskView.BpTreatment = null;
                this.View.CalculatorCardiovascularRiskView.SystolicBp = null;

                this.View.CalculatorCardiovascularRiskAges = this.View.RepositoryCalculatorCardiovascularRiskAge.Get();

                this.View.ListView.ItemsSource = this.View.CalculatorCardiovascularRiskAges;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorCardiovascularRiskAge calculatorCardiovascularRiskAge = (CalculatorCardiovascularRiskAge) e.Item;

            this.View.CalculatorCardiovascularRiskView.Age = calculatorCardiovascularRiskAge;

            this.Navigation.PushAsync(new ViewCalculatorCardiovascularRiskTotalCholesterol()
            {
                BindingContext = this.View.CalculatorCardiovascularRiskView
            }, true);

            ((ListView) sender).SelectedItem = null;
        }
    }
}