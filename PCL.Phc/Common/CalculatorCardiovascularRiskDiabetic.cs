using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Phc.Common
{
    public class CalculatorCardiovascularRiskDiabetic : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        public String Title { get; set; }

        public Int32 Male { get; set; }

        public Int32 Female { get; set; }

        public CalculatorCardiovascularRiskDiabetic()
        {
        }

        public CalculatorCardiovascularRiskDiabetic(Int32 id, String title, Int32 male, Int32 female)
        {
            this.Id = id;
            this.Title = title;
            this.Male = male;
            this.Female = female;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}