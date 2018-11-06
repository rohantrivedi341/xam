using System;
using PCL.Database;
using PCL.DependencyServices;
using PCL.Phc.Common;
using PCL.Phc.DependencyServices;
using PCL.Repository;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyApplicationPhcDatabase))]

namespace PCL.Phc.DependencyServices
{
    public class DependencyApplicationPhcDatabase : IDependencyApplicationDatabase
    {
        public void Create(SQLiteConnectionDatabase sqLiteConnectionDatabase)
        {
            sqLiteConnectionDatabase.CreateTable<ItemCalculator>();

            sqLiteConnectionDatabase.CreateTable<CalculatorPaediatricDosageDrug>();
            sqLiteConnectionDatabase.CreateTable<CalculatorPaediatricDosageAgeWeightGroup>();
            sqLiteConnectionDatabase.CreateTable<CalculatorMedicineCostingGeneric>();
            sqLiteConnectionDatabase.CreateTable<CalculatorMedicineCostingDescription>();
            sqLiteConnectionDatabase.CreateTable<CalculatorIcd10CodesChapter>();
            sqLiteConnectionDatabase.CreateTable<CalculatorIcd10CodesBlock>();
            sqLiteConnectionDatabase.CreateTable<CalculatorIcd10CodesCode>();
            sqLiteConnectionDatabase.CreateTable<CalculatorCardiovascularRiskAge>();
            sqLiteConnectionDatabase.CreateTable<CalculatorCardiovascularRiskDiabetic>();
            sqLiteConnectionDatabase.CreateTable<CalculatorCardiovascularRiskTotalCholesterol>();
            sqLiteConnectionDatabase.CreateTable<CalculatorCardiovascularRiskHdlCholesterol>();
            sqLiteConnectionDatabase.CreateTable<CalculatorCardiovascularRiskResult>();
            sqLiteConnectionDatabase.CreateTable<CalculatorCardiovascularRiskSex>();
            sqLiteConnectionDatabase.CreateTable<CalculatorCardiovascularRiskSmoker>();
            sqLiteConnectionDatabase.CreateTable<CalculatorCardiovascularRiskBpTreatment>();
            sqLiteConnectionDatabase.CreateTable<CalculatorCardiovascularRiskSystolicBp>();
        }
        
        public void Drop(SQLiteConnectionDatabase sqLiteConnectionDatabase)
        {
            sqLiteConnectionDatabase.DropTable<ItemCalculator>();

            sqLiteConnectionDatabase.DropTable<CalculatorPaediatricDosageDrug>();
            sqLiteConnectionDatabase.DropTable<CalculatorPaediatricDosageAgeWeightGroup>();
            sqLiteConnectionDatabase.DropTable<CalculatorMedicineCostingGeneric>();
            sqLiteConnectionDatabase.DropTable<CalculatorMedicineCostingDescription>();
            sqLiteConnectionDatabase.DropTable<CalculatorIcd10CodesChapter>();
            sqLiteConnectionDatabase.DropTable<CalculatorIcd10CodesBlock>();
            sqLiteConnectionDatabase.DropTable<CalculatorIcd10CodesCode>();
            sqLiteConnectionDatabase.DropTable<CalculatorCardiovascularRiskAge>();
            sqLiteConnectionDatabase.DropTable<CalculatorCardiovascularRiskDiabetic>();
            sqLiteConnectionDatabase.DropTable<CalculatorCardiovascularRiskTotalCholesterol>();
            sqLiteConnectionDatabase.DropTable<CalculatorCardiovascularRiskHdlCholesterol>();
            sqLiteConnectionDatabase.DropTable<CalculatorCardiovascularRiskResult>();
            sqLiteConnectionDatabase.DropTable<CalculatorCardiovascularRiskSex>();
            sqLiteConnectionDatabase.DropTable<CalculatorCardiovascularRiskSmoker>();
            sqLiteConnectionDatabase.DropTable<CalculatorCardiovascularRiskBpTreatment>();
            sqLiteConnectionDatabase.DropTable<CalculatorCardiovascularRiskSystolicBp>();
        }
    }
}