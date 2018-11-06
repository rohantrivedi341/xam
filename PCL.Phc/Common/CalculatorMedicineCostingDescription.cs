using System;
using PCL.Common.Interface;
using SQLite;

namespace PCL.Phc.Common
{
    public class CalculatorMedicineCostingDescription : IEntity
    {
        [PrimaryKey]
        public Int32 Id { get; set; }

        [Indexed]
        public Int32 GenericId { get; set; }

        public String Title { get; set; }

        public String Brand { get; set; }

        public String Price { get; set; }

        public String ContractNumber { get; set; }

        public CalculatorMedicineCostingDescription()
        {
        }

        public CalculatorMedicineCostingDescription(Int32 id, Int32 genericId, String title, String brand, String price, String contractNumber)
        {
            this.Id = id;
            this.GenericId = genericId;
            this.Title = title;
            this.Brand = brand;
            this.Price = price;
            this.ContractNumber = contractNumber;
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}