using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Hiv.Common
{
    public class CalculatorArvRenalDosageDosage : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed]
        public Int32 ArvId { get; set; }

        public String Title { get; set; }

        public String UsualDosage { get; set; }

        public CalculatorArvRenalDosageDosageType Type { get; set; }

        public Int32 TypeValue { get; set; }

        public CalculatorArvRenalDosageDosage()
        {
        }

        public CalculatorArvRenalDosageDosage(Int32 id, Int32 arvId, String title, String usualDosage)
        {
            this.Id = id;
            this.ArvId = arvId;
            this.Title = title;
            this.UsualDosage = usualDosage;
            this.Type = CalculatorArvRenalDosageDosageType.Normal;
        }

        public CalculatorArvRenalDosageDosage(Int32 id, Int32 arvId, String title, String usualDosage, CalculatorArvRenalDosageDosageType type, Int32 typeValue)
        {
            this.Id = id;
            this.ArvId = arvId;
            this.Title = title;
            this.UsualDosage = usualDosage;
            this.Type = type;
            this.TypeValue = typeValue;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}