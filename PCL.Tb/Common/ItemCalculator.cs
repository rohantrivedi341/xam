using System;

namespace PCL.Tb.Common
{
    public class ItemCalculator : PCL.Common.ItemCalculator
    {
        public ItemCalculatorType Type { get; set; }

        public ItemCalculator()
        {
        }

        public ItemCalculator(PCL.Common.ItemCalculator baseObject)
        {
            this.Id = baseObject.Id;
            this.StructureItemId = baseObject.StructureItemId;
            this.Identifier = baseObject.Identifier;
            this.Type = ItemCalculatorType.Unknown;
            this.FileName = baseObject.FileName;
            this.Folder = baseObject.Folder;
            this.Url = baseObject.Url;
            this.Pdf = baseObject.Pdf;
        }

        public override String ToString()
        {
            return this.Type.ToString();
        }

        public static ItemCalculatorType IdentifyType(String value)
        {
            if (value.Equals("PAEDIATRIC_DS_TB_DOSAGES"))
            {
                return ItemCalculatorType.PaediatricDsTbDosages;
            }

            if (value.Equals("PAEDIATRIC_ISONIAZIDE_PREVENTIVE_THERAPY"))
            {
                return ItemCalculatorType.PaediatricIsoniazidePreventiveTherapy;
            }

            if (value.Equals("ADULT_DS_TB_DOSAGES"))
            {
                return ItemCalculatorType.AdultDsTbDosages;
            }

            if (value.Equals("ADULT_ISONIAZIDE_PREVENTIVE_THERAPY"))
            {
                return ItemCalculatorType.AdultIsoniazidePreventiveTherapy;
            }

            if (value.Equals("BMI"))
            {
                return ItemCalculatorType.Bmi;
            }

            if (value.Equals("TB_TREATMENT_FOLLOW_UP_DATES"))
            {
                return ItemCalculatorType.TbTreatmentFollowUpDates;
            }
            
            if (value.Equals("MDR_TREATMENT_FOLLOW_UP_DATES"))
            {
                return ItemCalculatorType.MdrTreatmentFollowUpDates;
            }

            if (value.Equals("DRUG_INTERACTION"))
            {
                return ItemCalculatorType.DrugInteraction;
            }

            if (value.Equals("DRUG_STOCK_OUT"))
            {
                return ItemCalculatorType.DrugStockOut;
            }

            if (value.Equals("SUSPECTED_ADVERSE_DRUG_REACTION"))
            {
                return ItemCalculatorType.SuspectedAdverseDrugReaction;
            }

            return ItemCalculatorType.Unknown;
        }
    }
}