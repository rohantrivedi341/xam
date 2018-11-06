using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Hiv.Common
{
    public class CalculatorAdverseReactionPathologySex : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        public String Title { get; set; }

        public CalculatorAdverseReactionPathologySexType Type { get; set; }

        public CalculatorAdverseReactionPathologySex()
        {
        }

        public CalculatorAdverseReactionPathologySex(Int32 id, String title, CalculatorAdverseReactionPathologySexType calculatorAdverseReactionPathologySexType)
        {
            this.Id = id;
            this.Title = title;
            this.Type = calculatorAdverseReactionPathologySexType;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}