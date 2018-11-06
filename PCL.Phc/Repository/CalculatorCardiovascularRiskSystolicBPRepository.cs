using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Phc.Common;
using PCL.Repository;
using PCL.Repository.Base;

namespace PCL.Phc.Repository
{
    public class CalculatorCardiovascularRiskSystolicBpRepository : BaseRepository<CalculatorCardiovascularRiskSystolicBp>
    {
        public CalculatorCardiovascularRiskSystolicBpRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase) : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorCardiovascularRiskSystolicBp> Get(Boolean treated)
        {
            return this.Table.Where(x => treated.Equals(x.Treated)).ToList();
        }
    }
}