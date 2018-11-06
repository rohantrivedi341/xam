using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using PCL.Common;
using PCL.Common.Enum;
using PCL.Database;
using PCL.DependencyServices;
using PCL.Services;
using PCL.Tb.Common;
using PCL.Tb.DependencyServices;
using PCL.Tb.Repository;
using Xamarin.Forms;
using ItemCalculator = PCL.Tb.Common.ItemCalculator;

[assembly: Dependency(typeof(DependencyApplicationTbUpdateContent))]

namespace PCL.Tb.DependencyServices
{
    public class DependencyApplicationTbUpdateContent : IDependencyApplicationUpdateContent
    {
        public UpdateContentService UpdateContent;

        public Int32 CalculatorAdultDsTbDosageDrugId = 1;
        public Int32 CalculatorAdultDsTbDosagePhaseId = 1;
        public Int32 CalculatorAdultDsTbDosageWeightGroupId = 1;
        public Int32 CalculatorAdultIsoniazidePreventiveTherapyId = 1;
        public Int32 CalculatorAdultIsoniazidePreventiveTherapySizeId = 1;
        public Int32 CalculatorPaediatricDsTbDosageCategoryId = 1;
        public Int32 CalculatorPaediatricDsTbDosagePhaseId = 1;
        public Int32 CalculatorPaediatricDsTbDosageWeightGroupId = 1;
        public Int32 CalculatorPaediatricIsoniazidePreventiveTherapyId = 1;
        public Int32 CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroupId = 1;
        public Int32 CalculatorBmiId = 1;
        public Int32 CalculatorTbTreatmentFollowUpDateId;
        public Int32 CalculatorMdrTreatmentFollowUpDateId;
        public Int32 CalculatorDrugInteractionInteractionId = 1;

        public List<ItemCalculator> ItemCalculators = new List<ItemCalculator>();

        public List<CalculatorAdultDsTbDosageDrug> CalculatorAdultDsTbDosageDrugs = new List<CalculatorAdultDsTbDosageDrug>();
        public List<CalculatorAdultDsTbDosagePhase> CalculatorAdultDsTbDosagePhases = new List<CalculatorAdultDsTbDosagePhase>();
        public List<CalculatorAdultDsTbDosageWeightGroup> CalculatorAdultDsTbDosageWeightGroups = new List<CalculatorAdultDsTbDosageWeightGroup>();
        public List<CalculatorAdultIsoniazidePreventiveTherapy> CalculatorAdultIsoniazidePreventiveTherapies = new List<CalculatorAdultIsoniazidePreventiveTherapy>();
        public List<CalculatorAdultIsoniazidePreventiveTherapySize> CalculatorAdultIsoniazidePreventiveTherapySizes = new List<CalculatorAdultIsoniazidePreventiveTherapySize>();
        public List<CalculatorPaediatricDsTbDosageCategory> CalculatorPaediatricDsTbDosageCategories = new List<CalculatorPaediatricDsTbDosageCategory>();
        public List<CalculatorPaediatricDsTbDosagePhase> CalculatorPaediatricDsTbDosagePhases = new List<CalculatorPaediatricDsTbDosagePhase>();
        public List<CalculatorPaediatricDsTbDosageWeightGroup> CalculatorPaediatricDsTbDosageWeightGroups = new List<CalculatorPaediatricDsTbDosageWeightGroup>();
        public List<CalculatorPaediatricIsoniazidePreventiveTherapy> CalculatorPaediatricIsoniazidePreventiveTherapies = new List<CalculatorPaediatricIsoniazidePreventiveTherapy>();
        public List<CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup> CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroups = new List<CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup>();
        public List<CalculatorBmi> CalculatorBmis = new List<CalculatorBmi>();
        public List<CalculatorTbTreatmentFollowUpDate> CalculatorTbTreatmentFollowUpDates = new List<CalculatorTbTreatmentFollowUpDate>();
        public List<CalculatorMdrTreatmentFollowUpDate> CalculatorMdrTreatmentFollowUpDates = new List<CalculatorMdrTreatmentFollowUpDate>();
        public List<CalculatorDrugInteractionArv> CalculatorDrugInteractionArvs = new List<CalculatorDrugInteractionArv>();
        public List<CalculatorDrugInteractionEdl> CalculatorDrugInteractionEdls = new List<CalculatorDrugInteractionEdl>();
        public List<CalculatorDrugInteractionInteraction> CalculatorDrugInteractionInteractions = new List<CalculatorDrugInteractionInteraction>();


