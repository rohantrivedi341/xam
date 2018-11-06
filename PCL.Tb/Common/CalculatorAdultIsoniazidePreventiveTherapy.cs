using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Tb.Common
{
    public class CalculatorAdultIsoniazidePreventiveTherapy : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        public Boolean ArtTreatment { get; set; }

        public Boolean TstAvailable { get; set; }

        public String Management { get; set; }

        public CalculatorAdultIsoniazidePreventiveTherapy()
        {
        }

        public CalculatorAdultIsoniazidePreventiveTherapy(Int32 id, Boolean onArt, Boolean tstAvailable)
        {
            this.Id = id;
            this.ArtTreatment = onArt;
            this.TstAvailable = tstAvailable;
        }

        public override string ToString()
        {
            return this.ArtTreatment + " " + this.TstAvailable + " " + this.Management;
        }
    }
}
