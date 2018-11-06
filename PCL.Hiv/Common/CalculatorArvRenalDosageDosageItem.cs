using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Hiv.Common
{
    public class CalculatorArvRenalDosageDosageItem : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed]
        public Int32 DosageId { get; set; }

        public String Title { get; set; }

        public String Value { get; set; }

        public Int32? CreatinineClearanceBeginMlPerMinute { get; set; }

        public Int32? CreatinineClearanceEndMlPerMinute { get; set; }

        public CalculatorArvRenalDosageDosageItem()
        {
        }

        public CalculatorArvRenalDosageDosageItem(Int32 id, Int32 dosageId, String title, String value)
        {
            this.Id = id;
            this.DosageId = dosageId;
            this.Title = title;
            this.Value = value;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}