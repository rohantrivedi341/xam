using System;
using PCL.Tb.Common.View;
using PCL.UI.Helpers;
using PCL.UI.Templates;
using PCL.UI.Templates.Views;
using Xamarin.Forms;
using ContentPageBase = PCL.Tb.UI.Helpers.ContentPageBase;

namespace PCL.Tb.UI
{
    public partial class ViewCalculatorBmi : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public StackLayout StackLayout;

            public TemplateColumn2 RowMass;
            public TemplateColumn2 RowLength;
            public TemplateColumn1 ButtonNextRow;

            public CalculatorBmiView CalculatorBmiView;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorBmi()
        {
            this.InitializeComponent();

            this.View.StackLayout = this.stackLayout;

            this.Title = TbResources.CalculatorBmi;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof(CalculatorBmiView))
            {
                this.View.CalculatorBmiView = (CalculatorBmiView)this.BindingContext;
                this.View.CalculatorBmiView.Mass = 0;
                this.View.CalculatorBmiView.Length = 0;
                this.View.CalculatorBmiView.Result = 0;
                this.View.CalculatorBmiView.Bmi = null;
                
                this.View.RowMass = TemplateColumn2.Create(new LabelView(TbResources.CalculatorBmiMass).Bold(), new EntryView(String.Empty, Keyboard.Numeric, TbResources.CalculatorBmiMassUnit), 0.6, 0.4);
                this.View.StackLayout.Children.Add(this.View.RowMass);

                this.View.RowLength = TemplateColumn2.Create(new LabelView(TbResources.CalculatorBmiLength).Bold(), new EntryView(String.Empty, Keyboard.Numeric, TbResources.CalculatorBmiLengthUnit), 0.6, 0.4);
                this.View.StackLayout.Children.Add(this.View.RowLength);

                this.View.ButtonNextRow = TemplateColumn1.Create(new ButtonView(PCLResources.Next, this.OnButtonNextClicked));
                this.View.StackLayout.Children.Add(this.View.ButtonNextRow);
            }
        }

        private void OnButtonNextClicked(object sender, EventArgs e)
        {
            String mass = ((EntryView)this.View.RowMass.Second).Text;
            String length = ((EntryView)this.View.RowLength.Second).Text;

            Double massResult;

            if (!Double.TryParse(mass.Replace(",", "."), out massResult))
            {
                this.DisplayAlert(TbResources.CalculatorBmiMass, TbResources.CalculatorBmiMassValidationParsing, PCLResources.OK);
                
                return;
            }
            
            this.View.CalculatorBmiView.Mass = Math.Round(massResult, 1);
            
            Double lengthResult;

            if (!Double.TryParse(length.Replace(",", "."), out lengthResult))
            { 
                this.DisplayAlert(TbResources.CalculatorBmiMass, TbResources.CalculatorBmiLengthValidationParsing, PCLResources.OK);

                return;
            }

            this.View.CalculatorBmiView.Length = Math.Round(lengthResult / 100.0, 1);
            
            this.View.CalculatorBmiView.Result = Math.Round(this.View.CalculatorBmiView.Mass / (this.View.CalculatorBmiView.Length * this.View.CalculatorBmiView.Length), 1);
            
            this.Navigation.PushAsync(new ViewCalculatorBmiResult()
            {
                BindingContext = this.View.CalculatorBmiView
            }, true);
        }
    }
}