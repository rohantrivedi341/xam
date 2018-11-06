using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Repository.Base;
using PCL.Tb.Common;

namespace PCL.Tb.Repository
{
    public class CalculatorAdultDsTbDosageWeightGroupRepository : BaseRepository<CalculatorAdultDsTbDosageWeightGroup>
    {
        public CalculatorAdultDsTbDosageWeightGroupRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }
        
        public List<CalculatorAdultDsTbDosageWeightGroup> GetByCalculatorAdultDsTbDosageDrug(Int32 calculatorAdultDsTbDosageDrug)
        {
            return this.Table.Where(x => calculatorAdultDsTbDosageDrug.Equals(x.DrugId)).OrderBy(x => x.Id).ToList();
        }
    }
}