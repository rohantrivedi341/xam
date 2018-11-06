using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Repository.Base;
using PCL.Tb.Common;

namespace PCL.Tb.Repository
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