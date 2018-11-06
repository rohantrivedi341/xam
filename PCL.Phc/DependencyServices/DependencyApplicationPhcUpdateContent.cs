using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using PCL.Common;
using PCL.Common.Enum;
using PCL.Database;
using PCL.DependencyServices;
using PCL.Phc.Common;
using PCL.Phc.DependencyServices;
using PCL.Phc.Repository;
using PCL.Repository;
using PCL.Services;
using Xamarin.Forms;
using ItemCalculator = PCL.Phc.Common.ItemCalculator;

[assembly: Dependency(typeof (DependencyApplicationPhcUpdateContent))]

namespace PCL.Phc.DependencyServices
{
    public class DependencyApplicationPhcUpdateContent : IDependencyApplicationUpdateContent
    {
        public UpdateContentService UpdateContent;

        public Int32 CalculatorPaedatircDosageDrugId = 1;
        public Int32 CalculatorPaedatircDosageAgeWeightGroupId = 1;
        public Int32 CalculatorMedicineCostingGenericId = 1;
        public Int32 CalculatorMedicineCostingDescriptionId = 1;
        public Int32 CalculatorIcd10CodesChapterId = 1;
        public Int32 CalculatorIcd10CodesBlockId = 1;
        public Int32 CalculatorIcde10CodesCodeId = 1;
        public Int32 CalculatorCardiovascularRiskAgeId = 1;
        public Int32 CalculatorCardiovascularRiskDiabeticId = 1;
        public Int32 CalculatorCardiovascularRiskHdlCholesterolId = 1;
        public Int32 CalculatorCardiovascularRiskResultId = 1;
        public Int32 CalculatorCardiovascularRiskSexId = 1;
        public Int32 CalculatorCardiovascularRiskSmokerId = 1;
        public Int32 CalculatorCardiovascularRiskSystolicBpId = 1;
        public Int32 CalculatorCardiovascularRiskSystolicBpTreatmentId = 1;
        public Int32 CalculatorCardiovascularRiskTotalCholesterolId = 1;

        public List<ItemCalculator> ItemCalculators = new List<ItemCalculator>();

        public List<CalculatorPaediatricDosageDrug> CalculatorPaedatircDosageDrugs = new List<CalculatorPaediatricDosageDrug>();
        public List<CalculatorPaediatricDosageAgeWeightGroup> CalculatorPaedatircDosageAgeWeightGroups = new List<CalculatorPaediatricDosageAgeWeightGroup>();
        public List<CalculatorMedicineCostingGeneric> CalculatorMedicineCostingGenerics = new List<CalculatorMedicineCostingGeneric>();
        public List<CalculatorMedicineCostingDescription> CalculatorMedicineCostingDescriptions = new List<CalculatorMedicineCostingDescription>();
        public List<CalculatorIcd10CodesChapter> CalculatorIcd10CodesChapters = new List<CalculatorIcd10CodesChapter>();
        public List<CalculatorIcd10CodesBlock> CalculatorIcd10CodesBlocks = new List<CalculatorIcd10CodesBlock>();
        public List<CalculatorIcd10CodesCode> CalculatorIcd10CodesCodes = new List<CalculatorIcd10CodesCode>();
        public List<CalculatorCardiovascularRiskAge> CalculatorCardiovascularRiskAges = new List<CalculatorCardiovascularRiskAge>();
        public List<CalculatorCardiovascularRiskDiabetic> CalculatorCardiovascularRiskDiabetics = new List<CalculatorCardiovascularRiskDiabetic>();
        public List<CalculatorCardiovascularRiskHdlCholesterol> CalculatorCardiovascularRiskHdlCholesterols = new List<CalculatorCardiovascularRiskHdlCholesterol>();
        public List<CalculatorCardiovascularRiskResult> CalculatorCardiovascularRiskResults = new List<CalculatorCardiovascularRiskResult>();
        public List<CalculatorCardiovascularRiskSex> CalculatorCardiovascularRiskSexes = new List<CalculatorCardiovascularRiskSex>();
        public List<CalculatorCardiovascularRiskSmoker> CalculatorCardiovascularRiskSmokers = new List<CalculatorCardiovascularRiskSmoker>();
        public List<CalculatorCardiovascularRiskBpTreatment> CalculatorCardiovascularRiskBpTreatments = new List<CalculatorCardiovascularRiskBpTreatment>();
        public List<CalculatorCardiovascularRiskSystolicBp> CalculatorCardiovascularRiskSystolicBps = new List<CalculatorCardiovascularRiskSystolicBp>();
        public List<CalculatorCardiovascularRiskTotalCholesterol> CalculatorCardiovascularRiskTotalCholesterols = new List<CalculatorCardiovascularRiskTotalCholesterol>();

