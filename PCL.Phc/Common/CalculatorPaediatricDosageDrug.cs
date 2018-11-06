using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Phc.Common
{
    public class CalculatorPaediatricDosageDrug : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        public String Title { get; set; }

        public String Indications { get; set; }

        public String Frequency { get; set; }

        public String DosageFormula { get; set; }

        public CalculatorPaediatricDosageDrug()
        {
        }

        public CalculatorPaediatricDosageDrug(Int32 id, String title, String targetDose, String availableFormulations, String dosageFormula)
        {
            this.Id = id;
            this.Title = title;
            this.Indications = targetDose;
            this.Frequency = availableFormulations;
            this.DosageFormula = dosageFormula;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}