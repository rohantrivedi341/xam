using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Common;
using PCL.Database;
using PCL.Repository.Base;
using SQLite;

namespace PCL.Repository
{
    public class ItemPageRepository : BaseRepository<ItemPage>
    {
        public ItemPageRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase) : base(sqLiteConnectionDatabase)
        {
        }

        public ItemPage Get(String fileName)
        {
            return this.Table.ToList().Where(x => fileName.Equals(x.FileName)).SingleOrDefault();
        }

        public List<ItemPage> GetByStructureItem(Int32 structureItemId)
        {
            return this.Table.Where(x => structureItemId.Equals(x.StructureItemId)).ToList();
        }
    }
}