using System;
using System.Collections.Generic;

namespace PCL.Tb.Common.View
{
    public class CalculatorTbTreatmentFollowUpDateView
    {
        public ItemCalculator ItemCalculator { get; set; }

        public DateTime TreatmentDate { get; set; }

        public List<CalculatorTbTreatmentFollowUpDate> FollowUpDates { get; set; }

        public CalculatorTbTreatmentFollowUpDateView(ItemCalculator itemCalculator)
        {
            this.ItemCalculator = itemCalculator;
        }
    }
}