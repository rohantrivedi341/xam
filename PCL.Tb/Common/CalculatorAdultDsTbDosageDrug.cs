using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Tb.Common
{
    public class CalculatorAdultDsTbDosageDrug : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed]
        public Int32 PhaseId { get; set; }

        public String Title { get; set; }

        public String TargetDose { get; set; }

        public String AvailableFormulations { get; set; }

        public CalculatorAdultDsTbDosageDrug()
        {
        }

        public CalculatorAdultDsTbDosageDrug(Int32 id, Int32 phaseId, String title, String targetDose, String availableFormulations)
        {
            this.Id = id;
            this.PhaseId = phaseId;
            this.Title = title;
            this.TargetDose = targetDose;
            this.AvailableFormulations = availableFormulations;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}
