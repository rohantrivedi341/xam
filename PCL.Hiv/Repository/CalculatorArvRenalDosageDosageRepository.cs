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
    public class CalculatorArvRenalDosageDosageRepository : BaseRepository<CalculatorArvRenalDosageDosage>
    {
        public CalculatorArvRenalDosageDosageRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorArvRenalDosageDosage> GetByCalculatorArvRenalDosageArv(Int32 calculatorArvRenalDosageDosageArvId)
        {
            return this.Table.Where(x => calculatorArvRenalDosageDosageArvId.Equals(x.ArvId)).OrderBy(x => x.TypeValue).ToList();
        }
    }
}