using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Repository.Base;
using PCL.Tb.Common;

namespace PCL.Tb.Repository
{
    public class CalculatorPaediatricDsTbDosagePhaseRepository : BaseRepository<CalculatorPaediatricDsTbDosagePhase>
    {
        public CalculatorPaediatricDsTbDosagePhaseRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorPaediatricDsTbDosagePhase> GetByCalculatorPaediatricDsTbDosageCategory(Int32 calculatorPaediatricTbDosageCategory)
        {
            return this.Table.Where(x => calculatorPaediatricTbDosageCategory.Equals(x.CategoryId)).OrderBy(x => x.Id).ToList();
        }
    }
}