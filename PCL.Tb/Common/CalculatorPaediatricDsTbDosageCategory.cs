using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Tb.Common
{
    public class CalculatorPaediatricDsTbDosageCategory : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        public String Title { get; set; }

        public String AvailableFormulations { get; set; }

        public CalculatorPaediatricDsTbDosageCategory()
        {
        }

        public CalculatorPaediatricDsTbDosageCategory(Int32 id, String title)
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