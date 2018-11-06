using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Tb.Common
{
    public class CalculatorAdultIsoniazidePreventiveTherapySize : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed]
        public Int32 IptId { get; set; }
        
        public String Title { get; set; }
        
        public String Management { get; set; }

        public CalculatorAdultIsoniazidePreventiveTherapySize()
        {
        }
        
        public CalculatorAdultIsoniazidePreventiveTherapySize(Int32 id, Int32 iptId, String title, String management)
        {
            this.Id = id;
            this.IptId = iptId;
            this.Title = title;
            this.Management = management;
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
