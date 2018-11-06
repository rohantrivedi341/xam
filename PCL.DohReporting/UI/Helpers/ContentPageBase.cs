using PCL.DohReporting.Repository;

namespace PCL.DohReporting.UI.Helpers
{
    public class ContentPageBase : PCL.UI.Helpers.ContentPageBase
    {
        public ViewModel ViewBase;

        public new class ViewModel : PCL.UI.Helpers.ContentPageBase.ViewModel
        {
            private ItemCalculatorRepository _repositoryItemCalculator;

            public ItemCalculatorRepository RepositoryItemCalculator => this._repositoryItemCalculator ?? (this._repositoryItemCalculator = new ItemCalculatorRepository(this.Page.SqLiteConnectionDatabase));
            
            public ViewModel(ContentPageBase page) : base(page)
            {
                this.Page.ViewBase = this;
            }
        }
    }
}