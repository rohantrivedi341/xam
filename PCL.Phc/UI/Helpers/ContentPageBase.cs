using PCL.Phc.Repository;

namespace PCL.Phc.UI.Helpers
{
    public class ContentPageBase : PCL.UI.Helpers.ContentPageBase
    {
        public ViewModel ViewBase;

        public new class ViewModel : PCL.UI.Helpers.ContentPageBase.ViewModel
        {
            private ItemCalculatorRepository _repositoryItemCalculator;

            public ItemCalculatorRepository RepositoryItemCalculator => this._repositoryItemCalculator ?? (this._repositoryItemCalculator = new ItemCalculatorRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorCardiovascularRiskAgeRepository _repositoryCalculatorCardiovascularRiskAge;

            public CalculatorCardiovascularRiskAgeRepository RepositoryCalculatorCardiovascularRiskAge => this._repositoryCalculatorCardiovascularRiskAge ?? (this._repositoryCalculatorCardiovascularRiskAge = new CalculatorCardiovascularRiskAgeRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorCardiovascularRiskBpTreatmentRepository _repositoryCalculatorCardiovascularRiskBpTreatment;

            public CalculatorCardiovascularRiskBpTreatmentRepository RepositoryCalculatorCardiovascularRiskBpTreatment => this._repositoryCalculatorCardiovascularRiskBpTreatment ?? (this._repositoryCalculatorCardiovascularRiskBpTreatment = new CalculatorCardiovascularRiskBpTreatmentRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorCardiovascularRiskDiabeticRepository _repositoryCalculatorCardiovascularRiskDiabetic;

            public CalculatorCardiovascularRiskDiabeticRepository RepositoryCalculatorCardiovascularRiskDiabetic => this._repositoryCalculatorCardiovascularRiskDiabetic ?? (this._repositoryCalculatorCardiovascularRiskDiabetic = new CalculatorCardiovascularRiskDiabeticRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorCardiovascularRiskHdlCholesterolRepository _repositoryCalculatorCardiovascularRiskHdlCholesterol;

            public CalculatorCardiovascularRiskHdlCholesterolRepository RepositoryCalculatorCardiovascularRiskHdlCholesterol => this._repositoryCalculatorCardiovascularRiskHdlCholesterol ?? (this._repositoryCalculatorCardiovascularRiskHdlCholesterol = new CalculatorCardiovascularRiskHdlCholesterolRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorCardiovascularRiskResultRepository _repositoryCalculatorCardiovascularRiskResult;

            public CalculatorCardiovascularRiskResultRepository RepositoryCalculatorCardiovascularRiskResult => this._repositoryCalculatorCardiovascularRiskResult ?? (this._repositoryCalculatorCardiovascularRiskResult = new CalculatorCardiovascularRiskResultRepository(this.Page.SqLiteConnectionDatabase));

            private
                CalculatorCardiovascularRiskSexRepository _repositoryCalculatorCardiovascularRiskSex;

            public CalculatorCardiovascularRiskSexRepository RepositoryCalculatorCardiovascularRiskSex => this._repositoryCalculatorCardiovascularRiskSex ?? (this._repositoryCalculatorCardiovascularRiskSex = new CalculatorCardiovascularRiskSexRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorCardiovascularRiskSmokerRepository _repositoryCalculatorCardiovascularRiskSmoker;

            public CalculatorCardiovascularRiskSmokerRepository RepositoryCalculatorCardiovascularRiskSmoker => this._repositoryCalculatorCardiovascularRiskSmoker ?? (this._repositoryCalculatorCardiovascularRiskSmoker = new CalculatorCardiovascularRiskSmokerRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorCardiovascularRiskSystolicBpRepository _repositoryCalculatorCardiovascularRiskSystolicBp;

            public CalculatorCardiovascularRiskSystolicBpRepository RepositoryCalculatorCardiovascularRiskSystolicBp => this._repositoryCalculatorCardiovascularRiskSystolicBp ?? (this._repositoryCalculatorCardiovascularRiskSystolicBp = new CalculatorCardiovascularRiskSystolicBpRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorCardiovascularRiskTotalCholesterolRepository _repositoryCalculatorCardiovascularRiskTotalCholesterol;

            public CalculatorCardiovascularRiskTotalCholesterolRepository RepositoryCalculatorCardiovascularRiskTotalCholesterol => this._repositoryCalculatorCardiovascularRiskTotalCholesterol ?? (this._repositoryCalculatorCardiovascularRiskTotalCholesterol = new CalculatorCardiovascularRiskTotalCholesterolRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorIcd10CodesBlockRepository _repositoryCalculatorIcd10CodesBlock;

            public CalculatorIcd10CodesBlockRepository RepositoryCalculatorIcd10CodesBlock => this._repositoryCalculatorIcd10CodesBlock ?? (this._repositoryCalculatorIcd10CodesBlock = new CalculatorIcd10CodesBlockRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorIcd10CodesChapterRepository _repositoryCalculatorIcd10CodesChapter;

            public CalculatorIcd10CodesChapterRepository RepositoryCalculatorIcd10CodesChapter => this._repositoryCalculatorIcd10CodesChapter ?? (this._repositoryCalculatorIcd10CodesChapter = new CalculatorIcd10CodesChapterRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorIcd10CodesCodeRepository _repositoryCalculatorIcd10CodesCode;

            public CalculatorIcd10CodesCodeRepository RepositoryCalculatorIcd10CodesCode => this._repositoryCalculatorIcd10CodesCode ?? (this._repositoryCalculatorIcd10CodesCode = new CalculatorIcd10CodesCodeRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorMedicineCostingDescriptionRepository _repositoryCalculatorMedicineCostingDescription;

            public CalculatorMedicineCostingDescriptionRepository RepositoryCalculatorMedicineCostingDescription => this._repositoryCalculatorMedicineCostingDescription ?? (this._repositoryCalculatorMedicineCostingDescription = new CalculatorMedicineCostingDescriptionRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorMedicineCostingGenericRepository _repositoryCalculatorMedicineCostingGeneric;

            public CalculatorMedicineCostingGenericRepository RepositoryCalculatorMedicineCostingGeneric => this._repositoryCalculatorMedicineCostingGeneric ?? (this._repositoryCalculatorMedicineCostingGeneric = new CalculatorMedicineCostingGenericRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorPaediatricDosageAgeWeightGroupRepository _repositoryCalculatorPaediatricDosageAgeWeightGroup;

            public CalculatorPaediatricDosageAgeWeightGroupRepository RepositoryCalculatorPaediatricDosageAgeWeightGroup => this._repositoryCalculatorPaediatricDosageAgeWeightGroup ?? (this._repositoryCalculatorPaediatricDosageAgeWeightGroup = new CalculatorPaediatricDosageAgeWeightGroupRepository(this.Page.SqLiteConnectionDatabase));

            private CalculatorPaediatricDosageDrugRepository _repositoryCalculatorPaediatricDosageDrug;

            public CalculatorPaediatricDosageDrugRepository RepositoryCalculatorPaediatricDosageDrug => this._repositoryCalculatorPaediatricDosageDrug ?? (this._repositoryCalculatorPaediatricDosageDrug = new CalculatorPaediatricDosageDrugRepository(this.Page.SqLiteConnectionDatabase));

            public ViewModel(ContentPageBase page) : base(page)
            {
                this.Page.ViewBase = this;
            }
        }
    }
}