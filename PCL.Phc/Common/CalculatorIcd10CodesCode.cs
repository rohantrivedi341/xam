using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Phc.Common
{
    public class CalculatorIcd10CodesCode : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed(Name = "IX_ChapterBlock", Order = 1)]
        public Int32 Chapter { get; set; }

        [MaxLength(255)]
        [Indexed(Name = "IX_ChapterBlock", Order = 2)]
        public String Block { get; set; }

        [MaxLength(255)]
        public String Code { get; set; }

        public String Title { get; set; }

        public CalculatorIcd10CodesCode()
        {
        }

        public CalculatorIcd10CodesCode(Int32 id, Int32 chapter, String block, String code, String title)
        {
            this.Id = id;
            this.Chapter = chapter;
            this.Block = block;
            this.Code = code;
            this.Title = title;
        }

        public override String ToString()
        {
            return this.Code + " " + this.Title;
        }
    }
}