using System;
using System.Collections.Generic;
using PCL.Common;
using PCL.Common.Enum;
using PCL.Database;
using PCL.DependencyServices;
using PCL.Msf.Common;
using PCL.Msf.DependencyServices;
using PCL.Msf.Repository;
using PCL.Repository;
using PCL.Services;
using Xamarin.Forms;
using ItemCalculator = PCL.Msf.Common.ItemCalculator;

[assembly: Dependency(typeof (DependencyApplicationMsfUpdateContent))]

namespace PCL.Msf.DependencyServices
{
    public class DependencyApplicationMsfUpdateContent : IDependencyApplicationUpdateContent
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
            this.UpdateContent.Sections.Add(new Section(this.UpdateContent.SectionId, SectionType.Pages, "Guidelines", "Guidelines", "tab_guidelines.png", "guidelines", true));
            this.UpdateContent.SectionId++;
            this.UpdateContent.Sections.Add(new Section(this.UpdateContent.SectionId, SectionType.Pages, "Drugs", "Drugs", "tab_drugs.png", "drugs", true));
            this.UpdateContent.SectionId++;
            this.UpdateContent.Sections.Add(new Section(this.UpdateContent.SectionId, SectionType.Directory, "Directory", "Directory", "tab_directory.png", "directory", true));
            this.UpdateContent.SectionId++;
            this.UpdateContent.Sections.Add(new Section(this.UpdateContent.SectionId, SectionType.Pages, "Policies", "Policies", "tab_folder.png", "policies", true));
            this.UpdateContent.SectionId++;
            this.UpdateContent.Sections.Add(new Section(this.UpdateContent.SectionId, SectionType.Calculators, "Referrals", "Referrals", "tab_calculators.png", "referrals", true));
            this.UpdateContent.SectionId++;
            this.UpdateContent.Sections.Add(new Section(this.UpdateContent.SectionId, SectionType.SpecialPages, "Special Pages", "Special Pages", String.Empty, "pages", false));
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
                case ItemCalculatorType.Telemedicine:
                    this.UpdateContent.ProcessItemCalculatorUrl(itemCalculator, itemCalculator.Url);

                    break;
            }
        }
    }
}