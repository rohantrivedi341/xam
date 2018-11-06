using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Phc.Common
{
    public class CalculatorMedicineCostingGeneric : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        public String Title { get; set; }

        public String Labels { get; set; }

        public CalculatorMedicineCostingGeneric()
        {
        }

        public CalculatorMedicineCostingGeneric(Int32 id, String title)
        {
            this.Id = id;
            this.Title = title;
            this.Labels = String.Empty;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}