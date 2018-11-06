using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Tb.Common
{
    public class CalculatorAdultDsTbDosagePhase : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }
        
        public String Title { get; set; }

        public CalculatorAdultDsTbDosagePhase()
        {
        }

        public CalculatorAdultDsTbDosagePhase(Int32 id, String title)
        {
            this.Id = id;
            this.Title = title;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}
