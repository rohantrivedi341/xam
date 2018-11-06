using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using PCL.Common;
using PCL.Common.Enum;
using PCL.Database;
using PCL.DependencyServices;
using PCL.Hiv.Common;
using PCL.Hiv.DependencyServices;
using PCL.Hiv.Repository;
using PCL.Repository;
using PCL.Services;
using Xamarin.Forms;
using ItemCalculator = PCL.Hiv.Common.ItemCalculator;

[assembly: Dependency(typeof(DependencyApplicationHivUpdateContent))]

namespace PCL.Hiv.DependencyServices
{
    public class DependencyApplicationHivUpdateContent : IDependencyApplicationUpdateContent
    {
        public UpdateContentService UpdateContent;

        public Int32 CalculatorPaedatircArvDosageArvId = 1;
        public Int32 CalculatorPaedatircArvDosageWeightGroupId = 1;

        public Int32 CalculatorAdverseReactionPathologyParameterId = 1;
        public Int32 CalculatorAdverseReactionPathologyAgeCategoryId = 1;
        public Int32 CalculatorAdverseReactionPathologySexId = 1;

        public Int32 CalculatorArvRenalDosageArvId = 1;
        public Int32 CalculatorArvRenalDosageDosageId = 1;
        public Int32 CalculatorArvRenalDosageDosageItemId = 1;

        public Int32 CalculatorDrugInteractionInteractionId = 1;

        public List<ItemCalculator> ItemCalculators = new List<ItemCalculator>();

        public List<CalculatorPaediatricArvDosageArv> CalculatorPaedatircArvDosageArvs = new List<CalculatorPaediatricArvDosageArv>();
        public List<CalculatorPaediatricArvDosageWeightGroup> CalculatorPaedatircArvDosageWeightGroups = new List<CalculatorPaediatricArvDosageWeightGroup>();

        public List<CalculatorAdverseReactionPathologyParameter> CalculatorAdverseReactionPathologyParameters = new List<CalculatorAdverseReactionPathologyParameter>();
        public List<CalculatorAdverseReactionPathologyAgeCategory> CalculatorAdverseReactionPathologyAgeCategories = new List<CalculatorAdverseReactionPathologyAgeCategory>();
        public List<CalculatorAdverseReactionPathologySex> CalculatorAdverseReactionPathologySexes = new List<CalculatorAdverseReactionPathologySex>();

        public List<CalculatorArvRenalDosageArv> CalculatorArvRenalDosageArvs = new List<CalculatorArvRenalDosageArv>();
        public List<CalculatorArvRenalDosageDosage> CalculatorArvRenalDosageDosages = new List<CalculatorArvRenalDosageDosage>();
        public List<CalculatorArvRenalDosageDosageItem> CalculatorArvRenalDosageDosageItems = new List<CalculatorArvRenalDosageDosageItem>();

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

            new CalculatorPaediatricArvDosageArvRepository(sqLiteConnectionDatabase).Save(this.CalculatorPaedatircArvDosageArvs);
            new CalculatorPaediatricArvDosageWeightGroupRepository(sqLiteConnectionDatabase).Save(this.CalculatorPaedatircArvDosageWeightGroups);
            
            new CalculatorAdverseReactionPathologyParameterRepository(sqLiteConnectionDatabase).Save(this.CalculatorAdverseReactionPathologyParameters);
            new CalculatorAdverseReactionPathologyAgeCategoryRepository(sqLiteConnectionDatabase).Save(this.CalculatorAdverseReactionPathologyAgeCategories);
            new CalculatorAdverseReactionPathologySexRepository(sqLiteConnectionDatabase).Save(this.CalculatorAdverseReactionPathologySexes);

            new CalculatorArvRenalDosageArvRepository(sqLiteConnectionDatabase).Save(this.CalculatorArvRenalDosageArvs);
            new CalculatorArvRenalDosageDosageRepository(sqLiteConnectionDatabase).Save(this.CalculatorArvRenalDosageDosages);
            new CalculatorArvRenalDosageDosageItemRepository(sqLiteConnectionDatabase).Save(this.CalculatorArvRenalDosageDosageItems);

            new CalculatorDrugInteractionEdlRepository(sqLiteConnectionDatabase).Save(this.CalculatorDrugInteractionEdls);
            new CalculatorDrugInteractionArvRepository(sqLiteConnectionDatabase).Save(this.CalculatorDrugInteractionArvs);
            new CalculatorDrugInteractionInteractionRepository(sqLiteConnectionDatabase).Save(this.CalculatorDrugInteractionInteractions);
        }
        
