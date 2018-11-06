using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Phc.Common
{
    public class CalculatorPaediatricDosageAgeWeightGroup : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed]
        public Int32 DrugId { get; set; }

        public String Title { get; set; }

        public String Dosage { get; set; }

        public String FormulationOptions { get; set; }

        public Int32 DisplayOrder { get; set; }

        public CalculatorPaediatricDosageAgeWeightGroup()
        {
        }

        public CalculatorPaediatricDosageAgeWeightGroup(Int32 id, Int32 drugId, String title, String dosage, String formulationOptions, Int32 displayOrder)
        {
            this.Id = id;
            this.DrugId = drugId;
            this.Title = title;
            this.Dosage = dosage;
            this.FormulationOptions = formulationOptions;
            this.DisplayOrder = displayOrder;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}