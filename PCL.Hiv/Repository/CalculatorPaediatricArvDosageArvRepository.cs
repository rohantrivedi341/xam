using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Hiv.Common;
using PCL.Repository;
using PCL.Repository.Base;
using SQLite;

namespace PCL.Hiv.Repository
{
    public class CalculatorPaediatricArvDosageArvRepository : BaseRepository<CalculatorPaediatricArvDosageArv>
    {
        public CalculatorPaediatricArvDosageArvRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorPaediatricArvDosageArv> Get()
        {
            return this.Table.OrderBy(x => x.Title).ToList();
        }
    }
}