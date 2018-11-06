using PCL.Hiv.Repository;

namespace PCL.Hiv.UI.Helpers
{
    public class ContentPageBase : PCL.UI.Helpers.ContentPageBase
    {
        public ViewModel ViewBase;

        public new class ViewModel : PCL.UI.Helpers.ContentPageBase.ViewModel
        {
            private ItemCalculatorRepository _repositoryItemCalculator;

            public ItemCalculatorRepository RepositoryItemCalculator => this._repositoryItemCalculator ?? (this._repositoryItemCalculator = new ItemCalculatorRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorAdverseReactionPathologyAgeCategoryRepository _repositoryCalculatorAdverseReactionPathologyAgeCategory;

            public CalculatorAdverseReactionPathologyAgeCategoryRepository RepositoryCalculatorAdverseReactionPathologyAgeCategory => this._repositoryCalculatorAdverseReactionPathologyAgeCategory ?? (this._repositoryCalculatorAdverseReactionPathologyAgeCategory = new CalculatorAdverseReactionPathologyAgeCategoryRepository(this.Page.SqLiteConnectionDatabase));
            
            private CalculatorAdverseReactionPathologyParameterRepository _repositoryCalculatorAdverseReactionPathologyParameter;

            public CalculatorAdverseReactionPathologyParameterRepository RepositoryCalculatorAdverseReactionPathologyParameter => this._repositoryCalculatorAdverseReactionPathologyParameter ?? (this._repositoryCalculatorAdverseReactionPathologyParameter = new CalculatorAdverseReactionPathologyParameterRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorAdverseReactionPathologySexRepository _repositoryCalculatorAdverseReactionPathologySex;

            public CalculatorAdverseReactionPathologySexRepository RepositoryCalculatorAdverseReactionPathologySex => this._repositoryCalculatorAdverseReactionPathologySex ?? (this._repositoryCalculatorAdverseReactionPathologySex = new CalculatorAdverseReactionPathologySexRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorArvRenalDosageArvRepository _repositoryCalculatorArvRenalDosageArv;

            public CalculatorArvRenalDosageArvRepository RepositoryCalculatorArvRenalDosageArv => this._repositoryCalculatorArvRenalDosageArv ?? (this._repositoryCalculatorArvRenalDosageArv = new CalculatorArvRenalDosageArvRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorArvRenalDosageDosageItemRepository _repositoryCalculatorArvRenalDosageDosageItem;

            public CalculatorArvRenalDosageDosageItemRepository RepositoryCalculatorArvRenalDosageDosageItem => this._repositoryCalculatorArvRenalDosageDosageItem ?? (this._repositoryCalculatorArvRenalDosageDosageItem = new CalculatorArvRenalDosageDosageItemRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorArvRenalDosageDosageRepository _repositoryCalculatorArvRenalDosageDosage;

            public CalculatorArvRenalDosageDosageRepository RepositoryCalculatorArvRenalDosageDosage => this._repositoryCalculatorArvRenalDosageDosage ?? (this._repositoryCalculatorArvRenalDosageDosage = new CalculatorArvRenalDosageDosageRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorDrugInteractionArvRepository _repositoryCalculatorDrugInteractionArv;

            public CalculatorDrugInteractionArvRepository RepositoryCalculatorDrugInteractionArv => this._repositoryCalculatorDrugInteractionArv ?? (this._repositoryCalculatorDrugInteractionArv = new CalculatorDrugInteractionArvRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorDrugInteractionEdlRepository _repositoryCalculatorDrugInteractionEdl;

            public CalculatorDrugInteractionEdlRepository RepositoryCalculatorDrugInteractionEdl => this._repositoryCalculatorDrugInteractionEdl ?? (this._repositoryCalculatorDrugInteractionEdl = new CalculatorDrugInteractionEdlRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorDrugInteractionInteractionRepository _repositoryCalculatorDrugInteractionInteraction;

            public CalculatorDrugInteractionInteractionRepository RepositoryCalculatorDrugInteractionInteraction => this._repositoryCalculatorDrugInteractionInteraction ?? (this._repositoryCalculatorDrugInteractionInteraction = new CalculatorDrugInteractionInteractionRepository(this.Page.SqLiteConnectionDatabase));
            
            private CalculatorPaediatricArvDosageArvRepository _repositoryCalculatorPaediatricArvDosageArv;

            public CalculatorPaediatricArvDosageArvRepository RepositoryCalculatorPaediatricArvDosageArv => this._repositoryCalculatorPaediatricArvDosageArv ?? (this._repositoryCalculatorPaediatricArvDosageArv = new CalculatorPaediatricArvDosageArvRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorPaediatricArvDosageWeightGroupRepository _repositoryCalculatorPaediatricArvDosageWeightGroup;

            public CalculatorPaediatricArvDosageWeightGroupRepository RepositoryCalculatorPaediatricArvDosageWeightGroup => this._repositoryCalculatorPaediatricArvDosageWeightGroup ?? (this._repositoryCalculatorPaediatricArvDosageWeightGroup = new CalculatorPaediatricArvDosageWeightGroupRepository(this.Page.SqLiteConnectionDatabase));

            public ViewModel(ContentPageBase page) : base(page)
            {
                this.Page.ViewBase = this;
            }
        }
    }
}