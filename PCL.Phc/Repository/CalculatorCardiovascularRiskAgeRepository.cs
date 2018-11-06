using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Phc.Common;
using PCL.Repository;
using PCL.Repository.Base;

namespace PCL.Phc.Repository
{
    public class CalculatorCardiovascularRiskAgeRepository : BaseRepository<CalculatorCardiovascularRiskAge>
    {
        public CalculatorCardiovascularRiskAgeRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase) : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorCardiovascularRiskAge> Get()
        {
            return this.Table.OrderBy(x => x.Id).ToList();
        }
    }
}