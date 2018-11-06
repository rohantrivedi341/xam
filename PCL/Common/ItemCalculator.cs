using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Common
{
    public class ItemCalculator : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed]
        public Int32 StructureItemId { get; set; }

        public String Identifier { get; set; }


        public String FileName { get; set; }

        public String Folder { get; set; }

        public String Url { get; set; }

        public String Pdf { get; set; }
        
        public ItemCalculator()
        {
        }

        public ItemCalculator(Int32 id, Int32 structureItemId, String identifier)
        {
            this.Id = id;
            this.StructureItemId = structureItemId;
            this.Identifier = identifier;
        }
    }
}