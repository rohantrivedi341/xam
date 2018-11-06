using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Repository.Base;
using PCL.Tb.Common;

namespace PCL.Tb.Repository
{
    public class CalculatorBmiRepository : BaseRepository<CalculatorBmi>
    {
        public CalculatorBmiRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorBmi> Get()
        {
            return this.Table.OrderBy(x => x.Id).ToList();
        }

        public CalculatorBmi GetByResult(Double result)
        {
            return this.Table.Where(x => (x.ValueStart == null && result <= x.ValueEnd)
                                         ||
                                         (result >= x.ValueStart && result <= x.ValueEnd)
                                         ||
                                         (result >= x.ValueStart && x.ValueEnd == null)
                ).SingleOrDefault();
        }
    }
}