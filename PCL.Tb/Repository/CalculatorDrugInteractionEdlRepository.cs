using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Repository.Base;
using PCL.Tb.Common;

namespace PCL.Tb.Repository
{
    public class CalculatorDrugInteractionEdlRepository : BaseRepository<CalculatorDrugInteractionEdl>
    {
        public CalculatorDrugInteractionEdlRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorDrugInteractionEdl> Get()
        {
            return this.Table.ToList();
        }
    }
}