        public void Initialize(UpdateContentService updateContent)
        {
            this.UpdateContent = updateContent;
        }

        public void Save(SQLiteConnectionDatabase sqLiteConnectionDatabase)
        {
            new ItemCalculatorRepository(sqLiteConnectionDatabase).Save(this.ItemCalculators);

            new CalculatorPaediatricDosageDrugRepository(sqLiteConnectionDatabase).Save(this.CalculatorPaedatircDosageDrugs);
            new CalculatorPaediatricDosageAgeWeightGroupRepository(sqLiteConnectionDatabase).Save(this.CalculatorPaedatircDosageAgeWeightGroups);
            new CalculatorMedicineCostingGenericRepository(sqLiteConnectionDatabase).Save(this.CalculatorMedicineCostingGenerics);
            new CalculatorMedicineCostingDescriptionRepository(sqLiteConnectionDatabase).Save(this.CalculatorMedicineCostingDescriptions);
            new CalculatorIcd10CodesChapterRepository(sqLiteConnectionDatabase).Save(this.CalculatorIcd10CodesChapters);
            new CalculatorIcd10CodesBlockRepository(sqLiteConnectionDatabase).Save(this.CalculatorIcd10CodesBlocks);
            new CalculatorIcd10CodesCodeRepository(sqLiteConnectionDatabase).Save(this.CalculatorIcd10CodesCodes);
            new CalculatorCardiovascularRiskAgeRepository(sqLiteConnectionDatabase).Save(this.CalculatorCardiovascularRiskAges);
            new CalculatorCardiovascularRiskDiabeticRepository(sqLiteConnectionDatabase).Save(this.CalculatorCardiovascularRiskDiabetics);
            new CalculatorCardiovascularRiskHdlCholesterolRepository(sqLiteConnectionDatabase).Save(this.CalculatorCardiovascularRiskHdlCholesterols);
            new CalculatorCardiovascularRiskSexRepository(sqLiteConnectionDatabase).Save(this.CalculatorCardiovascularRiskSexes);
            new CalculatorCardiovascularRiskSmokerRepository(sqLiteConnectionDatabase).Save(this.CalculatorCardiovascularRiskSmokers);
            new CalculatorCardiovascularRiskBpTreatmentRepository(sqLiteConnectionDatabase).Save(this.CalculatorCardiovascularRiskBpTreatments);
            new CalculatorCardiovascularRiskSystolicBpRepository(sqLiteConnectionDatabase).Save(this.CalculatorCardiovascularRiskSystolicBps);
            new CalculatorCardiovascularRiskTotalCholesterolRepository(sqLiteConnectionDatabase).Save(this.CalculatorCardiovascularRiskTotalCholesterols);
            new CalculatorCardiovascularRiskResultRepository(sqLiteConnectionDatabase).Save(this.CalculatorCardiovascularRiskResults);
        }

