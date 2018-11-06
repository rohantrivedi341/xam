using PCL.Database;
using PCL.Repository;

namespace PCL.DependencyServices
{
    public interface IDependencyApplicationDatabase
    {
        void Create(SQLiteConnectionDatabase sqLiteConnectionDatabase);
        void Drop(SQLiteConnectionDatabase sqLiteConnectionDatabase);
    }
}