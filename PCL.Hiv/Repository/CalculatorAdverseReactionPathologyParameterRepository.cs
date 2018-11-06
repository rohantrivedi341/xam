using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Hiv.Common;
using PCL.Repository;
using PCL.Repository.Base;
using SQLite;

namespace PCL.Hiv.Repository
{
    public class CalculatorAdverseReactionPathologyParameterRepository : BaseRepository<CalculatorAdverseReactionPathologyParameter>
    {
        public CalculatorAdverseReactionPathologyParameterRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }

        public List<CalculatorAdverseReactionPathologyParameter> Get()
        {
            return this.Table.ToList();
        }
    }
}