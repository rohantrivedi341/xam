using System;

namespace PCL.Hiv.Common.View
{
    public class CalculatorArvRenalDosageView
    {
        public CalculatorArvRenalDosageArv Arv { get; set; }

        public CalculatorArvRenalDosageDosage Dosage { get; set; }

        public CalculatorArvRenalDosageDosageItem DosageItem { get; set; }

        public Int32? CreatinineClearance { get; set; }
    }
}