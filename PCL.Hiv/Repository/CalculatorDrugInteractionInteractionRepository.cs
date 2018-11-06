using System;
using System.Linq;
using PCL.Database;
using PCL.Hiv.Common;
using PCL.Repository;
using PCL.Repository.Base;
using SQLite;

namespace PCL.Hiv.Repository
{
    public class CalculatorDrugInteractionInteractionRepository : BaseRepository<CalculatorDrugInteractionInteraction>
    {
        public CalculatorDrugInteractionInteractionRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }

        public CalculatorDrugInteractionInteraction Get(Int32 edlId, Int32 arvId)
        {
            return this.Table.Where(x => edlId.Equals(x.EdlId)).Where(x => arvId.Equals(x.ArvId)).SingleOrDefault();
        }
    }
}