using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Phc.Common;
using PCL.Repository;
using PCL.Repository.Base;

namespace PCL.Phc.Repository
{
    public class CalculatorCardiovascularRiskBpTreatmentRepository : BaseRepository<CalculatorCardiovascularRiskBpTreatment>
    {
        public CalculatorCardiovascularRiskBpTreatmentRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase) : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorCardiovascularRiskBpTreatment> Get()
        {
            return this.Table.OrderBy(x => x.Id).ToList();
        }
    }
}