        public void Initialize(UpdateContentService updateContent)
        {
            this.UpdateContent = updateContent;
        }

        public void Save(SQLiteConnectionDatabase sqLiteConnectionDatabase)
        {
            new ItemCalculatorRepository(sqLiteConnectionDatabase).Save(this.ItemCalculators);
            new CalculatorAdultDsTbDosageDrugRepository(sqLiteConnectionDatabase).Save(this.CalculatorAdultDsTbDosageDrugs);
            new CalculatorAdultDsTbDosagePhaseRepository(sqLiteConnectionDatabase).Save(this.CalculatorAdultDsTbDosagePhases);
            new CalculatorAdultDsTbDosageWeightGroupRepository(sqLiteConnectionDatabase).Save(this.CalculatorAdultDsTbDosageWeightGroups);
            new CalculatorAdultIsoniazidePreventiveTherapyRepository(sqLiteConnectionDatabase).Save(this.CalculatorAdultIsoniazidePreventiveTherapies);
            new CalculatorAdultIsoniazidePreventiveTherapySizeRepository(sqLiteConnectionDatabase).Save(this.CalculatorAdultIsoniazidePreventiveTherapySizes);
            new CalculatorPaediatricDsTbDosageCategoryRepository(sqLiteConnectionDatabase).Save(this.CalculatorPaediatricDsTbDosageCategories);
            new CalculatorPaediatricDsTbDosagePhaseRepository(sqLiteConnectionDatabase).Save(this.CalculatorPaediatricDsTbDosagePhases);
            new CalculatorPaediatricDsTbDosageWeightGroupRepository(sqLiteConnectionDatabase).Save(this.CalculatorPaediatricDsTbDosageWeightGroups);
            new CalculatorPaediatricIsoniazidePreventiveTherapyRepository(sqLiteConnectionDatabase).Save(this.CalculatorPaediatricIsoniazidePreventiveTherapies);
            new CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroupRepository(sqLiteConnectionDatabase).Save(this.CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroups);
            new CalculatorBmiRepository(sqLiteConnectionDatabase).Save(this.CalculatorBmis);
            new CalculatorTbTreatmentFollowUpDateRepository(sqLiteConnectionDatabase).Save(this.CalculatorTbTreatmentFollowUpDates);
            new CalculatorMdrTreatmentFollowUpDateRepository(sqLiteConnectionDatabase).Save(this.CalculatorMdrTreatmentFollowUpDates);
            new CalculatorDrugInteractionArvRepository(sqLiteConnectionDatabase).Save(this.CalculatorDrugInteractionArvs);
            new CalculatorDrugInteractionEdlRepository(sqLiteConnectionDatabase).Save(this.CalculatorDrugInteractionEdls);
            new CalculatorDrugInteractionInteractionRepository(sqLiteConnectionDatabase).Save(this.CalculatorDrugInteractionInteractions);
        }

