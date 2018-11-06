using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Hiv.Common;
using PCL.Repository;
using PCL.Repository.Base;
using SQLite;

namespace PCL.Hiv.Repository
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