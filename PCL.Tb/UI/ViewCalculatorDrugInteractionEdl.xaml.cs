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
    public partial class ViewCalculatorDrugInteractionEdl : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public SearchBar SearchBar;
            public CV_ListView ListView;

            public CalculatorDrugInteractionView CalculatorDrugInteractionView;

            public List<CalculatorDrugInteractionEdl> CalculatorDrugInteractionEdls;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorDrugInteractionEdl()
        {
            this.InitializeComponent();

            this.View.SearchBar = this.searchBar;
            this.View.SearchBar.BackgroundColor = Color.FromHex("#adadad");
            this.View.SearchBar.TextChanged += this.OnSearchQueryChanged;

            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

            this.Title = TbResources.CalculatorDrugInteractionSelectEdl;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorDrugInteractionView))
            {
                this.View.CalculatorDrugInteractionView = (CalculatorDrugInteractionView) this.BindingContext;
                this.View.CalculatorDrugInteractionView.Edl = null;
                this.View.CalculatorDrugInteractionView.Arv = null;
                this.View.CalculatorDrugInteractionView.Interaction = null;

                this.View.CalculatorDrugInteractionEdls = this.View.RepositoryCalculatorDrugInteractionEdl.Get();

                this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

                this.View.ListView.ItemsSource = this.View.CalculatorDrugInteractionEdls;
            }
        }

        private void OnSearchQueryChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(e.NewTextValue))
            {
                this.View.ListView.ItemsSource = this.View.CalculatorDrugInteractionEdls;

                return;
            }

            this.View.ListView.ItemsSource = this.View.CalculatorDrugInteractionEdls.Where(x => x.Title.ToLower().StartsWith(e.NewTextValue.ToLower().Trim()));
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorDrugInteractionEdl calculatorDrugInteractionEdl = (CalculatorDrugInteractionEdl) e.Item;

            this.View.CalculatorDrugInteractionView.Edl = calculatorDrugInteractionEdl;

            this.Navigation.PushAsync(new ViewCalculatorDrugInteractionArv
            {
                BindingContext = this.View.CalculatorDrugInteractionView
            }, true);

            ((ListView) sender).SelectedItem = null;
        }
    }
}