        public void AddSections()
        {
            this.UpdateContent.Sections.Add(new Section(this.UpdateContent.SectionId, SectionType.Pages, "Guidelines", "Guidelines", "tab_guidelines.png", "guidelines", true));
            this.UpdateContent.SectionId++;
            this.UpdateContent.Sections.Add(new Section(this.UpdateContent.SectionId, SectionType.Pages, "Medicines", "Medicines", "tab_drugs.png", "drugs", true));
            this.UpdateContent.SectionId++;
            this.UpdateContent.Sections.Add(new Section(this.UpdateContent.SectionId, SectionType.Calculators, "Calculators", "Calculators", "tab_calculators.png", "calculators", true));
            this.UpdateContent.SectionId++;
            this.UpdateContent.Sections.Add(new Section(this.UpdateContent.SectionId, SectionType.Directory, "Directory", "Directory", "tab_directory.png", "directory", true));
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
                case ItemCalculatorType.AdultDsTbDosages:
                    this.ProcessCalculatorAdultDsTbDosages(section, itemCalculator.FileName);
                    break;
                case ItemCalculatorType.AdultIsoniazidePreventiveTherapy:
                    this.ProcessCalculatorAdultIsoniazidePreventiveTherapies(section, itemCalculator.FileName);
                    break;
                case ItemCalculatorType.PaediatricDsTbDosages:
                    this.ProcessCalculatorPaediatricDsTbDosages(section, itemCalculator.FileName);
                    break;
                case ItemCalculatorType.PaediatricIsoniazidePreventiveTherapy:
                    this.ProcessCalculatorPaediatricIsoniazidePreventiveTherapies(section, itemCalculator.FileName);
                    break;
                case ItemCalculatorType.Bmi:
                    this.ProcessCalculatorBmi(section, itemCalculator.FileName);
                    break;
                case ItemCalculatorType.TbTreatmentFollowUpDates:
                    this.ProcessCalculatorTbTreatmentFollowUpDates(section, itemCalculator.FileName);
                    break;
                case ItemCalculatorType.MdrTreatmentFollowUpDates:
                    this.ProcessCalculatorMdrTreatmentFollowUpDates(section, itemCalculator.FileName);
                    break;
                case ItemCalculatorType.DrugInteraction:
                    this.ProcessCalculatorDrugInteraction(section, itemCalculator.FileName);
                    break;
                case ItemCalculatorType.DrugStockOut:
                    this.UpdateContent.ProcessItemCalculatorFolder(itemCalculator, itemCalculator.Folder);
                    break;
                case ItemCalculatorType.SuspectedAdverseDrugReaction:
                    this.UpdateContent.ProcessItemCalculatorFolder(itemCalculator, itemCalculator.Folder);

                    break;
            }
        }

