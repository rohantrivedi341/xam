using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Tb.Common
{
    public class CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed]
        public Int32 TherapyId { get; set; }

        public String Title { get; set; }

        public String Dosage { get; set; }

        public CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup()
        {
        }

        public CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup(Int32 id, Int32 therapyId, String title, String dosage)
        {
            this.Id = id;
            this.TherapyId = therapyId;
            this.Title = title;
            this.Dosage = dosage;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}
