using System;
using PCL.Common.Enum;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Common
{
    public class ItemCalculatorLink : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed]
        public Int32 ItemCalculatorId { get; set; }

        public ItemCalculatorLinkType Type { get; set; }

        public String Link { get; set; }

        public ItemCalculatorLink()
        {
        }

        public ItemCalculatorLink(Int32 id, Int32 itemCalculatorId, ItemCalculatorLinkType type, String link)
        {
            this.Id = id;
            this.ItemCalculatorId = itemCalculatorId;
            this.Type = type;
            this.Link = link;
        }
    }
}