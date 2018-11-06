using System;
using PCL.Database;
using PCL.DependencyServices;
using PCL.DohReporting.Common;
using PCL.DohReporting.DependencyServices;
using PCL.Repository;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyApplicationDohReportingDatabase))]

namespace PCL.DohReporting.DependencyServices
{
    public class DependencyApplicationDohReportingDatabase : IDependencyApplicationDatabase
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