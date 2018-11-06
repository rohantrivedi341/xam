using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Common;
using PCL.Database;
using PCL.Repository.Base;
using SQLite;

namespace PCL.Repository
{
    public class FavoriteRepository : BaseRepository<Favorite>
    {
        public FavoriteRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase) : base(sqLiteConnectionDatabase)
        {
        }

        public List<Favorite> Get()
        {
            return this.Table.OrderBy(x => x.Title).ToList();
        }

        public Favorite GetByUuid(Guid uuid)
        {
            return this.Table.Where(x => uuid.Equals(x.Uuid)).SingleOrDefault();
        }
    }
}