        public void ProcessCalculatorAdultDsTbDosages(Section section, String fileName)
        {
            JArray jsonAdultDsTbDosagePhases = JArray.Parse(this.UpdateContent.GetSectionFile(section.Location, fileName));

            for (int indexAdultDsTbDosagePhases = 0; indexAdultDsTbDosagePhases < jsonAdultDsTbDosagePhases.Count; indexAdultDsTbDosagePhases++)
            {
                JObject jsonAdultDsTbPhase = jsonAdultDsTbDosagePhases[indexAdultDsTbDosagePhases].ToObject<JObject>();

                CalculatorAdultDsTbDosagePhase adultDsTbDosagePhase = new CalculatorAdultDsTbDosagePhase(this.CalculatorAdultDsTbDosagePhaseId, jsonAdultDsTbPhase.GetValue("title").Value<String>());

                this.CalculatorAdultDsTbDosagePhases.Add(adultDsTbDosagePhase);
                this.CalculatorAdultDsTbDosagePhaseId++;

                if (jsonAdultDsTbPhase.Property("drugs") != null && jsonAdultDsTbPhase.GetValue("drugs") is JArray)
                {
                    JArray jsonAdultDsTbDosageDrugs = jsonAdultDsTbPhase.GetValue("drugs").Value<JArray>();

                    for (int indexAdultDsTbDosageDrugs = 0; indexAdultDsTbDosageDrugs < jsonAdultDsTbDosageDrugs.Count; indexAdultDsTbDosageDrugs++)
                    {
                        JObject jsonAdultDsTbDrug = jsonAdultDsTbDosageDrugs[indexAdultDsTbDosageDrugs].ToObject<JObject>();

                        CalculatorAdultDsTbDosageDrug adultDsTbDosageDrug = new CalculatorAdultDsTbDosageDrug(this.CalculatorAdultDsTbDosageDrugId, adultDsTbDosagePhase.Id, jsonAdultDsTbDrug.GetValue("title").Value<String>(), jsonAdultDsTbDrug.GetValue("target_dose").Value<String>(), jsonAdultDsTbDrug.GetValue("available_formulations").Value<String>());

                        this.CalculatorAdultDsTbDosageDrugs.Add(adultDsTbDosageDrug);
                        this.CalculatorAdultDsTbDosageDrugId++;

                        if (jsonAdultDsTbDrug.Property("weight_groups") != null && jsonAdultDsTbDrug.GetValue("weight_groups") is JArray)
                        {
                            JArray jsonAdultDsTbDosageWeightGroups = jsonAdultDsTbDrug.GetValue("weight_groups").Value<JArray>();

                            for (int indexAdultDsTbDosageWeightGroups = 0; indexAdultDsTbDosageWeightGroups < jsonAdultDsTbDosageWeightGroups.Count; indexAdultDsTbDosageWeightGroups++)
                            {
                                JObject jsonWeightGroup = jsonAdultDsTbDosageWeightGroups[indexAdultDsTbDosageWeightGroups].ToObject<JObject>();

                                CalculatorAdultDsTbDosageWeightGroup adultDsTbDosageWeightGroup = new CalculatorAdultDsTbDosageWeightGroup(this.CalculatorAdultDsTbDosageWeightGroupId, adultDsTbDosageDrug.Id, jsonWeightGroup.GetValue("title").Value<String>(), jsonWeightGroup.GetValue("dosage").Value<String>());

                                this.CalculatorAdultDsTbDosageWeightGroups.Add(adultDsTbDosageWeightGroup);
                                this.CalculatorAdultDsTbDosageWeightGroupId++;
                            }
                        }
                    }
                }
            }
        }

        public void ProcessCalculatorAdultIsoniazidePreventiveTherapies(Section section, String fileName)
        {
            JArray jsonAdultIsoniazidePreventiveTherapies = JArray.Parse(this.UpdateContent.GetSectionFile(section.Location, fileName));

            for (int indexAdultIsoniazidePreventiveTherapies = 0; indexAdultIsoniazidePreventiveTherapies < jsonAdultIsoniazidePreventiveTherapies.Count; indexAdultIsoniazidePreventiveTherapies++)
            {
                JObject jsonAdultIsoniazidePreventiveTherapy = jsonAdultIsoniazidePreventiveTherapies[indexAdultIsoniazidePreventiveTherapies].ToObject<JObject>();

                CalculatorAdultIsoniazidePreventiveTherapy adultIsoniazidePreventiveTherapy = new CalculatorAdultIsoniazidePreventiveTherapy(this.CalculatorAdultIsoniazidePreventiveTherapyId, jsonAdultIsoniazidePreventiveTherapy.GetValue("on_art").Value<Boolean>(), jsonAdultIsoniazidePreventiveTherapy.GetValue("tst_available").Value<Boolean>());

                if (jsonAdultIsoniazidePreventiveTherapy.Property("management") != null)
                {
                    adultIsoniazidePreventiveTherapy.Management = jsonAdultIsoniazidePreventiveTherapy.GetValue("management").Value<String>();
                }

                this.CalculatorAdultIsoniazidePreventiveTherapies.Add(adultIsoniazidePreventiveTherapy);
                this.CalculatorAdultIsoniazidePreventiveTherapyId++;

                if (jsonAdultIsoniazidePreventiveTherapy.Property("sizes") != null && jsonAdultIsoniazidePreventiveTherapy.GetValue("sizes") is JArray)
                {
                    JArray jsonAdultIsoniazidePreventiveSizes = jsonAdultIsoniazidePreventiveTherapy.GetValue("sizes").Value<JArray>();

                    for (int indexAdultIsoniazidePreventiveSizes = 0; indexAdultIsoniazidePreventiveSizes < jsonAdultIsoniazidePreventiveSizes.Count; indexAdultIsoniazidePreventiveSizes++)
                    {
                        JObject jsonAdultIsoniazidePreventiveSize = jsonAdultIsoniazidePreventiveSizes[indexAdultIsoniazidePreventiveSizes].ToObject<JObject>();

                        CalculatorAdultIsoniazidePreventiveTherapySize adultIsoniazidePreventiveTherapySize = new CalculatorAdultIsoniazidePreventiveTherapySize(this.CalculatorAdultIsoniazidePreventiveTherapySizeId, adultIsoniazidePreventiveTherapy.Id, jsonAdultIsoniazidePreventiveSize.GetValue("title").Value<String>(), jsonAdultIsoniazidePreventiveSize.GetValue("management").Value<String>());

                        this.CalculatorAdultIsoniazidePreventiveTherapySizes.Add(adultIsoniazidePreventiveTherapySize);
                        this.CalculatorAdultIsoniazidePreventiveTherapySizeId++;
                    }
                }
            }
        }

