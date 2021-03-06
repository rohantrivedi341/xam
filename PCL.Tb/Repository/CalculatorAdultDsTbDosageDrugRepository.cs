﻿using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Repository.Base;
using PCL.Tb.Common;

namespace PCL.Tb.Repository
{
    public class CalculatorAdultDsTbDosageDrugRepository : BaseRepository<CalculatorAdultDsTbDosageDrug>
    {
        public CalculatorAdultDsTbDosageDrugRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorAdultDsTbDosageDrug> GetByCalculatorAdultDsTbPhase(Int32 calculatorAdultDsTbPhase)
        {
            return this.Table.Where(x => calculatorAdultDsTbPhase.Equals(x.PhaseId)).OrderBy(x => x.Id).ToList();
        }
    }
}