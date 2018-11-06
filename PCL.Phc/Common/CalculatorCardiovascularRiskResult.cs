using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Phc.Common
{
    public class CalculatorCardiovascularRiskResult : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed]
        public CalculatorCardiovascularRiskSexType SexType { get; set; }

        public Int32 Points { get; set; }

        public String RiskText { get; set; }

        public Double RiskValue { get; set; }

        public CalculatorCardiovascularRiskResult()
        {
        }

        public CalculatorCardiovascularRiskResult(Int32 id, CalculatorCardiovascularRiskSexType sexType, Int32 points, String riskText, Double riskValue)
        {
            this.Id = id;
            this.SexType = sexType;
            this.Points = points;
            this.RiskText = riskText;
            this.RiskValue = riskValue;
        }

        public override String ToString()
        {
            return this.RiskText;
        }
    }
}