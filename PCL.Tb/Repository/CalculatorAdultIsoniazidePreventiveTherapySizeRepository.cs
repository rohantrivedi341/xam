using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Repository.Base;
using PCL.Tb.Common;

namespace PCL.Tb.Repository
{
    public class CalculatorAdultIsoniazidePreventiveTherapySizeRepository : BaseRepository<CalculatorAdultIsoniazidePreventiveTherapySize>
    {
        public CalculatorAdultIsoniazidePreventiveTherapySizeRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }
        
        public List<CalculatorAdultIsoniazidePreventiveTherapySize> GetByCalculatorAdultIsoniazidePreventiveTherapy(Int32 calculatorAdultIsoniazidePreventiveTherapy)
        {
            return this.Table.Where(x => calculatorAdultIsoniazidePreventiveTherapy.Equals(x.IptId)).OrderBy(x => x.Id).ToList();
        }
    }
}