using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Hiv.Common
{
    public class CalculatorArvRenalDosageArv : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        public String Title { get; set; }

        public CalculatorArvRenalDosageArv()
        {
        }

        public CalculatorArvRenalDosageArv(Int32 id, String title)
        {
            this.Id = id;
            this.Title = title;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}