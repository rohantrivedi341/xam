using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Phc.Common;
using PCL.Repository;
using PCL.Repository.Base;

namespace PCL.Phc.Repository
{
    public class CalculatorIcd10CodesBlockRepository : BaseRepository<CalculatorIcd10CodesBlock>
    {
        public CalculatorIcd10CodesBlockRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase) : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorIcd10CodesBlock> Get(Int32 chapter)
        {
            return this.Table.Where(x => chapter.Equals(x.Chapter)).OrderBy(x => x.Number).ToList();
        }

        public CalculatorIcd10CodesBlock GetByNumber(string block)
        {
            return this.Table.Where(x => block.Equals(x.Number)).SingleOrDefault();
        }
    }
}