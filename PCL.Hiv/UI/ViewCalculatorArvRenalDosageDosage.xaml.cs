using System;
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
    public partial class ViewCalculatorArvRenalDosageDosage : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public Button ButtonCalculateCreatinineClearance;
            public CV_ListView ListView;

            public CalculatorArvRenalDosageView CalculatorArvRenalDosageView;

            public List<CalculatorArvRenalDosageDosage> CalculatorArvRenalDosageDosages;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorArvRenalDosageDosage()
        {
            this.InitializeComponent();

            this.View.ButtonCalculateCreatinineClearance = this.buttonCalculateCreatinineClearance;
            this.View.ButtonCalculateCreatinineClearance.Text = HivResources.CalculatorArvRenalDosageCalculateCreatinineClearance;
            this.View.ButtonCalculateCreatinineClearance.Clicked += this.OnButtonCalculateCreatinineClearanceClicked;

            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

            this.Title = HivResources.CalculatorArvRenalDosageSelectDosage;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorArvRenalDosageView))
            {
                this.View.CalculatorArvRenalDosageView = (CalculatorArvRenalDosageView) this.BindingContext;
                this.View.CalculatorArvRenalDosageView.Dosage = null;
                this.View.CalculatorArvRenalDosageView.DosageItem = null;
                this.View.CalculatorArvRenalDosageView.CreatinineClearance = null;

                this.View.CalculatorArvRenalDosageDosages = this.View.RepositoryCalculatorArvRenalDosageDosage.GetByCalculatorArvRenalDosageArv(this.View.CalculatorArvRenalDosageView.Arv.Id);

                this.View.ListView.ItemTemplate = new DataTemplate(typeof (TextDefaultCell));

                this.View.ListView.ItemsSource = this.View.CalculatorArvRenalDosageDosages;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorArvRenalDosageDosage calculatorArvRenalDosageDosage = (CalculatorArvRenalDosageDosage) e.Item;

            this.View.CalculatorArvRenalDosageView.Dosage = calculatorArvRenalDosageDosage;

            this.Navigation.PushAsync(new ViewCalculatorArvRenalDosageResult
            {
                BindingContext = this.View.CalculatorArvRenalDosageView
            }, true);

            ((ListView) sender).SelectedItem = null;
        }

        private void OnButtonCalculateCreatinineClearanceClicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new ViewCalculatorArvRenalDosageCreatinineClearance
            {
                BindingContext = this.View.CalculatorArvRenalDosageView
            }, true);
        }
    }
}