using System;
using System.Collections.Generic;

namespace PCL.Tb.Common.View
{
    public class CalculatorMdrTreatmentFollowUpDateView
    {
        public ItemCalculator ItemCalculator { get; set; }

        public DateTime TreatmentDate { get; set; }

        public List<CalculatorMdrTreatmentFollowUpDate> FollowUpDates { get; set; }

        public CalculatorMdrTreatmentFollowUpDateView(ItemCalculator itemCalculator)
        {
            this.ItemCalculator = itemCalculator;
        }
    }
}