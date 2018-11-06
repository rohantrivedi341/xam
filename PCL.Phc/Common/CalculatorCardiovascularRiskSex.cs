using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Phc.Common
{
    public class CalculatorCardiovascularRiskSex : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        public String Title { get; set; }

        public CalculatorCardiovascularRiskSexType Type { get; set; }

        public CalculatorCardiovascularRiskSex()
        {
        }

        public CalculatorCardiovascularRiskSex(Int32 id, String title, CalculatorCardiovascularRiskSexType type)
        {
            this.Id = id;
            this.Title = title;
            this.Type = type;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}