using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Common
{
    public class ItemContact : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed]
        public Int32 StructureItemId { get; set; }

        public String Title { get; set; }

        public String PhysicalAddress { get; set; }

        public String PostalAddress { get; set; }

        public String WebsiteUrl { get; set; }

        public String EmailAddress { get; set; }

        public String WorkingHours { get; set; }

        public String FacilityClassification { get; set; }

        public String FacilityManager { get; set; }
        
        public String FacilityManagerEmailAddress { get; set; }

        public String Latitude { get; set; }

        public String Longitude { get; set; }

        public ItemContact()
        {
        }

        public ItemContact(Int32 id, Int32 structureItemId, String title)
        {
            this.Id = id;
            this.StructureItemId = structureItemId;
            this.Title = title;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}