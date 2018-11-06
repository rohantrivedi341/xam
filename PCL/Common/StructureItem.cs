using System;
using PCL.Common.Enum;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Common
{
    public class StructureItem : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        public Guid? Uuid { get; set; }
        
        [Indexed(Order = 1)]
        public Int32 SectionId { get; set; }

        [Indexed(Order = 2)]
        public Int32? ParentId { get; set; }

        public String Title { get; set; }
        
        public String SubTitle { get; set; }

        public String Information { get; set; }

        public StructureItemType Type { get; set; }

        public Int32 DisplayOrder { get; set; }

        public StructureItem()
        {
        }

        public StructureItem(Int32 id, Int32 sectionId, Int32? parentId, String title, StructureItemType type, Int32 displayOrder)
        {
            this.Id = id;
            this.SectionId = sectionId;
            this.ParentId = parentId;
            this.Title = title;
            this.Type = type;
            this.DisplayOrder = displayOrder;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}