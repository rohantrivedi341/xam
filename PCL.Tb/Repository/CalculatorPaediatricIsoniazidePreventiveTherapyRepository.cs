using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Repository.Base;
using PCL.Tb.Common;

namespace PCL.Tb.Repository
{
    public class CalculatorPaediatricIsoniazidePreventiveTherapyRepository : BaseRepository<CalculatorPaediatricIsoniazidePreventiveTherapy>
    {
        public CalculatorPaediatricIsoniazidePreventiveTherapyRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }
        
        public List<CalculatorPaediatricIsoniazidePreventiveTherapy> Get()
        {
            return this.Table.OrderBy(x => x.Id).ToList();
        }
    }
}