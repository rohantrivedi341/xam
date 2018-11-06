using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Common;
using PCL.Database;
using PCL.Repository.Base;
using SQLite;

namespace PCL.Repository
{
    public class StructureItemRepository : BaseRepository<StructureItem>
    {
        public StructureItemRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase) : base(sqLiteConnectionDatabase)
        {
        }

        public StructureItem GetByUuid(Guid uuid)
        {
            return this.Table.Where(x => uuid.Equals(x.Uuid)).SingleOrDefault();
        }
        
        public List<StructureItem> GetBySection(Int32 sectionId)
        {
            return this.Table.Where(x => sectionId.Equals(x.SectionId)).Where(x => x.ParentId == null).OrderBy(x => x.DisplayOrder).ThenBy(x => x.Title).ToList();
        }

        public List<StructureItem> GetByParent(Int32 parentId)
        {
            return this.Table.Where(x => parentId.Equals(x.ParentId)).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}