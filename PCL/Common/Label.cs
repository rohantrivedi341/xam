using System;
using PCL.Common.Enum;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Common
{
    public class Label : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed(Order = 1)]
        public StructureItemType Type { get; set; }

        [Indexed(Order = 2)]
        public Int32 StructureItemId { get; set; }

        public String Title { get; set; }

        public String SubTitle { get; set; }

        public Label()
        {
        }

        public Label(Int32 id, StructureItemType type, Int32 structureItemId, String title, String subTitle)
        {
            this.Id = id;
            this.Type = type;
            this.StructureItemId = structureItemId;
            this.Title = title;
            this.SubTitle = subTitle;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}