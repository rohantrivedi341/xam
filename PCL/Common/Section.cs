using System;
using PCL.Common.Enum;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Common
{
    public class Section : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        public SectionType Type { get; set; }

        public String Title { get; set; }

        public String TitleAbbreviation { get; set; }

        public String Icon { get; set; }

        public String Location { get; set; }

        public Boolean DisplayInMenu { get; set; }

        public Section()
        {
        }

        public Section(Int32 id, SectionType type, String title, String titleAbbreviation, String icon, String location, Boolean displayInMenu)
        {
            this.Id = id;
            this.Type = type;
            this.Title = title;
            this.TitleAbbreviation = titleAbbreviation;
            this.Icon = icon;
            this.Location = location;
            this.DisplayInMenu = displayInMenu;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}