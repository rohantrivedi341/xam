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
    public class CalculatorArvRenalDosageDosageItemRepository : BaseRepository<CalculatorArvRenalDosageDosageItem>
    {
        public CalculatorArvRenalDosageDosageItemRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorArvRenalDosageDosageItem> GetByCalculatorArvRenalDosageDosage(Int32 calculatorArvRenalDosageDosageDosageId)
        {
            return this.Table.Where(x => calculatorArvRenalDosageDosageDosageId.Equals(x.DosageId)).OrderBy(x => x.Id).ToList();
        }
    }
}