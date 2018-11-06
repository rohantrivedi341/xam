using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Tb.Common
{
    public class CalculatorTbTreatmentFollowUpDate : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        public String Title { get; set; }

        public String Message { get; set; }

        public Int32 Days { get; set; }

        public CalculatorTbTreatmentFollowUpDate()
        {
        }

        public CalculatorTbTreatmentFollowUpDate(Int32 id, String title, String message, Int32 days)
        {
            this.Id = id;
            this.Title = title;
            this.Message = message;
            this.Days = days;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}