        public void ProcessCalculatorPaediatricDsTbDosages(Section section, String fileName)
        {
            JArray jsonPaediatricDsTbCategories = JArray.Parse(this.UpdateContent.GetSectionFile(section.Location, fileName));

            for (int indexPaediatricDsTbDosageCategory = 0; indexPaediatricDsTbDosageCategory < jsonPaediatricDsTbCategories.Count; indexPaediatricDsTbDosageCategory++)
            {
                JObject jsonPaediatricDsTbDosageCategory = jsonPaediatricDsTbCategories[indexPaediatricDsTbDosageCategory].ToObject<JObject>();

                CalculatorPaediatricDsTbDosageCategory paediatricDsTbDosageCategory = new CalculatorPaediatricDsTbDosageCategory(this.CalculatorPaediatricDsTbDosageCategoryId, jsonPaediatricDsTbDosageCategory.GetValue("title").Value<String>());

                if (jsonPaediatricDsTbDosageCategory.Property("available_formulations") != null)
                {
                    paediatricDsTbDosageCategory.AvailableFormulations = jsonPaediatricDsTbDosageCategory.GetValue("available_formulations").Value<String>();
                }

                this.CalculatorPaediatricDsTbDosageCategories.Add(paediatricDsTbDosageCategory);
                this.CalculatorPaediatricDsTbDosageCategoryId++;

                if (jsonPaediatricDsTbDosageCategory.Property("phases") != null && jsonPaediatricDsTbDosageCategory.GetValue("phases") is JArray)
                {
                    JArray jsonPaediatricDsTbDosagePhases = jsonPaediatricDsTbDosageCategory.GetValue("phases").Value<JArray>();

                    for (int indexPaediatricDsTbDosagePhases = 0; indexPaediatricDsTbDosagePhases < jsonPaediatricDsTbDosagePhases.Count; indexPaediatricDsTbDosagePhases++)
                    {
                        JObject jsonPaediatricDsTbPhase = jsonPaediatricDsTbDosagePhases[indexPaediatricDsTbDosagePhases].ToObject<JObject>();

                        CalculatorPaediatricDsTbDosagePhase paediatricDsTbDosagePhase = new CalculatorPaediatricDsTbDosagePhase(this.CalculatorPaediatricDsTbDosagePhaseId, paediatricDsTbDosageCategory.Id, jsonPaediatricDsTbPhase.GetValue("title").Value<String>(), jsonPaediatricDsTbPhase.GetValue("available_formulations").Value<String>());

                        this.CalculatorPaediatricDsTbDosagePhases.Add(paediatricDsTbDosagePhase);
                        this.CalculatorPaediatricDsTbDosagePhaseId++;

                        if (jsonPaediatricDsTbPhase.Property("weight_groups") != null && jsonPaediatricDsTbPhase.GetValue("weight_groups") is JArray)
                        {
                            JArray jsonPaediatricDsTbDosageWeightGroups = jsonPaediatricDsTbPhase.GetValue("weight_groups").Value<JArray>();

                            for (int indexPaediatricDsTbDosageWeightGroups = 0; indexPaediatricDsTbDosageWeightGroups < jsonPaediatricDsTbDosageWeightGroups.Count; indexPaediatricDsTbDosageWeightGroups++)
                            {
                                JObject jsonWeightGroup = jsonPaediatricDsTbDosageWeightGroups[indexPaediatricDsTbDosageWeightGroups].ToObject<JObject>();

                                CalculatorPaediatricDsTbDosageWeightGroup paediatricDsTbDosageWeightGroup = new CalculatorPaediatricDsTbDosageWeightGroup(this.CalculatorPaediatricDsTbDosageWeightGroupId, jsonWeightGroup.GetValue("title").Value<String>(), jsonWeightGroup.GetValue("dosage").Value<String>());

                                paediatricDsTbDosageWeightGroup.PhaseId = paediatricDsTbDosagePhase.Id;

                                this.CalculatorPaediatricDsTbDosageWeightGroups.Add(paediatricDsTbDosageWeightGroup);
                                this.CalculatorPaediatricDsTbDosageWeightGroupId++;
                            }
                        }
                    }
                }
                else if (jsonPaediatricDsTbDosageCategory.Property("weight_groups") != null && jsonPaediatricDsTbDosageCategory.GetValue("weight_groups") is JArray)
                {
                    JArray jsonPaediatricDsTbDosageWeightGroups = jsonPaediatricDsTbDosageCategory.GetValue("weight_groups").Value<JArray>();

                    for (int indexPaediatricDsTbDosageWeightGroups = 0; indexPaediatricDsTbDosageWeightGroups < jsonPaediatricDsTbDosageWeightGroups.Count; indexPaediatricDsTbDosageWeightGroups++)
                    {
                        JObject jsonWeightGroup = jsonPaediatricDsTbDosageWeightGroups[indexPaediatricDsTbDosageWeightGroups].ToObject<JObject>();

                        CalculatorPaediatricDsTbDosageWeightGroup paediatricDsTbDosageWeightGroup = new CalculatorPaediatricDsTbDosageWeightGroup(this.CalculatorPaediatricDsTbDosageWeightGroupId, jsonWeightGroup.GetValue("title").Value<String>(), jsonWeightGroup.GetValue("dosage").Value<String>());

                        paediatricDsTbDosageWeightGroup.CategoryId = paediatricDsTbDosageCategory.Id;

                        this.CalculatorPaediatricDsTbDosageWeightGroups.Add(paediatricDsTbDosageWeightGroup);
                        this.CalculatorPaediatricDsTbDosageWeightGroupId++;
                    }
                }
            }
        }

