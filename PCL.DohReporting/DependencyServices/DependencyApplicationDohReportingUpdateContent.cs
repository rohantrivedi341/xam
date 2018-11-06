using System;
using System.Collections.Generic;
using PCL.Common;
using PCL.Common.Enum;
using PCL.Database;
using PCL.DependencyServices;
using PCL.DohReporting.Common;
using PCL.DohReporting.DependencyServices;
using PCL.DohReporting.Repository;
using PCL.Repository;
using PCL.Services;
using SQLite;
using Xamarin.Forms;
using ItemCalculator = PCL.DohReporting.Common.ItemCalculator;

[assembly: Dependency(typeof (DependencyApplicationDohReportingUpdateContent))]

namespace PCL.DohReporting.DependencyServices
{
    public class DependencyApplicationDohReportingUpdateContent : IDependencyApplicationUpdateContent
    {
        public UpdateContentService UpdateContent;

        public List<ItemCalculator> ItemCalculators = new List<ItemCalculator>();

        public void Initialize(UpdateContentService updateContent)
        {
            this.UpdateContent = updateContent;
        }

        public void Save(SQLiteConnectionDatabase sqLiteConnectionDatabase)
        {
            new ItemCalculatorRepository(sqLiteConnectionDatabase).Save(this.ItemCalculators);
        }

        public void AddSections()
        {
            this.UpdateContent.Sections.Add(new Section(this.UpdateContent.SectionId, SectionType.Calculators, "Public", "Public", "tab_guidelines.png", "public", true));
            this.UpdateContent.SectionId++;
            this.UpdateContent.Sections.Add(new Section(this.UpdateContent.SectionId, SectionType.Calculators, "Health workers", "Health workers", "tab_guidelines.png", "health-workers", true));
            this.UpdateContent.SectionId++;
        }

        public void ProcessCalculator(Section section, PCL.Common.ItemCalculator itemCalculatorBase)
        {
            ItemCalculator itemCalculator = new ItemCalculator(itemCalculatorBase);

            ItemCalculatorType itemCalculatorType = ItemCalculator.IdentifyType(itemCalculator.Identifier);

            if (itemCalculatorType == ItemCalculatorType.Unknown)
            {
                return;
            }

            itemCalculator.Type = itemCalculatorType;

            this.ItemCalculators.Add(itemCalculator);

            switch (itemCalculatorType)
            {
                case ItemCalculatorType.DrugStockOut_Public:
                    this.UpdateContent.ProcessItemCalculatorFolder(itemCalculator, itemCalculator.Folder);

                    break;
                case ItemCalculatorType.DrugStockOut_HealthWorker:
                    this.UpdateContent.ProcessItemCalculatorFolder(itemCalculator, itemCalculator.Folder);

                    break;
            }
        }
    }
}