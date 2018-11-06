using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Hiv.Common;
using PCL.Hiv.Common.View;
using PCL.UI.CustomViews;
using PCL.UI.Helpers;
using PCL.UI.Templates.Cells;
using Xamarin.Forms;
using ContentPageBase = PCL.Hiv.UI.Helpers.ContentPageBase;

namespace PCL.Hiv.UI
{
    public partial class ViewCalculatorDrugInteractionArv : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public SearchBar SearchBar;
            public CV_ListView ListView;

            public CalculatorDrugInteractionView CalculatorDrugInteractionView;

            public List<CalculatorDrugInteractionArv> CalculatorDrugInteractionArvs;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorDrugInteractionArv()
        {
            this.InitializeComponent();

            this.View.SearchBar = this.searchBar;
            this.View.SearchBar.BackgroundColor = Color.FromHex("#adadad");
            this.View.SearchBar.TextChanged += this.OnSearchQueryChanged;

            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

            this.Title = HivResources.CalculatorDrugInteractionSelectArv;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorDrugInteractionView))
            {
                this.View.CalculatorDrugInteractionView = (CalculatorDrugInteractionView) this.BindingContext;
                this.View.CalculatorDrugInteractionView.Arv = null;
                this.View.CalculatorDrugInteractionView.Interaction = null;

                this.View.CalculatorDrugInteractionArvs = this.View.RepositoryCalculatorDrugInteractionArv.Get();

                this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

                this.View.ListView.ItemsSource = this.View.CalculatorDrugInteractionArvs;
            }
        }

        private void OnSearchQueryChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(e.NewTextValue))
            {
                this.View.ListView.ItemsSource = this.View.CalculatorDrugInteractionArvs;

                return;
            }

            this.View.ListView.ItemsSource = this.View.CalculatorDrugInteractionArvs.Where(x => x.Title.ToLower().StartsWith(e.NewTextValue.ToLower().Trim()));
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorDrugInteractionArv calculatorDrugInteractionArv = (CalculatorDrugInteractionArv) e.Item;

            this.View.CalculatorDrugInteractionView.Arv = calculatorDrugInteractionArv;

            this.Navigation.PushAsync(new ViewCalculatorDrugInteractionInteraction
            {
                BindingContext = this.View.CalculatorDrugInteractionView
            }, true);

            ((ListView) sender).SelectedItem = null;
        }
    }
}