﻿using System;
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
    public partial class ViewCalculatorAdultDsTbDosagePhase : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public CV_ListView ListView;

            public CalculatorAdultDsTbDosageView CalculatorAdultDsTbDosageView;

            public List<CalculatorAdultDsTbDosagePhase> CalculatorPaediatricDsTbDosagePhases;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorAdultDsTbDosagePhase()
        {
            this.InitializeComponent();

            this.View.ListView = this.listView;
            this.View.ListView.ItemTapped += this.OnItemTapped;
            this.View.ListView.ItemTemplate = new DataTemplate(typeof(TextDefaultCell));

            this.Title = TbResources.CalculatorAdultDsTbDosageSelectPhase;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof(CalculatorAdultDsTbDosageView))
            {
                this.View.CalculatorAdultDsTbDosageView = (CalculatorAdultDsTbDosageView)this.BindingContext;
                this.View.CalculatorAdultDsTbDosageView.Phase = null;
                this.View.CalculatorAdultDsTbDosageView.Drug = null;
                this.View.CalculatorAdultDsTbDosageView.WeightGroup = null;

                this.View.CalculatorPaediatricDsTbDosagePhases = this.View.RepositoryCalculatorAdultDsTbDosagePhase.Get();

                this.View.ListView.ItemTemplate = new DataTemplate(typeof(TextDefaultCell));

                this.View.ListView.ItemsSource = this.View.CalculatorPaediatricDsTbDosagePhases;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            CalculatorAdultDsTbDosagePhase calculatorAdultDsTbDosagePhase = (CalculatorAdultDsTbDosagePhase)e.Item;

            this.View.CalculatorAdultDsTbDosageView.Phase = calculatorAdultDsTbDosagePhase;

            List<CalculatorAdultDsTbDosageDrug> calculatorAdultDsTbDosageDrugs = this.View.RepositoryCalculatorAdultDsTbDosageDrug.GetByCalculatorAdultDsTbPhase(this.View.CalculatorAdultDsTbDosageView.Phase.Id);

            if (calculatorAdultDsTbDosageDrugs.Count > 1)
            {
                this.Navigation.PushAsync(new ViewCalculatorAdultDsTbDosageDrug()
                {
                    BindingContext = this.View.CalculatorAdultDsTbDosageView
                }, true);
            }
            else
            {
                this.View.CalculatorAdultDsTbDosageView.Drug = calculatorAdultDsTbDosageDrugs.First();
                
                this.Navigation.PushAsync(new ViewCalculatorAdultDsTbDosageWeightGroup()
                {
                    BindingContext = this.View.CalculatorAdultDsTbDosageView
                }, true);
            }

            ((ListView)sender).SelectedItem = null;
        }
    }
}