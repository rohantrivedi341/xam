using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Common
{
    public class ItemPage : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed]
        public Int32 StructureItemId { get; set; }

        public String FileName { get; set; }

        public ItemPage()
        {
        }

        public ItemPage(Int32 id, Int32 structureItemId, String fileName)
        {
            this.Id = id;
            this.StructureItemId = structureItemId;
            this.FileName = fileName;
        }

        public override String ToString()
        {
            return this.FileName;
        }
    }
}