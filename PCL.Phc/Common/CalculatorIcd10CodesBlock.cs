using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Phc.Common
{
    public class CalculatorIcd10CodesBlock : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed]
        public Int32 Chapter { get; set; }

        public String Number { get; set; }

        public String Title { get; set; }

        public String Prefix { get; set; }

        public CalculatorIcd10CodesBlock()
        {
        }

        public CalculatorIcd10CodesBlock(Int32 id, Int32 chapter, String number, String title, String prefix)
        {
            this.Id = id;
            this.Chapter = chapter;
            this.Number = number;
            this.Title = title;
            this.Prefix = prefix;
        }

        public override String ToString()
        {
            return this.Prefix + " " + this.Title;
        }
    }
}