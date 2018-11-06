using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Hiv.Common;
using PCL.Repository;
using PCL.Repository.Base;
using SQLite;

namespace PCL.Hiv.Repository
{
    public class CalculatorPaediatricArvDosageWeightGroupRepository : BaseRepository<CalculatorPaediatricArvDosageWeightGroup>
    {
        public CalculatorPaediatricArvDosageWeightGroupRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorPaediatricArvDosageWeightGroup> GetByCalculatorPaedatircArvDosageArv(Int32 calculatorPaedatircArvDosageArvId)
        {
            return this.Table.Where(x => calculatorPaedatircArvDosageArvId.Equals(x.ArvId)).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}