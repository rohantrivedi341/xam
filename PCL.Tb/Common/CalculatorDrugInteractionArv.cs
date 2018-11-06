using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Tb.Common
{
    public class CalculatorDrugInteractionArv : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        public String Title { get; set; }

        public CalculatorDrugInteractionArv()
        {
        }

        public CalculatorDrugInteractionArv(Int32 id, String title)
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