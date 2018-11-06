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
    public partial class ViewCalculatorCardiovascularRiskSystolicBp : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public CV_ListView ListView;

            public CalculatorCardiovascularRiskView CalculatorCardiovascularRiskView;

            public List<CalculatorCardiovascularRiskSystolicBp> CalculatorCardiovascularRiskSystolicBps;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorCardiovascularRiskSystolicBp()
        {
            this.InitializeComponent();

            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

            this.Title = PhcResources.CalculatorCardiovascularRiskSelectSystolicBp;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorCardiovascularRiskView))
            {
                this.View.CalculatorCardiovascularRiskView = (CalculatorCardiovascularRiskView) this.BindingContext;
                this.View.CalculatorCardiovascularRiskView.SystolicBp = null;

                this.View.CalculatorCardiovascularRiskSystolicBps = this.View.RepositoryCalculatorCardiovascularRiskSystolicBp.Get(this.View.CalculatorCardiovascularRiskView.BpTreatment.Treatment);

                this.View.ListView.ItemsSource = this.View.CalculatorCardiovascularRiskSystolicBps;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorCardiovascularRiskSystolicBp calculatorCardiovascularRiskSystolicBp = (CalculatorCardiovascularRiskSystolicBp) e.Item;

            this.View.CalculatorCardiovascularRiskView.SystolicBp = calculatorCardiovascularRiskSystolicBp;

            this.Navigation.PushAsync(new ViewCalculatorCardiovascularRiskResult()
            {
                BindingContext = this.View.CalculatorCardiovascularRiskView
            }, true);

            ((ListView) sender).SelectedItem = null;
        }
    }
}