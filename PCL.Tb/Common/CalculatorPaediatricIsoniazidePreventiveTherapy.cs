using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Tb.Common
{
    public class CalculatorPaediatricIsoniazidePreventiveTherapy : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        public String TargetDose { get; set; }

        public String AvailableFormulations { get; set; }

        public CalculatorPaediatricIsoniazidePreventiveTherapy()
        {
        }

        public CalculatorPaediatricIsoniazidePreventiveTherapy(Int32 id, String targetDose, String availableFormulations)
        {
            this.Id = id;
            this.TargetDose = targetDose;
            this.AvailableFormulations = availableFormulations;
        }

        public override String ToString()
        {
            return this.TargetDose;
        }
    }
}
