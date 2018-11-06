using System.Collections.Generic;
using System.Linq;
using PCL.Common;
using PCL.Common.Enum;
using PCL.Database;
using PCL.Repository.Base;
using SQLite;

namespace PCL.Repository
{
    public class SectionRepository : BaseRepository<Section>
    {
        public SectionRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase) : base(sqLiteConnectionDatabase)
        {
        }

        public List<Section> GetDisplayedInMenu()
        {
            return this.Table.Where(x => x.DisplayInMenu).OrderBy(x => x.Id).ToList();
        }

        public Section GetFavoriteSection()
        {
            return this.Table.Where(x => x.Type == SectionType.Favorites).SingleOrDefault();
        }
    }
}