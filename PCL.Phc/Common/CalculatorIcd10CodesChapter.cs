using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Phc.Common
{
    public class CalculatorIcd10CodesChapter : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        public Int32 Number { get; set; }

        public String Title { get; set; }

        public String Prefix { get; set; }

        public CalculatorIcd10CodesChapter()
        {
        }

        public CalculatorIcd10CodesChapter(Int32 id, Int32 number, String title, String prefix)
        {
            this.Id = id;
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