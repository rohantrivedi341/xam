using System.Collections.Generic;
using PCL.Hiv.Common;
using PCL.Hiv.Common.View;
using PCL.UI.CustomViews;
using PCL.UI.Helpers;
using PCL.UI.Templates.Cells;
using Xamarin.Forms;
using ContentPageBase = PCL.Hiv.UI.Helpers.ContentPageBase;

namespace PCL.Hiv.UI
{
    public partial class ViewCalculatorAdverseReactionPathologySex : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public CV_ListView ListView;

            public CalculatorAdverseReactionPathologyView CalculatorAdverseReactionPathologyView;

            public List<CalculatorAdverseReactionPathologySex> CalculatorAdverseReactionPathologySexes;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorAdverseReactionPathologySex()
        {
            this.InitializeComponent();

            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

            this.Title = HivResources.CalculatorAdverseReactionPathologySelectSex;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorAdverseReactionPathologyView))
            {
                this.View.CalculatorAdverseReactionPathologyView = (CalculatorAdverseReactionPathologyView) this.BindingContext;
                this.View.CalculatorAdverseReactionPathologyView.Sex = null;
                this.View.CalculatorAdverseReactionPathologyView.Results = null;

                this.View.CalculatorAdverseReactionPathologySexes = this.View.RepositoryCalculatorAdverseReactionPathologySex.Get();

                this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

                this.View.ListView.ItemsSource = this.View.CalculatorAdverseReactionPathologySexes;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorAdverseReactionPathologySex calculatorAdverseReactionPathologySex = (CalculatorAdverseReactionPathologySex) e.Item;

            this.View.CalculatorAdverseReactionPathologyView.Sex = calculatorAdverseReactionPathologySex;

            this.Navigation.PushAsync(new ViewCalculatorAdverseReactionPathologyTestResults()
            {
                BindingContext = this.View.CalculatorAdverseReactionPathologyView
            }, true);

            ((ListView) sender).SelectedItem = null;
        }
    }
}