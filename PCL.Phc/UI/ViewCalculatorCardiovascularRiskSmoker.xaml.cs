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
    public partial class ViewCalculatorCardiovascularRiskSmoker : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public CV_ListView ListView;

            public CalculatorCardiovascularRiskView CalculatorCardiovascularRiskView;

            public List<CalculatorCardiovascularRiskSmoker> CalculatorCardiovascularRiskSmokers;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorCardiovascularRiskSmoker()
        {
            this.InitializeComponent();

            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

            this.Title = PhcResources.CalculatorCardiovascularRiskSelectSmoker;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorCardiovascularRiskView))
            {
                this.View.CalculatorCardiovascularRiskView = (CalculatorCardiovascularRiskView) this.BindingContext;
                this.View.CalculatorCardiovascularRiskView.Smoker = null;
                this.View.CalculatorCardiovascularRiskView.Diabetic = null;
                this.View.CalculatorCardiovascularRiskView.BpTreatment = null;
                this.View.CalculatorCardiovascularRiskView.SystolicBp = null;

                this.View.CalculatorCardiovascularRiskSmokers = this.View.RepositoryCalculatorCardiovascularRiskSmoker.Get();

                this.View.ListView.ItemsSource = this.View.CalculatorCardiovascularRiskSmokers;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorCardiovascularRiskSmoker calculatorCardiovascularRiskSmoker = (CalculatorCardiovascularRiskSmoker) e.Item;

            this.View.CalculatorCardiovascularRiskView.Smoker = calculatorCardiovascularRiskSmoker;

            this.Navigation.PushAsync(new ViewCalculatorCardiovascularRiskDiabetic()
            {
                BindingContext = this.View.CalculatorCardiovascularRiskView
            }, true);

            ((ListView) sender).SelectedItem = null;
        }
    }
}