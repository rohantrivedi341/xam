using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCL.Common.Interface;
using PCL.Database;
using SQLite;

namespace PCL.Repository.Base
{
    public class BaseRepository<T> where T : IEntity, new()
    {
        public SQLiteConnectionDatabase SqLiteConnectionDatabase;

        public BaseRepository(SQLiteConnectionDatabase sqLiteConnectionDatabase)
        {
            this.SqLiteConnectionDatabase = sqLiteConnectionDatabase;
        }

        public TableQuery<T> Table => this.SqLiteConnectionDatabase.Table<T>();

        public T Get(Int32 id)
        {
            return this.Table.Where(x => id.Equals(x.Id)).SingleOrDefault();
        }

        public void Save(T item)
        {
            this.SqLiteConnectionDatabase.Insert(item);
        }

        public void Save(IEnumerable<T> items)
        {
            this.SqLiteConnectionDatabase.InsertAll(items);
        }

        public void Delete(T item)
        {
            this.SqLiteConnectionDatabase.Delete(item);
        }
    }
}
