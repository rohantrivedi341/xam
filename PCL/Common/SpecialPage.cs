using System;
using PCL.Common.Enum;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Common
{
    public class SpecialPage : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed]
        public Int32 SectionId { get; set; }

        public String Title { get; set; }

        public SpecialPageType Type { get; set; }

        public String FileName { get; set; }

        public SpecialPage()
        {
        }

        public SpecialPage(Int32 id, Int32 sectionId, String title, SpecialPageType type, String fileName)
        {
            this.Id = id;
            this.Title = title;
            this.SectionId = sectionId;
            this.Type = type;
            this.FileName = fileName;
        }

        public override String ToString()
        {
            return this.Title;
        }

        public static SpecialPageType IdentifyType(String value)
        {
            if (value.Equals("ABOUT"))
            {
                return SpecialPageType.About;
            }

            if (value.Equals("DISCLAIMER"))
            {
                return SpecialPageType.Disclaimer;
            }

            if (value.Equals("FEEDBACK"))
            {
                return SpecialPageType.Feedback;
            }

            return SpecialPageType.Unknown;
        }
    }
}