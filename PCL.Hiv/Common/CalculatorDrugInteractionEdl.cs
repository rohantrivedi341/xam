using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Hiv.Common
{
    public class CalculatorDrugInteractionEdl : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        public String Title { get; set; }

        public CalculatorDrugInteractionEdl()
        {
        }

        public CalculatorDrugInteractionEdl(Int32 id, String title)
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