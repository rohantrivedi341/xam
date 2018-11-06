using System.Collections.Generic;
using System.Linq;
using PCL.Common;
using PCL.Common.Enum;
using PCL.Database;
using PCL.Repository.Base;
using SQLite;

namespace PCL.Repository
{
    public class SpecialPageRepository : BaseRepository<SpecialPage>
    {
        public SpecialPageRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase) : base(sqLiteConnectionDatabase)
        {
        }

        public List<SpecialPage> Get ()
        {
            return this.Table.ToList();
        }
        
        public SpecialPage GetByType(SpecialPageType specialPageType)
        {
            return this.Table.Where(x => x.Type == specialPageType).SingleOrDefault();
        }
    }
}