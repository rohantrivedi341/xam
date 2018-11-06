using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Tb.Common
{
    public class CalculatorPaediatricDsTbDosagePhase : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed]
        public Int32 CategoryId { get; set; }

        public String Title { get; set; }

        public String AvailableFormulations { get; set; }

        public CalculatorPaediatricDsTbDosagePhase()
        {
        }
        
        public CalculatorPaediatricDsTbDosagePhase(Int32 id, Int32 categoryId, String title, String availableFormulations)
        {
            this.Id = id;
            this.CategoryId = categoryId;
            this.Title = title;
            this.AvailableFormulations = availableFormulations;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}