using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Hiv.Common
{
    public class CalculatorPaediatricArvDosageArv : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        public String Title { get; set; }

        public String TargetDose { get; set; }

        public String AvailableFormulations { get; set; }

        public CalculatorPaediatricArvDosageArv()
        {
        }

        public CalculatorPaediatricArvDosageArv(Int32 id, String title, String targetDose, String availableFormulations)
        {
            this.Id = id;
            this.Title = title;
            this.TargetDose = targetDose;
            this.AvailableFormulations = availableFormulations;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}