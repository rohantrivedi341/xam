using System;

namespace PCL.Msf.Common
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
            if (value.Equals("TELEMEDICINE"))
            {
                return ItemCalculatorType.Telemedicine;
            }

            return ItemCalculatorType.Unknown;
        }
    }
}