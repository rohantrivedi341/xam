using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Phc.Common;
using PCL.Repository;
using PCL.Repository.Base;

namespace PCL.Phc.Repository
{
    public class CalculatorMedicineCostingDescriptionRepository : BaseRepository<CalculatorMedicineCostingDescription>
    {
        public CalculatorMedicineCostingDescriptionRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase) : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorMedicineCostingDescription> Get()
        {
            return this.Table.OrderBy(x => x.Title).ToList();
        }

        public List<CalculatorMedicineCostingDescription> GetByCalculatorMedicineCostingGeneric(Int32 calculatorMedicineCostingGenericId)
        {
            return this.Table.Where(x => calculatorMedicineCostingGenericId.Equals(x.GenericId)).OrderBy(x => x.Title).ToList();
        }
    }
}