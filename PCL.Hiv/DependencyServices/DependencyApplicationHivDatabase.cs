using PCL.Database;
using PCL.DependencyServices;
using PCL.Hiv.Common;
using PCL.Hiv.DependencyServices;
using PCL.Repository;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyApplicationHivDatabase))]

namespace PCL.Hiv.DependencyServices
{
    public class DependencyApplicationHivDatabase : IDependencyApplicationDatabase
    {
        public void Create(SQLiteConnectionDatabase sqLiteConnectionDatabase)
        {
            sqLiteConnectionDatabase.CreateTable<ItemCalculator>();
            
            sqLiteConnectionDatabase.CreateTable<CalculatorPaediatricArvDosageArv>();
            sqLiteConnectionDatabase.CreateTable<CalculatorPaediatricArvDosageWeightGroup>();
            sqLiteConnectionDatabase.CreateTable<CalculatorAdverseReactionPathologyParameter>();
            sqLiteConnectionDatabase.CreateTable<CalculatorAdverseReactionPathologyAgeCategory>();
            sqLiteConnectionDatabase.CreateTable<CalculatorAdverseReactionPathologySex>();
            sqLiteConnectionDatabase.CreateTable<CalculatorArvRenalDosageArv>();
            sqLiteConnectionDatabase.CreateTable<CalculatorArvRenalDosageDosage>();
            sqLiteConnectionDatabase.CreateTable<CalculatorArvRenalDosageDosageItem>();
            sqLiteConnectionDatabase.CreateTable<CalculatorDrugInteractionArv>();
            sqLiteConnectionDatabase.CreateTable<CalculatorDrugInteractionEdl>();
            sqLiteConnectionDatabase.CreateTable<CalculatorDrugInteractionInteraction>();
        }
        
        public void Drop(SQLiteConnectionDatabase sqLiteConnectionDatabase)
        {
            sqLiteConnectionDatabase.DropTable<ItemCalculator>();
            
            sqLiteConnectionDatabase.DropTable<CalculatorPaediatricArvDosageArv>();
            sqLiteConnectionDatabase.DropTable<CalculatorPaediatricArvDosageWeightGroup>();
            sqLiteConnectionDatabase.DropTable<CalculatorAdverseReactionPathologyParameter>();
            sqLiteConnectionDatabase.DropTable<CalculatorAdverseReactionPathologyAgeCategory>();
            sqLiteConnectionDatabase.DropTable<CalculatorAdverseReactionPathologySex>();
            sqLiteConnectionDatabase.DropTable<CalculatorArvRenalDosageArv>();
            sqLiteConnectionDatabase.DropTable<CalculatorArvRenalDosageDosage>();
            sqLiteConnectionDatabase.DropTable<CalculatorArvRenalDosageDosageItem>();
            sqLiteConnectionDatabase.DropTable<CalculatorDrugInteractionArv>();
            sqLiteConnectionDatabase.DropTable<CalculatorDrugInteractionEdl>();
            sqLiteConnectionDatabase.DropTable<CalculatorDrugInteractionInteraction>();
        }
    }
}