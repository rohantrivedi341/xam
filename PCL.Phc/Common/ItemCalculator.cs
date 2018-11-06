using System;

namespace PCL.Phc.Common
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
            if (value.Equals("PAEDIATRIC_DOSAGES"))
            {
                return ItemCalculatorType.PaediatricDosages;
            }

            if (value.Equals("MEDICINE_COSTING"))
            {
                return ItemCalculatorType.MedicineCosting;
            }

            if (value.Equals("DRUG_STOCK_OUT"))
            {
                return ItemCalculatorType.DrugStockOut;
            }

            if (value.Equals("SUSPECTED_ADVERSE_DRUG_REACTION"))
            {
                return ItemCalculatorType.SuspectedAdverseDrugReaction;
            }

            if (value.Equals("ICD_10_CODES"))
            {
                return ItemCalculatorType.Icd10Codes;
            }

            if (value.Equals("CARDIOVASCULAR_RISK"))
            {
                return ItemCalculatorType.CardiovascularRisk;
            }

            return ItemCalculatorType.Unknown;
        }
    }
}