using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Phc.Common;
using PCL.Repository;
using PCL.Repository.Base;

namespace PCL.Phc.Repository
{
    public class CalculatorMedicineCostingGenericRepository : BaseRepository<CalculatorMedicineCostingGeneric>
    {
        public CalculatorMedicineCostingGenericRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase) : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorMedicineCostingGeneric> Get()
        {
            return this.Table.OrderBy(x => x.Title).ToList();
        }
    }
}