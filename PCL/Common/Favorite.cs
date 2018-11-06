using System;
using PCL.Common.Enum;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Common
{
    public class Favorite : IEntity
    {
        [PrimaryKey]
        [AutoIncrement]
        public Int32 Id { get; set; }

		public Guid Uuid { get; set; }

        [Indexed]
        public StructureItemType Type { get; set; }
        
        public String Title { get; set; }

        public String SubTitle { get; set; }

        public Favorite()
        {
        }

        public Favorite(Guid uuid, StructureItemType type, String title, String subTitle)
        {
            this.Uuid = uuid;
            this.Type = type;
            this.Title = title;
            this.SubTitle = subTitle;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}