        public void ProcessCalculatorPaediatricIsoniazidePreventiveTherapies(Section section, String fileName)
        {
            JArray jsonPaediatricIsoniazidePreventiveTherapies = JArray.Parse(this.UpdateContent.GetSectionFile(section.Location, fileName));

            for (int indexPaediatricIsoniazidePreventiveTherapies = 0; indexPaediatricIsoniazidePreventiveTherapies < jsonPaediatricIsoniazidePreventiveTherapies.Count; indexPaediatricIsoniazidePreventiveTherapies++)
            {
                JObject jsonPaediatricIsoniazidePreventiveTherapy = jsonPaediatricIsoniazidePreventiveTherapies[indexPaediatricIsoniazidePreventiveTherapies].ToObject<JObject>();

                CalculatorPaediatricIsoniazidePreventiveTherapy paediatricIsoniazidePreventiveTherapy = new CalculatorPaediatricIsoniazidePreventiveTherapy(this.CalculatorPaediatricIsoniazidePreventiveTherapyId, jsonPaediatricIsoniazidePreventiveTherapy.GetValue("target_dose").Value<String>(), jsonPaediatricIsoniazidePreventiveTherapy.GetValue("available_formulations").Value<String>());

                this.CalculatorPaediatricIsoniazidePreventiveTherapies.Add(paediatricIsoniazidePreventiveTherapy);
                this.CalculatorPaediatricIsoniazidePreventiveTherapyId++;

                if (jsonPaediatricIsoniazidePreventiveTherapy.Property("weight_groups") != null && jsonPaediatricIsoniazidePreventiveTherapy.GetValue("weight_groups") is JArray)
                {
                    JArray jsonPaediatricIsoniazidePreventiveWeightGroups = jsonPaediatricIsoniazidePreventiveTherapy.GetValue("weight_groups").Value<JArray>();

                    for (int indexPaediatricIsoniazidePreventiveWeightGroups = 0; indexPaediatricIsoniazidePreventiveWeightGroups < jsonPaediatricIsoniazidePreventiveWeightGroups.Count; indexPaediatricIsoniazidePreventiveWeightGroups++)
                    {
                        JObject jsonPaediatricIsoniazidePreventiveWeightGroup = jsonPaediatricIsoniazidePreventiveWeightGroups[indexPaediatricIsoniazidePreventiveWeightGroups].ToObject<JObject>();

                        CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup paediatricIsoniazidePreventiveTherapyWeightGroup = new CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup(this.CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroupId, paediatricIsoniazidePreventiveTherapy.Id, jsonPaediatricIsoniazidePreventiveWeightGroup.GetValue("title").Value<String>(), jsonPaediatricIsoniazidePreventiveWeightGroup.GetValue("dosage").Value<String>());

                        this.CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroups.Add(paediatricIsoniazidePreventiveTherapyWeightGroup);
                        this.CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroupId++;
                    }
                }
            }
        }

