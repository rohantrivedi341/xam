using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Hiv.Common;
using PCL.Repository;
using PCL.Repository.Base;
using SQLite;

namespace PCL.Hiv.Repository
{
    public class CalculatorArvRenalDosageArvRepository : BaseRepository<CalculatorArvRenalDosageArv>
    {
        public CalculatorArvRenalDosageArvRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorArvRenalDosageArv> Get()
        {
            return this.Table.OrderBy(x => x.Title).ToList();
        }
    }
}