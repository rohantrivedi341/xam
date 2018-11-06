using System;
using PCL.Common;
using PCL.Database;
using PCL.Repository.Base;
using SQLite;

namespace PCL.Repository
{
    public class ItemCalculatorLinkRepository : BaseRepository<ItemCalculatorLink>
    {
        public ItemCalculatorLinkRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase) : base(sqLiteConnectionDatabase)
        {
        }

        public ItemCalculatorLink GetByItemCalculator(Int32 itemCalculatorId)
        {
            return this.Table.Where(x => itemCalculatorId.Equals(x.ItemCalculatorId)).FirstOrDefault();
        }
    }
}