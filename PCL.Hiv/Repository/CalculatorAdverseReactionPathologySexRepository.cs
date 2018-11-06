using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Hiv.Common;
using PCL.Repository;
using PCL.Repository.Base;
using SQLite;

namespace PCL.Hiv.Repository
{
    public class CalculatorAdverseReactionPathologySexRepository : BaseRepository<CalculatorAdverseReactionPathologySex>
    {
        public CalculatorAdverseReactionPathologySexRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorAdverseReactionPathologySex> Get()
        {
            return this.Table.ToList();
        }
    }
}