        private void ProcessCalculatorBmi(Section section, string fileName)
        {
            JArray jsonBmis = JArray.Parse(this.UpdateContent.GetSectionFile(section.Location, fileName));

            for (int indexBmis = 0; indexBmis < jsonBmis.Count; indexBmis++)
            {
                JObject jsonBmi = jsonBmis[indexBmis].ToObject<JObject>();

                CalculatorBmi bmi = new CalculatorBmi(this.CalculatorBmiId, jsonBmi.GetValue("title").Value<String>(), jsonBmi.GetValue("message").Value<String>(), jsonBmi.GetValue("color").Value<String>(), jsonBmi.GetValue("value_start").Value<Double?>(), jsonBmi.GetValue("value_end").Value<Double?>());

                this.CalculatorBmis.Add(bmi);
                this.CalculatorBmiId++;
            }
        }

        private void ProcessCalculatorTbTreatmentFollowUpDates(Section section, string fileName)
        {
            JArray jsonTbTreatmentFollowUpDates = JArray.Parse(this.UpdateContent.GetSectionFile(section.Location, fileName));

            for (int indexTbTreatmentFollowUpDates = 0; indexTbTreatmentFollowUpDates < jsonTbTreatmentFollowUpDates.Count; indexTbTreatmentFollowUpDates++)
            {
                JObject jsonTbTreatmentFollowUpDate = jsonTbTreatmentFollowUpDates[indexTbTreatmentFollowUpDates].ToObject<JObject>();

                CalculatorTbTreatmentFollowUpDate tbTreatmentFollowUpDate = new CalculatorTbTreatmentFollowUpDate(this.CalculatorTbTreatmentFollowUpDateId, jsonTbTreatmentFollowUpDate.GetValue("title").Value<String>(), jsonTbTreatmentFollowUpDate.GetValue("message").Value<String>(), jsonTbTreatmentFollowUpDate.GetValue("days").Value<Int32>());

                this.CalculatorTbTreatmentFollowUpDates.Add(tbTreatmentFollowUpDate);
                this.CalculatorTbTreatmentFollowUpDateId++;
            }
        }

