using PCL.Tb.Repository;

namespace PCL.Tb.UI.Helpers
{
    public class ContentPageBase : PCL.UI.Helpers.ContentPageBase
    {
        public ViewModel ViewBase;

        public new class ViewModel : PCL.UI.Helpers.ContentPageBase.ViewModel
        {
            private ItemCalculatorRepository _repositoryItemCalculator;

            public ItemCalculatorRepository RepositoryItemCalculator => this._repositoryItemCalculator ?? (this._repositoryItemCalculator = new ItemCalculatorRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorAdultDsTbDosageDrugRepository _repositoryCalculatorAdultDsTbDosageDrug;

            public CalculatorAdultDsTbDosageDrugRepository RepositoryCalculatorAdultDsTbDosageDrug => this._repositoryCalculatorAdultDsTbDosageDrug ?? (this._repositoryCalculatorAdultDsTbDosageDrug = new CalculatorAdultDsTbDosageDrugRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorAdultDsTbDosagePhaseRepository _repositoryCalculatorAdultDsTbDosagePhase;
            
            public CalculatorAdultDsTbDosagePhaseRepository RepositoryCalculatorAdultDsTbDosagePhase => this._repositoryCalculatorAdultDsTbDosagePhase ?? (this._repositoryCalculatorAdultDsTbDosagePhase = new CalculatorAdultDsTbDosagePhaseRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorAdultDsTbDosageWeightGroupRepository _repositoryCalculatorAdultDsTbDosageWeightGroup;

            public CalculatorAdultDsTbDosageWeightGroupRepository RepositoryCalculatorAdultDsTbDosageWeightGroup => this._repositoryCalculatorAdultDsTbDosageWeightGroup ?? (this._repositoryCalculatorAdultDsTbDosageWeightGroup = new CalculatorAdultDsTbDosageWeightGroupRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorAdultIsoniazidePreventiveTherapyRepository _repositoryCalculatorAdultIsoniazidePreventiveTherapy;

            public CalculatorAdultIsoniazidePreventiveTherapyRepository RepositoryCalculatorAdultIsoniazidePreventiveTherapy => this._repositoryCalculatorAdultIsoniazidePreventiveTherapy ?? (this._repositoryCalculatorAdultIsoniazidePreventiveTherapy = new CalculatorAdultIsoniazidePreventiveTherapyRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorAdultIsoniazidePreventiveTherapySizeRepository _repositoryCalculatorAdultIsoniazidePreventiveTherapySize;

            public CalculatorAdultIsoniazidePreventiveTherapySizeRepository RepositoryCalculatorAdultIsoniazidePreventiveTherapySize => this._repositoryCalculatorAdultIsoniazidePreventiveTherapySize ?? (this._repositoryCalculatorAdultIsoniazidePreventiveTherapySize = new CalculatorAdultIsoniazidePreventiveTherapySizeRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorPaediatricIsoniazidePreventiveTherapyRepository _repositoryCalculatorPaediatricIsoniazidePreventiveTherapy;

            public CalculatorPaediatricIsoniazidePreventiveTherapyRepository RepositoryCalculatorPaediatricIsoniazidePreventiveTherapy => this._repositoryCalculatorPaediatricIsoniazidePreventiveTherapy ?? (this._repositoryCalculatorPaediatricIsoniazidePreventiveTherapy = new CalculatorPaediatricIsoniazidePreventiveTherapyRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroupRepository _repositoryCalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup;

            public CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroupRepository RepositoryCalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup => this._repositoryCalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup ?? (this._repositoryCalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup = new CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroupRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorPaediatricDsTbDosageCategoryRepository _repositoryCalculatorPaediatricDsTbDosageCategory;

            public CalculatorPaediatricDsTbDosageCategoryRepository RepositoryCalculatorPaediatricDsTbDosageCategory => this._repositoryCalculatorPaediatricDsTbDosageCategory ?? (this._repositoryCalculatorPaediatricDsTbDosageCategory = new CalculatorPaediatricDsTbDosageCategoryRepository(this.Page.SqLiteConnectionDatabase));
            
            private CalculatorPaediatricDsTbDosagePhaseRepository _repositoryCalculatorPaediatricDsTbDosagePhase;
            
            public CalculatorPaediatricDsTbDosagePhaseRepository RepositoryCalculatorPaediatricDsTbDosagePhase => this._repositoryCalculatorPaediatricDsTbDosagePhase ?? (this._repositoryCalculatorPaediatricDsTbDosagePhase = new CalculatorPaediatricDsTbDosagePhaseRepository(this.Page.SqLiteConnectionDatabase));
            
            private CalculatorPaediatricDsTbDosageWeightGroupRepository _repositoryCalculatorPaediatricDsTbDosageWeightGroup;
            
            public CalculatorPaediatricDsTbDosageWeightGroupRepository RepositoryCalculatorPaediatricDsTbDosageWeightGroup => this._repositoryCalculatorPaediatricDsTbDosageWeightGroup ?? (this._repositoryCalculatorPaediatricDsTbDosageWeightGroup = new CalculatorPaediatricDsTbDosageWeightGroupRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorBmiRepository _repositoryCalculatorBmi;

            public CalculatorBmiRepository RepositoryCalculatorBmi => this._repositoryCalculatorBmi ?? (this._repositoryCalculatorBmi = new CalculatorBmiRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorTbTreatmentFollowUpDateRepository _repositoryCalculatorTbTreatmentFollowUpDate;
            
            public CalculatorTbTreatmentFollowUpDateRepository RepositoryCalculatorTbTreatmentFollowUpDate => this._repositoryCalculatorTbTreatmentFollowUpDate ?? (this._repositoryCalculatorTbTreatmentFollowUpDate = new CalculatorTbTreatmentFollowUpDateRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorMdrTreatmentFollowUpDateRepository _repositoryCalculatorMdrTreatmentFollowUpDate;

            public CalculatorMdrTreatmentFollowUpDateRepository RepositoryCalculatorMdrTreatmentFollowUpDate => this._repositoryCalculatorMdrTreatmentFollowUpDate ?? (this._repositoryCalculatorMdrTreatmentFollowUpDate = new CalculatorMdrTreatmentFollowUpDateRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorDrugInteractionArvRepository _repositoryCalculatorDrugInteractionArv;

            public CalculatorDrugInteractionArvRepository RepositoryCalculatorDrugInteractionArv => this._repositoryCalculatorDrugInteractionArv ?? (this._repositoryCalculatorDrugInteractionArv = new CalculatorDrugInteractionArvRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorDrugInteractionEdlRepository _repositoryCalculatorDrugInteractionEdl;

            public CalculatorDrugInteractionEdlRepository RepositoryCalculatorDrugInteractionEdl => this._repositoryCalculatorDrugInteractionEdl ?? (this._repositoryCalculatorDrugInteractionEdl = new CalculatorDrugInteractionEdlRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorDrugInteractionInteractionRepository _repositoryCalculatorDrugInteractionInteraction;

            public CalculatorDrugInteractionInteractionRepository RepositoryCalculatorDrugInteractionInteraction => this._repositoryCalculatorDrugInteractionInteraction ?? (this._repositoryCalculatorDrugInteractionInteraction = new CalculatorDrugInteractionInteractionRepository(this.Page.SqLiteConnectionDatabase));

            public ViewModel(ContentPageBase page) : base(page)
            {
                this.Page.ViewBase = this;
            }
        }
    }
}