        public void AddSections()
        {
            this.UpdateContent.Sections.Add(new Section(this.UpdateContent.SectionId, SectionType.Pages, "Guidelines", "Guidelines", "tab_guidelines.png", "guidelines", true));
            this.UpdateContent.SectionId++;
            this.UpdateContent.Sections.Add(new Section(this.UpdateContent.SectionId, SectionType.Pages, "Medicines", "Medicines", "tab_drugs.png", "drugs", true));
            this.UpdateContent.SectionId++;
            this.UpdateContent.Sections.Add(new Section(this.UpdateContent.SectionId, SectionType.Calculators, "Tools", "Tools", "tab_calculators.png", "calculators", true));
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
                case ItemCalculatorType.PaediatricDosages:
                    this.ProcessCalculatorPaediatricDosages(section, itemCalculator.FileName);

                    break;
                case ItemCalculatorType.MedicineCosting:
                    this.ProcessCalculatorMedicineCosting(section, itemCalculator.FileName);

                    break;
                case ItemCalculatorType.DrugStockOut:
                    this.UpdateContent.ProcessItemCalculatorFolder(itemCalculator, itemCalculator.Folder);

                    break;
                case ItemCalculatorType.SuspectedAdverseDrugReaction:
                    this.UpdateContent.ProcessItemCalculatorFolder(itemCalculator, itemCalculator.Folder);

                    break;
                case ItemCalculatorType.Icd10Codes:
                    this.ProcessItemCalculatorIcd10Codes(section, itemCalculator.FileName);

                    break;
                case ItemCalculatorType.CardiovascularRisk:
                    this.ProcessItemCalculatorCardiovascularRisk(section, itemCalculator.FileName);

                    break;
            }
        }

        private void ProcessCalculatorPaediatricDosages(Section section, String fileName)
        {
            JArray jsonPaediatricDrugDosages = JArray.Parse(this.UpdateContent.GetSectionFile(section.Location, fileName));

            for (int indexPaediatricDosages = 0; indexPaediatricDosages < jsonPaediatricDrugDosages.Count; indexPaediatricDosages++)
            {
                JObject jsonPaediatricDosageDrug = jsonPaediatricDrugDosages[indexPaediatricDosages].ToObject<JObject>();

                CalculatorPaediatricDosageDrug paediatricDrugDosageDrug = new CalculatorPaediatricDosageDrug(this.CalculatorPaedatircDosageDrugId, jsonPaediatricDosageDrug.GetValue("title").Value<String>(), jsonPaediatricDosageDrug.GetValue("indications").Value<String>(), jsonPaediatricDosageDrug.GetValue("frequency").Value<String>(), jsonPaediatricDosageDrug.GetValue("dosage_formula").Value<String>());

                this.CalculatorPaedatircDosageDrugs.Add(paediatricDrugDosageDrug);
                this.CalculatorPaedatircDosageDrugId++;

                if (jsonPaediatricDosageDrug.Property("weight_groups") != null && jsonPaediatricDosageDrug.GetValue("weight_groups") is JArray)
                {
                    JArray jsonPaediatricDrugDosageWeightGroups = jsonPaediatricDosageDrug.GetValue("weight_groups").Value<JArray>();

                    for (int indexPaediatricDrugDosageWeightGroups = 0; indexPaediatricDrugDosageWeightGroups < jsonPaediatricDrugDosageWeightGroups.Count; indexPaediatricDrugDosageWeightGroups++)
                    {
                        JObject jsonPaedatircDrugDosageWeightGroup = jsonPaediatricDrugDosageWeightGroups[indexPaediatricDrugDosageWeightGroups].ToObject<JObject>();

                        CalculatorPaediatricDosageAgeWeightGroup paediatricDrugDosageWeightGroup = new CalculatorPaediatricDosageAgeWeightGroup(this.CalculatorPaedatircDosageAgeWeightGroupId, paediatricDrugDosageDrug.Id, jsonPaedatircDrugDosageWeightGroup.GetValue("title").Value<String>(), jsonPaedatircDrugDosageWeightGroup.GetValue("dosage").Value<String>(), jsonPaedatircDrugDosageWeightGroup.GetValue("formulation_options").Value<String>(), indexPaediatricDrugDosageWeightGroups);

                        this.CalculatorPaedatircDosageAgeWeightGroups.Add(paediatricDrugDosageWeightGroup);
                        this.CalculatorPaedatircDosageAgeWeightGroupId++;
                    }
                }
            }
        }

