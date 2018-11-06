using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Repository.Base;
using PCL.Tb.Common;

namespace PCL.Tb.Repository
{
    public class CalculatorPaediatricDsTbDosageCategoryRepository : BaseRepository<CalculatorPaediatricDsTbDosageCategory>
    {
        public CalculatorPaediatricDsTbDosageCategoryRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }
        
        public List<CalculatorPaediatricDsTbDosageCategory> Get()
        {
            return this.Table.OrderBy(x => x.Id).ToList();
        }
    }
}