using PCL.Common;
using PCL.Database;
using PCL.Repository;
using PCL.Services;

namespace PCL.DependencyServices
{
    public interface IDependencyApplicationUpdateContent
    {
        void Initialize(UpdateContentService updateContent);
        void Save(SQLiteConnectionDatabase sqLiteConnectionDatabase);
        void AddSections();
        void ProcessCalculator(Section section, ItemCalculator itemCalculatorBase);
    }
}