        private void ProcessCalculatorMedicineCosting(Section section, String fileName)
        {
            JArray jsonMedicineCostingGenerics = JArray.Parse(this.UpdateContent.GetSectionFile(section.Location, fileName));

            for (int indexMedicineCostingGenerics = 0; indexMedicineCostingGenerics < jsonMedicineCostingGenerics.Count; indexMedicineCostingGenerics++)
            {
                JObject jsonMedicineCostingGeneric = jsonMedicineCostingGenerics[indexMedicineCostingGenerics].ToObject<JObject>();

                CalculatorMedicineCostingGeneric medicineCostingGeneric = new CalculatorMedicineCostingGeneric(this.CalculatorMedicineCostingGenericId, jsonMedicineCostingGeneric.GetValue("title").Value<String>());

                this.CalculatorMedicineCostingGenerics.Add(medicineCostingGeneric);
                this.CalculatorMedicineCostingGenericId++;

                if (jsonMedicineCostingGeneric.Property("labels") != null && jsonMedicineCostingGeneric.GetValue("labels") is JArray)
                {
                    JArray jsonMedicineCostingLabels = jsonMedicineCostingGeneric.GetValue("labels").Value<JArray>();

                    for (int indexMedicineCostingLabels = 0; indexMedicineCostingLabels < jsonMedicineCostingLabels.Count; indexMedicineCostingLabels++)
                    {
                        if (!String.IsNullOrWhiteSpace(medicineCostingGeneric.Labels))
                        {
                            medicineCostingGeneric.Labels += ", ";
                        }

                        medicineCostingGeneric.Labels += jsonMedicineCostingLabels[indexMedicineCostingLabels].Value<String>();
                    }
                }

                if (jsonMedicineCostingGeneric.Property("children") != null && jsonMedicineCostingGeneric.GetValue("children") is JArray)
                {
                    JArray jsonMedicineCostingDescriptions = jsonMedicineCostingGeneric.GetValue("children").Value<JArray>();

                    for (int indexMedicineCostingDescriptions = 0; indexMedicineCostingDescriptions < jsonMedicineCostingDescriptions.Count; indexMedicineCostingDescriptions++)
                    {
                        JObject jsonMedicineCostingDescription = jsonMedicineCostingDescriptions[indexMedicineCostingDescriptions].ToObject<JObject>();

                        CalculatorMedicineCostingDescription calculatorMedicineCostingDescription = new CalculatorMedicineCostingDescription(this.CalculatorMedicineCostingDescriptionId, medicineCostingGeneric.Id, jsonMedicineCostingDescription.GetValue("description").Value<String>(), jsonMedicineCostingDescription.GetValue("brand").Value<String>(), jsonMedicineCostingDescription.GetValue("price").Value<String>(), jsonMedicineCostingDescription.GetValue("contract_number").Value<String>());

                        this.CalculatorMedicineCostingDescriptions.Add(calculatorMedicineCostingDescription);
                        this.CalculatorMedicineCostingDescriptionId++;
                    }
                }
            }
        }

