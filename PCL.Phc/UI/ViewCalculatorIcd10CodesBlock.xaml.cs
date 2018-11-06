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
    public partial class ViewCalculatorIcd10CodesBlock : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public CV_ListView ListView;

            public CalculatorIcd10View CalculatorIcd10View;

            public List<CalculatorIcd10CodesBlock> CalculatorWhoDiseasesBlocks;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorIcd10CodesBlock()
        {
            this.InitializeComponent();

            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

            this.Title = PhcResources.CalculatorIcd10CodesSelectBlock;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorIcd10View))
            {
                this.View.CalculatorIcd10View = (CalculatorIcd10View) this.BindingContext;
                this.View.CalculatorIcd10View.Block = null;
                this.View.CalculatorIcd10View.Code = null;

                this.View.CalculatorWhoDiseasesBlocks = this.View.RepositoryCalculatorIcd10CodesBlock.Get(this.View.CalculatorIcd10View.Chapter.Number);

                this.View.ListView.ItemsSource = this.View.CalculatorWhoDiseasesBlocks;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorIcd10CodesBlock calculatorWhoDiseasesBlock = (CalculatorIcd10CodesBlock) e.Item;

            this.View.CalculatorIcd10View.Block = calculatorWhoDiseasesBlock;

            this.Navigation.PushAsync(new ViewCalculatorIcd10CodesCode()
            {
                BindingContext = this.View.CalculatorIcd10View
            }, true);

            ((ListView) sender).SelectedItem = null;
        }
    }
}