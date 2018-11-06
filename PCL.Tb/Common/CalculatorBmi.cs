using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Tb.Common
{
    public class CalculatorBmi : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        public String Title { get; set; }

        public String Message { get; set; }

        public String Color { get; set; }
        
        public Double? ValueStart { get; set; }

        public Double? ValueEnd { get; set; }
        
        public CalculatorBmi()
        {
        }

        public CalculatorBmi(Int32 id, String title, String message, String color, Double? valueStart, Double? valueEnd)
        {
            this.Id = id;
            this.Title = title;
            this.Message = message;
            this.Color = color;
            this.ValueStart = valueStart;
            this.ValueEnd = valueEnd;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}
