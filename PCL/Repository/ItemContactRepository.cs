using System;
using PCL.Common;
using PCL.Database;
using PCL.Repository.Base;
using SQLite;

namespace PCL.Repository
{
    public class ItemContactRepository : BaseRepository<ItemContact>
    {
        public ItemContactRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase) : base(sqLiteConnectionDatabase)
        {
        }

        public ItemContact GetByStructureItem(Int32 structureItemId)
        {
            return this.Table.Where(x => structureItemId.Equals(x.StructureItemId)).FirstOrDefault();
        }
    }
}