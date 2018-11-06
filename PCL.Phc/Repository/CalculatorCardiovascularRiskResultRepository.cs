using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Phc.Common;
using PCL.Repository;
using PCL.Repository.Base;

namespace PCL.Phc.Repository
{
    public class CalculatorCardiovascularRiskResultRepository : BaseRepository<CalculatorCardiovascularRiskResult>
    {
        public CalculatorCardiovascularRiskResultRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase) : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorCardiovascularRiskResult> Get(CalculatorCardiovascularRiskSexType sexType)
        {
            return this.Table.Where(x => sexType.Equals(x.SexType)).OrderBy(x => x.Points).ToList();
        }
    }
}