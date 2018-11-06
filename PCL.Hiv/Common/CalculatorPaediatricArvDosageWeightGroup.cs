using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Hiv.Common
{
    public class CalculatorPaediatricArvDosageWeightGroup : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed]
        public Int32 ArvId { get; set; }

        public String Title { get; set; }

        public String Dosage { get; set; }

        public Int32 DisplayOrder { get; set; }

        public CalculatorPaediatricArvDosageWeightGroup()
        {
        }

        public CalculatorPaediatricArvDosageWeightGroup(Int32 id, Int32 arvId, String title, String dosage, Int32 displayOrder)
        {
            this.Id = id;
            this.ArvId = arvId;
            this.Title = title;
            this.Dosage = dosage;
            this.DisplayOrder = displayOrder;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}