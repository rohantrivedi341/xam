using System;
using System.Linq;
using PCL.Database;
using PCL.Phc.Common;
using PCL.Repository;
using PCL.Repository.Base;

namespace PCL.Phc.Repository
{
    public class ItemCalculatorRepository : BaseRepository<ItemCalculator>
    {
        public ItemCalculatorRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase) : base(sqLiteConnectionDatabase)
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