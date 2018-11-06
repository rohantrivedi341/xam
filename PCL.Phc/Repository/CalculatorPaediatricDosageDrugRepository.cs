using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Phc.Common;
using PCL.Repository;
using PCL.Repository.Base;

namespace PCL.Phc.Repository
{
    public class CalculatorPaediatricDosageDrugRepository : BaseRepository<CalculatorPaediatricDosageDrug>
    {
        public CalculatorPaediatricDosageDrugRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase) : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorPaediatricDosageDrug> Get()
        {
            return this.Table.OrderBy(x => x.Title).ToList();
        }
    }
}