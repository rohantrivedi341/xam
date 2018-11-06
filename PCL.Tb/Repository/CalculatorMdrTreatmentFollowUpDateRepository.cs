using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Repository.Base;
using PCL.Tb.Common;

namespace PCL.Tb.Repository
{
    public class CalculatorMdrTreatmentFollowUpDateRepository : BaseRepository<CalculatorMdrTreatmentFollowUpDate>
    {
        public CalculatorMdrTreatmentFollowUpDateRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }
        
        public List<CalculatorMdrTreatmentFollowUpDate> Get()
        {
            return this.Table.OrderBy(x => x.Id).ToList();
        }
    }
}