        public void ProcessItemCalculatorIcd10Codes(Section section, String fileName)
        {
            JObject jsonRoot = JArray.Parse(this.UpdateContent.GetSectionFile(section.Location, fileName))[0].ToObject<JObject>();

            JArray jsonChapters = jsonRoot.GetValue("chapters").Value<JArray>();

            for (int indexChapters = 0; indexChapters < jsonChapters.Count; indexChapters++)
            {
                JObject jsonChapter = jsonChapters[indexChapters].ToObject<JObject>();

                CalculatorIcd10CodesChapter calculatorWhoDiseasesChapter = new CalculatorIcd10CodesChapter(this.CalculatorIcd10CodesChapterId, jsonChapter.GetValue("number").Value<Int32>(), jsonChapter.GetValue("title").Value<String>(), jsonChapter.GetValue("prefix").Value<String>());

                this.CalculatorIcd10CodesChapters.Add(calculatorWhoDiseasesChapter);
                this.CalculatorIcd10CodesChapterId++;
            }

            JArray jsonBlocks = jsonRoot.GetValue("blocks").Value<JArray>();

            for (int indexBlocks = 0; indexBlocks < jsonBlocks.Count; indexBlocks++)
            {
                JObject jsonBlock = jsonBlocks[indexBlocks].ToObject<JObject>();

                CalculatorIcd10CodesBlock calculatorWhoDiseasesBlock = new CalculatorIcd10CodesBlock(this.CalculatorIcd10CodesBlockId, jsonBlock.GetValue("chapter").Value<Int32>(), jsonBlock.GetValue("number").Value<String>(), jsonBlock.GetValue("title").Value<String>(), jsonBlock.GetValue("prefix").Value<String>());

                this.CalculatorIcd10CodesBlocks.Add(calculatorWhoDiseasesBlock);
                this.CalculatorIcd10CodesBlockId++;
            }

            JArray jsonCodes = jsonRoot.GetValue("codes").Value<JArray>();

            for (int indexCodes = 0; indexCodes < jsonCodes.Count; indexCodes++)
            {
                JObject jsonCode = jsonCodes[indexCodes].ToObject<JObject>();

                CalculatorIcd10CodesCode calculatorWhoDiseasesCode = new CalculatorIcd10CodesCode(this.CalculatorIcde10CodesCodeId, jsonCode.GetValue("chapter").Value<Int32>(), jsonCode.GetValue("block").Value<String>(), jsonCode.GetValue("code").Value<String>(), jsonCode.GetValue("title").Value<String>());

                this.CalculatorIcd10CodesCodes.Add(calculatorWhoDiseasesCode);
                this.CalculatorIcde10CodesCodeId++;
            }
        }

