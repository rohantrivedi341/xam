using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Phc.Common
{
    public class CalculatorCardiovascularRiskSystolicBp : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        public String Title { get; set; }

        [Indexed]
        public Boolean Treated { get; set; }

        public Int32 Male { get; set; }

        public Int32 Female { get; set; }

        public CalculatorCardiovascularRiskSystolicBp()
        {
        }

        public CalculatorCardiovascularRiskSystolicBp(Int32 id, String title, Boolean treated, Int32 male, Int32 female)
        {
            this.Id = id;
            this.Title = title;
            this.Treated = treated;
            this.Male = male;
            this.Female = female;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}