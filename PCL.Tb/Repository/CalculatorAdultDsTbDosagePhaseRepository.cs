using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Repository.Base;
using PCL.Tb.Common;

namespace PCL.Tb.Repository
{
    public class CalculatorAdultDsTbDosagePhaseRepository : BaseRepository<CalculatorAdultDsTbDosagePhase>
    {
        public CalculatorAdultDsTbDosagePhaseRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }
        
        public List<CalculatorAdultDsTbDosagePhase> Get()
        {
            return this.Table.OrderBy(x => x.Id).ToList();
        }
    }
}