using System;
using System.Linq;
using PCL.Database;
using PCL.Hiv.Common;
using PCL.Repository;
using PCL.Repository.Base;
using SQLite;

namespace PCL.Hiv.Repository
{
    public class CalculatorAdverseReactionPathologyAgeCategoryRepository : BaseRepository<CalculatorAdverseReactionPathologyAgeCategory>
    {
        public CalculatorAdverseReactionPathologyAgeCategoryRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }

        public CalculatorAdverseReactionPathologyAgeCategory GetByCalculatorAdverseReactionPathologyParameterAndDaysBorn(Int32 calculatorAdverseReactionPathologyParameterId, Int32 daysBorn)
        {
            return this.Table.Where(x => calculatorAdverseReactionPathologyParameterId.Equals(x.ParameterId)).Where(x => daysBorn >= x.StartDay).Where(x => daysBorn <= x.EndDay).SingleOrDefault();
        }
    }
}