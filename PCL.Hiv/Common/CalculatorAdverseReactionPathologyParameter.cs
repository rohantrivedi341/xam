using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Hiv.Common
{
    public class CalculatorAdverseReactionPathologyParameter : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        public String Title { get; set; }

        public String Unit { get; set; }

        public CalculatorAdverseReactionPathologyParameter()
        {
        }

        public CalculatorAdverseReactionPathologyParameter(Int32 id, String title, String unit)
        {
            this.Id = id;
            this.Title = title;
            this.Unit = unit;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}