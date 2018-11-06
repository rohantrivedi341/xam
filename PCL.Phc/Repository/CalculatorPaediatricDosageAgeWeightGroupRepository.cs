using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Phc.Common;
using PCL.Repository;
using PCL.Repository.Base;

namespace PCL.Phc.Repository
{
    public class CalculatorPaediatricDosageAgeWeightGroupRepository : BaseRepository<CalculatorPaediatricDosageAgeWeightGroup>
    {
        public CalculatorPaediatricDosageAgeWeightGroupRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase) : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorPaediatricDosageAgeWeightGroup> GetByCalculatorPaediatricDrugDosageDrug(Int32 calculatorPaediatricDosageDrugId)
        {
            return this.Table.Where(x => calculatorPaediatricDosageDrugId.Equals(x.DrugId)).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}