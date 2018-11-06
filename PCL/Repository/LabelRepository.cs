using System.Collections.Generic;
using System.Linq;
using PCL.Common;
using PCL.Database;
using PCL.Repository.Base;
using SQLite;

namespace PCL.Repository
{
    public class LabelRepository : BaseRepository<Label>
    {
        public LabelRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase) : base(sqLiteConnectionDatabase)
        {
        }

        public List<Label> Get()
        {
            return this.Table.ToList();
        }
    }
}