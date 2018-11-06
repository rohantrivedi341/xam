using System;
using PCL.Common;
using SQLite;

namespace PCL.Database
{
    public class SQLiteConnectionDatabase : SQLiteConnection
    {
        public SQLiteConnectionDatabase(String dbPath) : base(dbPath)
        {

        }

        public static SQLiteConnectionDatabase NewConnection()
        {
            return new SQLiteConnectionDatabase(App.CurrentInstance.DependencyPlatformGeneral.GetDbPath());
        }

        public void Recreate()
        {
            this.Drop();
            this.Create();
        }

        public void Create()
        {
            this.CreateTable<Section>();
            this.CreateTable<StructureItem>();
            this.CreateTable<ItemPage>();
            this.CreateTable<ItemContact>();
            this.CreateTable<ItemContactNumber>();
            this.CreateTable<ItemCalculatorLink>();
            this.CreateTable<Label>();
            this.CreateTable<Favorite>();
            this.CreateTable<SpecialPage>();

            App.CurrentInstance.DependencyApplicationDatabase.Create(this);
        }

        public void Drop()
        {
            this.DropTable<Section>();
            this.DropTable<StructureItem>();
            this.DropTable<ItemPage>();
            this.DropTable<ItemContact>();
            this.DropTable<ItemContactNumber>();
            this.DropTable<ItemCalculatorLink>();
            this.DropTable<Label>();
            this.DropTable<Favorite>();
            this.DropTable<SpecialPage>();
            
            App.CurrentInstance.DependencyApplicationDatabase.Drop(this);
        }
    }
}