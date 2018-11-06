using PCL.Database;
using PCL.DependencyServices;
using PCL.Tb.Common;
using PCL.Tb.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyApplicationTbDatabase))]

namespace PCL.Tb.DependencyServices
{
    public class DependencyApplicationTbDatabase : IDependencyApplicationDatabase
    {
        public void Create(SQLiteConnectionDatabase sqLiteConnectionDatabase)
        {
            sqLiteConnectionDatabase.CreateTable<ItemCalculator>();

            sqLiteConnectionDatabase.CreateTable<CalculatorAdultDsTbDosageDrug>();
            sqLiteConnectionDatabase.CreateTable<CalculatorAdultDsTbDosagePhase>();
            sqLiteConnectionDatabase.CreateTable<CalculatorAdultDsTbDosageWeightGroup>();
            sqLiteConnectionDatabase.CreateTable<CalculatorAdultIsoniazidePreventiveTherapy>();
            sqLiteConnectionDatabase.CreateTable<CalculatorAdultIsoniazidePreventiveTherapySize>();
            sqLiteConnectionDatabase.CreateTable<CalculatorBmi>();
            sqLiteConnectionDatabase.CreateTable<CalculatorPaediatricDsTbDosageCategory>();
            sqLiteConnectionDatabase.CreateTable<CalculatorPaediatricDsTbDosagePhase>();
            sqLiteConnectionDatabase.CreateTable<CalculatorPaediatricDsTbDosageWeightGroup>();
            sqLiteConnectionDatabase.CreateTable<CalculatorPaediatricIsoniazidePreventiveTherapy>();
            sqLiteConnectionDatabase.CreateTable<CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup>();
            sqLiteConnectionDatabase.CreateTable<CalculatorTbTreatmentFollowUpDate>();
            sqLiteConnectionDatabase.CreateTable<CalculatorMdrTreatmentFollowUpDate>();
            sqLiteConnectionDatabase.CreateTable<CalculatorDrugInteractionArv>();
            sqLiteConnectionDatabase.CreateTable<CalculatorDrugInteractionEdl>();
            sqLiteConnectionDatabase.CreateTable<CalculatorDrugInteractionInteraction>();
        }
        
        public void Drop(SQLiteConnectionDatabase sqLiteConnectionDatabase)
        {
            sqLiteConnectionDatabase.DropTable<ItemCalculator>();

            sqLiteConnectionDatabase.DropTable<CalculatorAdultDsTbDosageDrug>();
            sqLiteConnectionDatabase.DropTable<CalculatorAdultDsTbDosagePhase>();
            sqLiteConnectionDatabase.DropTable<CalculatorAdultDsTbDosageWeightGroup>();
            sqLiteConnectionDatabase.DropTable<CalculatorAdultIsoniazidePreventiveTherapy>();
            sqLiteConnectionDatabase.DropTable<CalculatorAdultIsoniazidePreventiveTherapySize>();
            sqLiteConnectionDatabase.DropTable<CalculatorBmi>();
            sqLiteConnectionDatabase.DropTable<CalculatorPaediatricDsTbDosageCategory>();
            sqLiteConnectionDatabase.DropTable<CalculatorPaediatricDsTbDosagePhase>();
            sqLiteConnectionDatabase.DropTable<CalculatorPaediatricDsTbDosageWeightGroup>();
            sqLiteConnectionDatabase.DropTable<CalculatorPaediatricIsoniazidePreventiveTherapy>();
            sqLiteConnectionDatabase.DropTable<CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup>();
            sqLiteConnectionDatabase.DropTable<CalculatorTbTreatmentFollowUpDate>();
            sqLiteConnectionDatabase.DropTable<CalculatorMdrTreatmentFollowUpDate>();
            sqLiteConnectionDatabase.DropTable<CalculatorDrugInteractionArv>();
            sqLiteConnectionDatabase.DropTable<CalculatorDrugInteractionEdl>();
            sqLiteConnectionDatabase.DropTable<CalculatorDrugInteractionInteraction>();
        }
    }
}