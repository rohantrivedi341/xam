using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Repository.Base;
using PCL.Tb.Common;

namespace PCL.Tb.Repository
{
    public class CalculatorPaediatricDsTbDosageWeightGroupRepository : BaseRepository<CalculatorPaediatricDsTbDosageWeightGroup>
    {
        public CalculatorPaediatricDsTbDosageWeightGroupRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorPaediatricDsTbDosageWeightGroup> GetByCalculatorPaediatricDsTbDosageCategory(Int32 calculatorPaediatricTbDosageCategory)
        {
            return this.Table.Where(x => calculatorPaediatricTbDosageCategory.Equals(x.CategoryId)).OrderBy(x => x.Id).ToList();
        }

        public List<CalculatorPaediatricDsTbDosageWeightGroup> GetByCalculatorPaediatricDsTbDosagePhase(Int32 calculatorPaediatricTbDosagePhase)
        {
            return this.Table.Where(x => calculatorPaediatricTbDosagePhase.Equals(x.PhaseId)).OrderBy(x => x.Id).ToList();
        }
    }
}