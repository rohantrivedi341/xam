using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Tb.Common
{
    public class CalculatorAdultDsTbDosageWeightGroup : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed]
        public Int32 DrugId { get; set; }

        public String Title { get; set; }

        public String Dosage { get; set; }

        public CalculatorAdultDsTbDosageWeightGroup()
        {
        }

        public CalculatorAdultDsTbDosageWeightGroup(Int32 id, Int32 drugId, String title, String dosage)
        {
            this.Id = id;
            this.DrugId = drugId;
            this.Title = title;
            this.Dosage = dosage;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}
