using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Tb.Common
{
    public class CalculatorDrugInteractionInteraction : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed(Order = 1)]
        public Int32 EdlId { get; set; }

        [Indexed(Order = 2)]
        public Int32 ArvId { get; set; }

        public String Interaction { get; set; }

        public String Management { get; set; }

        public CalculatorDrugInteractionInteraction()
        {
        }

        public CalculatorDrugInteractionInteraction(Int32 id, Int32 edlId, Int32 arvId, String interaction, String management)
        {
            this.Id = id;
            this.EdlId = edlId;
            this.ArvId = arvId;
            this.Interaction = interaction;
            this.Management = management;
        }

        public override String ToString()
        {
            return String.Format("{0} {1}", this.Interaction, this.Management);
        }
    }
}