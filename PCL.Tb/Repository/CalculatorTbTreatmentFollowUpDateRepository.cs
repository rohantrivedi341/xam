using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Repository.Base;
using PCL.Tb.Common;

namespace PCL.Tb.Repository
{
    public class CalculatorTbTreatmentFollowUpDateRepository : BaseRepository<CalculatorTbTreatmentFollowUpDate>
    {
        public CalculatorTbTreatmentFollowUpDateRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }
        
        public List<CalculatorTbTreatmentFollowUpDate> Get()
        {
            return this.Table.OrderBy(x => x.Id).ToList();
        }
    }
}