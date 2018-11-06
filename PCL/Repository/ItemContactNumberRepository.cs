using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Common;
using PCL.Database;
using PCL.Repository.Base;
using SQLite;

namespace PCL.Repository
{
    public class ItemContactNumberRepository : BaseRepository<ItemContactNumber>
    {
        public ItemContactNumberRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase) : base(sqLiteConnectionDatabase)
        {
        }

        public List<ItemContactNumber> GetByItemContact(Int32 itemContactId)
        {
            return this.Table.Where(x => itemContactId.Equals(x.ItemContactId)).OrderBy(x => x.Title).ToList();
        }
    }
}