        private void ProcessItemCalculatorCardiovascularRisk(Section section, string fileName)
        {
            JObject jsonRoot = JArray.Parse(this.UpdateContent.GetSectionFile(section.Location, fileName))[0].ToObject<JObject>();

            JArray jsonSexes = jsonRoot.GetValue("sexes").Value<JArray>();

            for (int indexSexes = 0; indexSexes < jsonSexes.Count; indexSexes++)
            {
                JObject jsonSex = jsonSexes[indexSexes].ToObject<JObject>();

                CalculatorCardiovascularRiskSex calculatorCardiovascularRiskSex = new CalculatorCardiovascularRiskSex(this.CalculatorCardiovascularRiskSexId, jsonSex.GetValue("title").Value<String>(), (CalculatorCardiovascularRiskSexType) jsonSex.GetValue("sex_type").Value<Int32>());

                this.CalculatorCardiovascularRiskSexes.Add(calculatorCardiovascularRiskSex);
                this.CalculatorCardiovascularRiskSexId++;
            }

            JArray jsonAges = jsonRoot.GetValue("ages").Value<JArray>();

            for (int indexAges = 0; indexAges < jsonAges.Count; indexAges++)
            {
                JObject jsonAge = jsonAges[indexAges].ToObject<JObject>();

                CalculatorCardiovascularRiskAge calculatorCardiovascularRiskAge = new CalculatorCardiovascularRiskAge(this.CalculatorCardiovascularRiskAgeId, jsonAge.GetValue("title").Value<String>(), jsonAge.GetValue("male").Value<Int32>(), jsonAge.GetValue("female").Value<Int32>());

                this.CalculatorCardiovascularRiskAges.Add(calculatorCardiovascularRiskAge);
                this.CalculatorCardiovascularRiskAgeId++;
            }

            JArray jsonTotalCholesterols = jsonRoot.GetValue("total_cholesterols").Value<JArray>();

            for (int indexTotalCholesterols = 0; indexTotalCholesterols < jsonTotalCholesterols.Count; indexTotalCholesterols++)
            {
                JObject jsonTotalCholesterol = jsonTotalCholesterols[indexTotalCholesterols].ToObject<JObject>();

                CalculatorCardiovascularRiskTotalCholesterol calculatorCardiovascularRiskTotalCholesterol = new CalculatorCardiovascularRiskTotalCholesterol(this.CalculatorCardiovascularRiskTotalCholesterolId, jsonTotalCholesterol.GetValue("title").Value<String>(), jsonTotalCholesterol.GetValue("male").Value<Int32>(), jsonTotalCholesterol.GetValue("female").Value<Int32>());

                this.CalculatorCardiovascularRiskTotalCholesterols.Add(calculatorCardiovascularRiskTotalCholesterol);
                this.CalculatorCardiovascularRiskTotalCholesterolId++;
            }

            JArray jsonHdlCholesterols = jsonRoot.GetValue("hdl_cholesterols").Value<JArray>();

            for (int indexHdlCholesterols = 0; indexHdlCholesterols < jsonHdlCholesterols.Count; indexHdlCholesterols++)
            {
                JObject jsonHdlCholesterol = jsonHdlCholesterols[indexHdlCholesterols].ToObject<JObject>();

                CalculatorCardiovascularRiskHdlCholesterol calculatorCardiovascularRiskHdlCholesterol = new CalculatorCardiovascularRiskHdlCholesterol(this.CalculatorCardiovascularRiskHdlCholesterolId, jsonHdlCholesterol.GetValue("title").Value<String>(), jsonHdlCholesterol.GetValue("male").Value<Int32>(), jsonHdlCholesterol.GetValue("female").Value<Int32>());

                this.CalculatorCardiovascularRiskHdlCholesterols.Add(calculatorCardiovascularRiskHdlCholesterol);
                this.CalculatorCardiovascularRiskHdlCholesterolId++;
            }

            JArray jsonSmokers = jsonRoot.GetValue("smokers").Value<JArray>();

            for (int indexSmokers = 0; indexSmokers < jsonSmokers.Count; indexSmokers++)
            {
                JObject jsonSmoker = jsonSmokers[indexSmokers].ToObject<JObject>();

                CalculatorCardiovascularRiskSmoker calculatorCardiovascularRiskSmoker = new CalculatorCardiovascularRiskSmoker(this.CalculatorCardiovascularRiskSmokerId, jsonSmoker.GetValue("title").Value<String>(), jsonSmoker.GetValue("male").Value<Int32>(), jsonSmoker.GetValue("female").Value<Int32>());

                this.CalculatorCardiovascularRiskSmokers.Add(calculatorCardiovascularRiskSmoker);
                this.CalculatorCardiovascularRiskSmokerId++;
            }

            JArray jsonDiabetics = jsonRoot.GetValue("diabetics").Value<JArray>();

            for (int indexDiabetics = 0; indexDiabetics < jsonDiabetics.Count; indexDiabetics++)
            {
                JObject jsonDiabetic = jsonDiabetics[indexDiabetics].ToObject<JObject>();

                CalculatorCardiovascularRiskDiabetic calculatorCardiovascularRiskDiabetic = new CalculatorCardiovascularRiskDiabetic(this.CalculatorCardiovascularRiskDiabeticId, jsonDiabetic.GetValue("title").Value<String>(), jsonDiabetic.GetValue("male").Value<Int32>(), jsonDiabetic.GetValue("female").Value<Int32>());

                this.CalculatorCardiovascularRiskDiabetics.Add(calculatorCardiovascularRiskDiabetic);
                this.CalculatorCardiovascularRiskDiabeticId++;
            }

            JArray jsonBpTreatments = jsonRoot.GetValue("bps_treatments").Value<JArray>();

            for (int indexBpTreatments = 0; indexBpTreatments < jsonBpTreatments.Count; indexBpTreatments++)
            {
                JObject jsonBpTreatment = jsonBpTreatments[indexBpTreatments].ToObject<JObject>();

                CalculatorCardiovascularRiskBpTreatment calculatorCardiovascularRiskBpTreatment = new CalculatorCardiovascularRiskBpTreatment(this.CalculatorCardiovascularRiskSystolicBpTreatmentId, jsonBpTreatment.GetValue("title").Value<String>(), jsonBpTreatment.GetValue("treatment").Value<Boolean>());

                this.CalculatorCardiovascularRiskBpTreatments.Add(calculatorCardiovascularRiskBpTreatment);
                this.CalculatorCardiovascularRiskSystolicBpTreatmentId++;
            }

            JArray jsonSystolicBpsUntreated = jsonRoot.GetValue("systolic_bps_untreated").Value<JArray>();

            for (int indexSystolicBps = 0; indexSystolicBps < jsonSystolicBpsUntreated.Count; indexSystolicBps++)
            {
                JObject jsonSystolicBp = jsonSystolicBpsUntreated[indexSystolicBps].ToObject<JObject>();

                CalculatorCardiovascularRiskSystolicBp calculatorCardiovascularRiskSystolicBp = new CalculatorCardiovascularRiskSystolicBp(this.CalculatorCardiovascularRiskSystolicBpId, jsonSystolicBp.GetValue("title").Value<String>(), false, jsonSystolicBp.GetValue("male").Value<Int32>(), jsonSystolicBp.GetValue("female").Value<Int32>());

                this.CalculatorCardiovascularRiskSystolicBps.Add(calculatorCardiovascularRiskSystolicBp);
                this.CalculatorCardiovascularRiskSystolicBpId++;
            }

            JArray jsonSystolicBpsTreated = jsonRoot.GetValue("systolic_bps_treated").Value<JArray>();

            for (int indexSystolicBps = 0; indexSystolicBps < jsonSystolicBpsTreated.Count; indexSystolicBps++)
            {
                JObject jsonSystolicBp = jsonSystolicBpsTreated[indexSystolicBps].ToObject<JObject>();

                CalculatorCardiovascularRiskSystolicBp calculatorCardiovascularRiskSystolicBp = new CalculatorCardiovascularRiskSystolicBp(this.CalculatorCardiovascularRiskSystolicBpId, jsonSystolicBp.GetValue("title").Value<String>(), true, jsonSystolicBp.GetValue("male").Value<Int32>(), jsonSystolicBp.GetValue("female").Value<Int32>());

                this.CalculatorCardiovascularRiskSystolicBps.Add(calculatorCardiovascularRiskSystolicBp);
                this.CalculatorCardiovascularRiskSystolicBpId++;
            }

            JArray jsonResults = jsonRoot.GetValue("results").Value<JArray>();
            JArray jsonResultsMen = jsonResults[0].ToObject<JObject>().GetValue("male").Value<JArray>();

            for (int indexResults = 0; indexResults < jsonResultsMen.Count; indexResults++)
            {
                JObject jsonResult = jsonResultsMen[indexResults].ToObject<JObject>();

                CalculatorCardiovascularRiskResult calculatorCardiovascularRiskResult = new CalculatorCardiovascularRiskResult(this.CalculatorCardiovascularRiskResultId, CalculatorCardiovascularRiskSexType.Male, jsonResult.GetValue("points").Value<Int32>(), jsonResult.GetValue("risk_text").Value<String>(), jsonResult.GetValue("risk_value").Value<Double>());

                this.CalculatorCardiovascularRiskResults.Add(calculatorCardiovascularRiskResult);
                this.CalculatorCardiovascularRiskResultId++;
            }

            JArray jsonResultsWomen = jsonResults[0].ToObject<JObject>().GetValue("female").Value<JArray>();

            for (int indexResults = 0; indexResults < jsonResultsWomen.Count; indexResults++)
            {
                JObject jsonResult = jsonResultsWomen[indexResults].ToObject<JObject>();

                CalculatorCardiovascularRiskResult calculatorCardiovascularRiskResult = new CalculatorCardiovascularRiskResult(this.CalculatorCardiovascularRiskResultId, CalculatorCardiovascularRiskSexType.Female, jsonResult.GetValue("points").Value<Int32>(), jsonResult.GetValue("risk_text").Value<String>(), jsonResult.GetValue("risk_value").Value<Double>());

                this.CalculatorCardiovascularRiskResults.Add(calculatorCardiovascularRiskResult);
                this.CalculatorCardiovascularRiskResultId++;
            }
        }
    }
}