        private void ProcessCalculatorMdrTreatmentFollowUpDates(Section section, string fileName)
        {
            JArray jsonMdrTreatmentFollowUpDates = JArray.Parse(this.UpdateContent.GetSectionFile(section.Location, fileName));

            for (int indexMdrTreatmentFollowUpDates = 0; indexMdrTreatmentFollowUpDates < jsonMdrTreatmentFollowUpDates.Count; indexMdrTreatmentFollowUpDates++)
            {
                JObject jsonMdrTreatmentFollowUpDate = jsonMdrTreatmentFollowUpDates[indexMdrTreatmentFollowUpDates].ToObject<JObject>();

                CalculatorMdrTreatmentFollowUpDate mdrTreatmentFollowUpDate = new CalculatorMdrTreatmentFollowUpDate(this.CalculatorMdrTreatmentFollowUpDateId, jsonMdrTreatmentFollowUpDate.GetValue("title").Value<String>(), jsonMdrTreatmentFollowUpDate.GetValue("message").Value<String>(), jsonMdrTreatmentFollowUpDate.GetValue("days").Value<Int32>());

                this.CalculatorMdrTreatmentFollowUpDates.Add(mdrTreatmentFollowUpDate);
                this.CalculatorMdrTreatmentFollowUpDateId++;
            }
        }

        public void ProcessCalculatorDrugInteraction(Section section, String fileName)
        {
            JObject jsonRoot = JArray.Parse(this.UpdateContent.GetSectionFile(section.Location, fileName))[0].ToObject<JObject>();

            JArray jsonDrugInteractionsEdls = jsonRoot.GetValue("edls").Value<JArray>();

            for (int indexEdls = 0; indexEdls < jsonDrugInteractionsEdls.Count; indexEdls++)
            {
                JObject jsonEdl = jsonDrugInteractionsEdls[indexEdls].ToObject<JObject>();

                CalculatorDrugInteractionEdl calculatorDrugInteractionEdl = new CalculatorDrugInteractionEdl(jsonEdl.GetValue("id").Value<Int32>(), jsonEdl.GetValue("title").Value<String>());

                this.CalculatorDrugInteractionEdls.Add(calculatorDrugInteractionEdl);
            }

            JArray jsonArvs = jsonRoot.GetValue("arvs").Value<JArray>();

            for (int indexArvs = 0; indexArvs < jsonArvs.Count; indexArvs++)
            {
                JObject jsonArv = jsonArvs[indexArvs].ToObject<JObject>();

                CalculatorDrugInteractionArv calculatorDrugInteractionArv = new CalculatorDrugInteractionArv(jsonArv.GetValue("id").Value<Int32>(), jsonArv.GetValue("title").Value<String>());

                this.CalculatorDrugInteractionArvs.Add(calculatorDrugInteractionArv);
            }

            JArray jsonInteractions = jsonRoot.GetValue("interactions").Value<JArray>();

            for (int indexInteractions = 0; indexInteractions < jsonInteractions.Count; indexInteractions++)
            {
                JObject jsonInteraction = jsonInteractions[indexInteractions].ToObject<JObject>();

                CalculatorDrugInteractionInteraction calculatorDrugInteractionInteraction = new CalculatorDrugInteractionInteraction(this.CalculatorDrugInteractionInteractionId, jsonInteraction.GetValue("edl_id").Value<Int32>(), jsonInteraction.GetValue("arv_id").Value<Int32>(), jsonInteraction.GetValue("interaction").Value<String>(), jsonInteraction.GetValue("management").Value<String>());

                this.CalculatorDrugInteractionInteractions.Add(calculatorDrugInteractionInteraction);
                this.CalculatorDrugInteractionInteractionId++;
            }
        }
    }
}