using System;
using System.Collections.Generic;

namespace PCL.Hiv.Common.View
{
    public class CalculatorAdverseReactionPathologyView
    {
        public DateTime DateOfBirth { get; set; }

        public Int32 DaysBorn { get; set; }

        public CalculatorAdverseReactionPathologySex Sex { get; set; }

        public List<CalculatorAdverseReactionPathologyResult> Results { get; set; }
    }
}