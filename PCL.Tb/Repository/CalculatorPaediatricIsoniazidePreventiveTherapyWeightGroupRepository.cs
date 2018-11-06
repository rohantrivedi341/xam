using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Repository.Base;
using PCL.Tb.Common;

namespace PCL.Tb.Repository
{
    public class CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroupRepository : BaseRepository<CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup>
    {
        public CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroupRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }
        
        public List<CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup> GetByCalculatorPaediatricIsoniazidePreventiveTherapy(Int32 calculatorPaediatricIsoniazidePreventiveTherapy)
        {
            return this.Table.Where(x => calculatorPaediatricIsoniazidePreventiveTherapy.Equals(x.TherapyId)).OrderBy(x => x.Id).ToList();
        }
    }
}