        public void AddSections()
        {
            this.UpdateContent.Sections.Add(new Section(this.UpdateContent.SectionId, SectionType.Pages, "Guidelines", "Guidelines", "tab_guidelines.png", "ndoh", true));
            this.UpdateContent.SectionId++;
            this.UpdateContent.Sections.Add(new Section(this.UpdateContent.SectionId, SectionType.Pages, "ARVs", "ARVs", "tab_drugs.png", "drugs", true));
            this.UpdateContent.SectionId++;
            this.UpdateContent.Sections.Add(new Section(this.UpdateContent.SectionId, SectionType.Calculators, "Tools", "Tools", "tab_calculators.png", "calculators", true));
            this.UpdateContent.SectionId++;
            this.UpdateContent.Sections.Add(new Section(this.UpdateContent.SectionId, SectionType.Pages, "Summaries", "Summaries", "tab_guidelines.png", "private-sector", true));
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
                case ItemCalculatorType.PaediatricArvDosage:
                    this.ProcessCalculatorPaediatricArvDosage(section, itemCalculator.FileName);

                    break;
                case ItemCalculatorType.AdverseReactionPathology:
                    this.ProcessCalculatorAdverseReactionPathology(section, itemCalculator.FileName);

                    break;
                case ItemCalculatorType.ArvRenalDosage:
                    this.ProcessCalculatorArvRenalDosage(section, itemCalculator.FileName);

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

        public void ProcessCalculatorPaediatricArvDosage(Section section, String fileName)
        {
            JArray jsonPaediatricArvDosages = JArray.Parse(this.UpdateContent.GetSectionFile(section.Location, fileName));

            for (int indexPaediatricArvDosages = 0; indexPaediatricArvDosages < jsonPaediatricArvDosages.Count; indexPaediatricArvDosages++)
            {
                JObject jsonPaediatricArvDosage = jsonPaediatricArvDosages[indexPaediatricArvDosages].ToObject<JObject>();

                CalculatorPaediatricArvDosageArv jsonPaediatricArvDosageArv = new CalculatorPaediatricArvDosageArv(this.CalculatorPaedatircArvDosageArvId, jsonPaediatricArvDosage.GetValue("title").Value<String>(), jsonPaediatricArvDosage.GetValue("target_dose").Value<String>(), jsonPaediatricArvDosage.GetValue("available_formulations").Value<String>());

                this.CalculatorPaedatircArvDosageArvs.Add(jsonPaediatricArvDosageArv);
                this.CalculatorPaedatircArvDosageArvId++;

                if (jsonPaediatricArvDosage.Property("weight_groups") != null && jsonPaediatricArvDosage.GetValue("weight_groups") is JArray)
                {
                    JArray jsonWeightGroups = jsonPaediatricArvDosage.GetValue("weight_groups").Value<JArray>();

                    for (int indexWeightGroups = 0; indexWeightGroups < jsonWeightGroups.Count; indexWeightGroups++)
                    {
                        JObject jsonItemContactNumber = jsonWeightGroups[indexWeightGroups].ToObject<JObject>();

                        CalculatorPaediatricArvDosageWeightGroup calculatorPaedatircArvDosageWeightGroup = new CalculatorPaediatricArvDosageWeightGroup(this.CalculatorPaedatircArvDosageWeightGroupId, jsonPaediatricArvDosageArv.Id, jsonItemContactNumber.GetValue("title").Value<String>(), jsonItemContactNumber.GetValue("dosage").Value<String>(), jsonItemContactNumber.GetValue("display_order").Value<Int32>());

                        this.CalculatorPaedatircArvDosageWeightGroups.Add(calculatorPaedatircArvDosageWeightGroup);
                        this.CalculatorPaedatircArvDosageWeightGroupId++;
                    }
                }
            }
        }

        public void ProcessCalculatorAdverseReactionPathology(Section section, String fileName)
        {
            JArray jsonAdverseReactionPathologies = JArray.Parse(this.UpdateContent.GetSectionFile(section.Location, fileName));

            for (int indexAdverseReactionPathologies = 0; indexAdverseReactionPathologies < jsonAdverseReactionPathologies.Count; indexAdverseReactionPathologies++)
            {
                JObject jsonAdverseReactionPathology = jsonAdverseReactionPathologies[indexAdverseReactionPathologies].ToObject<JObject>();

                CalculatorAdverseReactionPathologyParameter adverseReactionPathologyParameter = new CalculatorAdverseReactionPathologyParameter(this.CalculatorAdverseReactionPathologyParameterId, jsonAdverseReactionPathology.GetValue("title").Value<String>(), jsonAdverseReactionPathology.GetValue("unit").Value<String>());

                this.CalculatorAdverseReactionPathologyParameters.Add(adverseReactionPathologyParameter);
                this.CalculatorAdverseReactionPathologyParameterId++;

                if (jsonAdverseReactionPathology.Property("age_groups") != null && jsonAdverseReactionPathology.GetValue("age_groups") is JArray)
                {
                    Int32? parameterUlnMale = jsonAdverseReactionPathology.Property("uln_male") != null ? jsonAdverseReactionPathology.GetValue("uln_male").Value<Int32?>() : null;
                    Int32? parameterUlnFemale = jsonAdverseReactionPathology.Property("uln_female") != null ? jsonAdverseReactionPathology.GetValue("uln_female").Value<Int32?>() : null;
                    Double? parameterGradeNoAbnormalReaction = jsonAdverseReactionPathology.Property("grade_no_abnormal_reaction") != null ? jsonAdverseReactionPathology.GetValue("grade_no_abnormal_reaction").Value<Double?>() : null;
                    Double? parameterGrade1 = jsonAdverseReactionPathology.Property("grade_1") != null ? jsonAdverseReactionPathology.GetValue("grade_1").Value<Double?>() : null;
                    Double? parameterGrade2 = jsonAdverseReactionPathology.Property("grade_2") != null ? jsonAdverseReactionPathology.GetValue("grade_2").Value<Double?>() : null;
                    Double? parameterGrade3 = jsonAdverseReactionPathology.Property("grade_3") != null ? jsonAdverseReactionPathology.GetValue("grade_3").Value<Double?>() : null;
                    Double? parameterGrade4 = jsonAdverseReactionPathology.Property("grade_4") != null ? jsonAdverseReactionPathology.GetValue("grade_4").Value<Double?>() : null;

                    JArray jsonAgeGroups = jsonAdverseReactionPathology.GetValue("age_groups").Value<JArray>();

                    for (int indexAgeGroups = 0; indexAgeGroups < jsonAgeGroups.Count; indexAgeGroups++)
                    {
                        JObject jsonAdverseReactionPathologyAgeCategory = jsonAgeGroups[indexAgeGroups].ToObject<JObject>();

                        Int32 ulnMale = parameterUlnMale.HasValue ? parameterUlnMale.Value : jsonAdverseReactionPathologyAgeCategory.GetValue("uln_male").Value<Int32>();
                        Int32 ulnFemale = parameterUlnFemale.HasValue ? parameterUlnFemale.Value : jsonAdverseReactionPathologyAgeCategory.GetValue("uln_female").Value<Int32>();
                        Double gradeNoAbnormalReaction = parameterGradeNoAbnormalReaction.HasValue ? parameterGradeNoAbnormalReaction.Value : jsonAdverseReactionPathologyAgeCategory.GetValue("grade_no_abnormal_reaction").Value<Double>();
                        Double grade1 = parameterGrade1.HasValue ? parameterGrade1.Value : jsonAdverseReactionPathologyAgeCategory.GetValue("grade_1").Value<Double>();
                        Double grade2 = parameterGrade2.HasValue ? parameterGrade2.Value : jsonAdverseReactionPathologyAgeCategory.GetValue("grade_2").Value<Double>();
                        Double grade3 = parameterGrade3.HasValue ? parameterGrade3.Value : jsonAdverseReactionPathologyAgeCategory.GetValue("grade_3").Value<Double>();
                        Double grade4 = parameterGrade4.HasValue ? parameterGrade4.Value : jsonAdverseReactionPathologyAgeCategory.GetValue("grade_4").Value<Double>();

                        CalculatorAdverseReactionPathologyAgeCategory adverseReactionPathologyAgeCategory = new CalculatorAdverseReactionPathologyAgeCategory(this.CalculatorAdverseReactionPathologyAgeCategoryId, adverseReactionPathologyParameter.Id, jsonAdverseReactionPathologyAgeCategory.GetValue("title").Value<String>(), jsonAdverseReactionPathologyAgeCategory.GetValue("start_day").Value<Int32>(), jsonAdverseReactionPathologyAgeCategory.GetValue("end_day").Value<Int32>(), ulnMale, ulnFemale, gradeNoAbnormalReaction, grade1, grade2, grade3, grade4);

                        this.CalculatorAdverseReactionPathologyAgeCategories.Add(adverseReactionPathologyAgeCategory);
                        this.CalculatorAdverseReactionPathologyAgeCategoryId++;
                    }
                }
            }

            this.CalculatorAdverseReactionPathologySexes.Add(new CalculatorAdverseReactionPathologySex(this.CalculatorAdverseReactionPathologySexId, "Male", CalculatorAdverseReactionPathologySexType.Male));
            this.CalculatorAdverseReactionPathologySexId++;
            this.CalculatorAdverseReactionPathologySexes.Add(new CalculatorAdverseReactionPathologySex(this.CalculatorAdverseReactionPathologySexId, "Female", CalculatorAdverseReactionPathologySexType.Female));
            this.CalculatorAdverseReactionPathologySexId++;
        }

        public void ProcessCalculatorArvRenalDosage(Section section, String fileName)
        {
            JArray jsonArvRenalDosages = JArray.Parse(this.UpdateContent.GetSectionFile(section.Location, fileName));

            for (int indexArvRenalDosages = 0; indexArvRenalDosages < jsonArvRenalDosages.Count; indexArvRenalDosages++)
            {
                JObject jsonArvRenalDosage = jsonArvRenalDosages[indexArvRenalDosages].ToObject<JObject>();

                CalculatorArvRenalDosageArv calculatorArvRenalDosageArv = new CalculatorArvRenalDosageArv(this.CalculatorArvRenalDosageArvId, jsonArvRenalDosage.GetValue("title").Value<String>());

                this.CalculatorArvRenalDosageArvs.Add(calculatorArvRenalDosageArv);
                this.CalculatorArvRenalDosageArvId++;

                if (jsonArvRenalDosage.Property("dosages") != null && jsonArvRenalDosage.GetValue("dosages") is JArray)
                {
                    JArray jsonDosages = jsonArvRenalDosage.GetValue("dosages").Value<JArray>();

                    for (int indexDosages = 0; indexDosages < jsonDosages.Count; indexDosages++)
                    {
                        JObject jsonDosage = jsonDosages[indexDosages].ToObject<JObject>();

                        CalculatorArvRenalDosageDosage calculatorArvRenalDosageDosage = new CalculatorArvRenalDosageDosage(this.CalculatorArvRenalDosageDosageId, calculatorArvRenalDosageArv.Id, jsonDosage.GetValue("title").Value<String>(), jsonDosage.GetValue("usual_dosage").Value<String>());

                        if (jsonDosage.Property("type") != null && jsonDosage.Property("type_value") != null)
                        {
                            calculatorArvRenalDosageDosage.Type = (CalculatorArvRenalDosageDosageType)jsonDosage.GetValue("type").Value<Int32>();
                            calculatorArvRenalDosageDosage.TypeValue = jsonDosage.GetValue("type_value").Value<Int32>();
                        }

                        this.CalculatorArvRenalDosageDosages.Add(calculatorArvRenalDosageDosage);
                        this.CalculatorArvRenalDosageDosageId++;

                        if (jsonDosage.Property("dosage_items") != null && jsonDosage.GetValue("dosage_items") is JArray)
                        {
                            JArray jsonDosageItems = jsonDosage.GetValue("dosage_items").Value<JArray>();

                            for (int indexDosageItems = 0; indexDosageItems < jsonDosageItems.Count; indexDosageItems++)
                            {
                                JObject jsonDosageItem = jsonDosageItems[indexDosageItems].ToObject<JObject>();

                                CalculatorArvRenalDosageDosageItem calculatorArvRenalDosageDosageItem = new CalculatorArvRenalDosageDosageItem(this.CalculatorArvRenalDosageDosageItemId, calculatorArvRenalDosageDosage.Id, jsonDosageItem.GetValue("title").Value<String>(), jsonDosageItem.GetValue("value").Value<String>());
                                
                                if (jsonDosageItem.Property("begin_ml") != null)
                                {
                                    calculatorArvRenalDosageDosageItem.CreatinineClearanceBeginMlPerMinute = jsonDosageItem.GetValue("begin_ml").Value<Int32?>();
                                }

                                if (jsonDosageItem.Property("end_ml") != null)
                                {
                                    calculatorArvRenalDosageDosageItem.CreatinineClearanceEndMlPerMinute = jsonDosageItem.GetValue("end_ml").Value<Int32?>();
                                }

                                this.CalculatorArvRenalDosageDosageItems.Add(calculatorArvRenalDosageDosageItem);
                                this.CalculatorArvRenalDosageDosageItemId++;
                            }
                        }
                    }
                }
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