using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Database;
using PCL.Repository.Base;
using PCL.Tb.Common;

namespace PCL.Tb.Repository
{
    public class CalculatorAdultIsoniazidePreventiveTherapyRepository : BaseRepository<CalculatorAdultIsoniazidePreventiveTherapy>
    {
        public CalculatorAdultIsoniazidePreventiveTherapyRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
            : base(sqLiteConnectionDatabase)
        {
        }
        
        public List<CalculatorAdultIsoniazidePreventiveTherapy> Get()
        {
            return this.Table.OrderBy(x => x.Id).ToList();
        }

        internal CalculatorAdultIsoniazidePreventiveTherapy Get(Boolean artTreatment, Boolean tstAvailable)
        {
            return this.Table.Where(x => x.ArtTreatment == artTreatment).Where(x => x.TstAvailable == tstAvailable).SingleOrDefault();
        }
    }
}