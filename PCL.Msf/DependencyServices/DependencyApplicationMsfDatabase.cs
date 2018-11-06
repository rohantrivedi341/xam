using PCL.Database;
using PCL.DependencyServices;
using PCL.Msf.Common;
using PCL.Msf.DependencyServices;
using PCL.Repository;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyApplicationMsfDatabase))]

namespace PCL.Msf.DependencyServices
{
    public class DependencyApplicationMsfDatabase : IDependencyApplicationDatabase
    {
        public void Create(SQLiteConnectionDatabase sqLiteConnectionDatabase)
        {
            sqLiteConnectionDatabase.CreateTable<ItemCalculator>();
        }
        
        public void Drop(SQLiteConnectionDatabase sqLiteConnectionDatabase)
        {
            sqLiteConnectionDatabase.DropTable<ItemCalculator>();
        }
    }
}