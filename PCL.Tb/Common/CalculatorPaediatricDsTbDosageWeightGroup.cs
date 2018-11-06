using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Tb.Common
{
    public class CalculatorPaediatricDsTbDosageWeightGroup : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }
        
        [Indexed]
        public Int32? CategoryId { get; set; }

        [Indexed]
        public Int32? PhaseId { get; set; }
        
        public String Title { get; set; }

        public String Dosage { get; set; }

        public CalculatorPaediatricDsTbDosageWeightGroup()
        {
        }

        public CalculatorPaediatricDsTbDosageWeightGroup(Int32 id, String title, String dosage)
        {
            this.Id = id;
            this.Title = title;
            this.Dosage = dosage;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}