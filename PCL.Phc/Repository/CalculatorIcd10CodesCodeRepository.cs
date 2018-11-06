using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Phc.Common;
using PCL.Repository;
using PCL.Repository.Base;

namespace PCL.Phc.Repository
{
    public class CalculatorIcd10CodesCodeRepository : BaseRepository<CalculatorIcd10CodesCode>
    {
        public CalculatorIcd10CodesCodeRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase) : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorIcd10CodesCode> Get()
        {
            return this.Table.OrderBy(x => x.Code).ToList();
        }

        public CalculatorIcd10CodesCode GetByCode(String code)
        {
            return this.Table.Where(x => code.Equals(x.Code)).SingleOrDefault();
        }

        public List<CalculatorIcd10CodesCode> GetParents(Int32 chapter, String block)
        {
            return this.Table.Where(x => chapter.Equals(x.Chapter)).Where(x => block.Equals(x.Block)).ToList().Where(x => x.Code.Length == 3).OrderBy(x => x.Code).ToList();
        }

        public List<CalculatorIcd10CodesCode> GetChildren(Int32 chapter, String block, String code)
        {
            return this.Table.Where(x => chapter.Equals(x.Chapter)).Where(x => block.Equals(x.Block)).ToList().Where(x => x.Code.Length > 3).Where(x => x.Code.StartsWith(code)).OrderBy(x => x.Code).ToList();
        }
    }
}