using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Common
{
    public class ItemContactNumber : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed]
        public Int32 ItemContactId { get; set; }

        public String Title { get; set; }

        public String Telephone { get; set; }

        public Int32 DisplayOrder { get; set; }

        public ItemContactNumber()
        {
        }

        public ItemContactNumber(Int32 id, Int32 itemContactId, String title, String telephone, Int32 displayOrder)
        {
            this.Id = id;
            this.ItemContactId = itemContactId;
            this.Title = title;
            this.Telephone = telephone;
            this.DisplayOrder = displayOrder;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}