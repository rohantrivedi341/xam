using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Hiv.Common
{
    public class CalculatorAdverseReactionPathologyAgeCategory : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed]
        public Int32 ParameterId { get; set; }

        public String Title { get; set; }

        public Int32 StartDay { get; set; }

        public Int32 EndDay { get; set; }

        public Int32 UlnMale { get; set; }

        public Int32 UlnFemale { get; set; }

        public Double GradeNoAbnormalReaction { get; set; }

        public Double Grade1 { get; set; }

        public Double Grade2 { get; set; }

        public Double Grade3 { get; set; }

        public Double Grade4 { get; set; }

        public CalculatorAdverseReactionPathologyAgeCategory()
        {
        }

        public CalculatorAdverseReactionPathologyAgeCategory(Int32 id, Int32 parameterId, String title, Int32 startDay, Int32 endDay, Int32 ulnMale, Int32 ulnFemale, Double gradeNoAbnormalReaction, Double grade1, Double grade2, Double grade3, Double grade4)
        {
            this.Id = id;
            this.ParameterId = parameterId;
            this.Title = title;
            this.StartDay = startDay;
            this.EndDay = endDay;
            this.UlnMale = ulnMale;
            this.UlnFemale = ulnFemale;
            this.GradeNoAbnormalReaction = gradeNoAbnormalReaction;
            this.Grade1 = grade1;
            this.Grade2 = grade2;
            this.Grade3 = grade3;
            this.Grade4 = grade4;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}