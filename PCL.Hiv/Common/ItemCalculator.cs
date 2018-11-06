using System;

namespace PCL.Hiv.Common
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
            if (value.Equals("PAEDIATRIC_ARV_DOSAGE"))
            {
                return ItemCalculatorType.PaediatricArvDosage;
            }

            if (value.Equals("ADVERSE_REACTION_PATHOLOGY"))
            {
                return ItemCalculatorType.AdverseReactionPathology;
            }

            if (value.Equals("ARV_RENAL_DOSAGE"))
            {
                return ItemCalculatorType.ArvRenalDosage;
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