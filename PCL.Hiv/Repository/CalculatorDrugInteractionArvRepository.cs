using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Hiv.Common;
using PCL.Repository;
using PCL.Repository.Base;
using SQLite;

namespace PCL.Hiv.Repository
{
    public class CalculatorDrugInteractionArvRepository : BaseRepository<CalculatorDrugInteractionArv>
    {
        public CalculatorDrugInteractionArvRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorDrugInteractionArv> Get()
        {
            return this.Table.ToList();
        }
    }
}