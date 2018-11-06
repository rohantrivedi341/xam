using System;
using System.Linq;
using PCL.Database;
using PCL.Hiv.Common;
using PCL.Repository;
using PCL.Repository.Base;
using SQLite;

namespace PCL.Hiv.Repository
{
    public class ItemCalculatorRepository : BaseRepository<ItemCalculator>
    {
        public ItemCalculatorRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }

        public ItemCalculator Get(String identifier)
        {
            return this.Table.Where(x => identifier.Equals(x.Identifier)).SingleOrDefault();
        }

        public ItemCalculator GetByStructureItem(Int32 structureItemId)
        {
            return this.Table.Where(x => structureItemId.Equals(x.StructureItemId)).SingleOrDefault();
        }
    }
}