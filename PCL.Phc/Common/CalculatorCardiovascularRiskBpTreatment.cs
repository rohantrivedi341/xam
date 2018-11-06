using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Phc.Common
{
    public class CalculatorCardiovascularRiskBpTreatment : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        public String Title { get; set; }

        public Boolean Treatment { get; set; }

        public CalculatorCardiovascularRiskBpTreatment()
        {
        }

        public CalculatorCardiovascularRiskBpTreatment(Int32 id, String title, Boolean treatment)
        {
            this.Id = id;
            this.Title = title;
            this.Treatment = treatment;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}