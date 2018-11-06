using System;

namespace PCL.Hiv.Common.View
{
    public class CalculatorAdverseReactionPathologyResult
    {
        public CalculatorAdverseReactionPathologyParameter Parameter { get; set; }

        public CalculatorAdverseReactionPathologyAgeCategory AgeCategory { get; set; }

        public Double SexUln { get; set; }

        public Double TestResult { get; set; }

        public Double TestResultUln { get; set; }

        public CalculatorAdverseReactionPathologyGrade Grade { get; set; }
    }
}