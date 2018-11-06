using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Phc.Common;
using PCL.Repository;
using PCL.Repository.Base;

namespace PCL.Phc.Repository
{
    public class CalculatorIcd10CodesChapterRepository : BaseRepository<CalculatorIcd10CodesChapter>
    {
        public CalculatorIcd10CodesChapterRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase) : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorIcd10CodesChapter> Get()
        {
            return this.Table.OrderBy(x => x.Number).ToList();
        }
    }
}