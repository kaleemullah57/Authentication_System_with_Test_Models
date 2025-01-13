using Authentication_System_with_Test_Models.Authentication_Folders.Auth_Models.User_Models;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Final_Resume_Model;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Interfaces;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Models;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Repositories;
using Dapper;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Authentication_System_with_Test_Models.Resume_Details_Folder.Services
{
    public class FinalResumeService
    {
        private readonly IPersonalRecordInterface _personalRecord;
        private readonly IEducationRecordInterface _educationRecord;
        private readonly IExtraEducationRecordInterface _extraEducationRecord;
        private readonly IExperienceRecordInterface _experienceRecord;
        private readonly ISkillsRecordInterface _skillsRecord;
        private readonly ILanguageRecordInterface _languageRecord;

        private readonly IFinalResumeInterface _finalResume;
        private readonly FinalResumeRepository _finalResumeRepository;



        public FinalResumeService(
                IPersonalRecordInterface personalRecordInterface,
                IEducationRecordInterface educationRecordInterface,
                IExtraEducationRecordInterface extraEducationRecordInterface,
                IExperienceRecordInterface experienceRecordInterface,
                ISkillsRecordInterface skillsRecordInterface,
                ILanguageRecordInterface languageRecordInterface
            ,
                IFinalResumeInterface finalResume,
                FinalResumeRepository finalResumeRepository

            )
        {
            _personalRecord = personalRecordInterface;
            _educationRecord = educationRecordInterface;
            _extraEducationRecord = extraEducationRecordInterface;
            _experienceRecord = experienceRecordInterface;
            _skillsRecord = skillsRecordInterface;
            _languageRecord = languageRecordInterface;
            _finalResume = finalResume;
            _finalResumeRepository = finalResumeRepository;
        }








        public async Task AddFinalResume(int Id, FinalResumeModel model)
        {
            var PersonalRecordId = await _personalRecord.AddPersonalRecodAsync(Id, model.PersonalRecord);

            // Add Education Record
            foreach (var edu in model.Educations)
            {
                await _educationRecord.AddEducationRecordAsync(Id, PersonalRecordId, edu);
            }

            // Add Extra Education Record
            foreach (var exEdu in model.ExtraEducations)
            {
                await _extraEducationRecord.AddExtraEducationRecordAsync(Id, PersonalRecordId, exEdu);
            }


            // Add Experience Record 
            foreach (var exp in model.Experience)
            {
                await _experienceRecord.AddExperienceRecordAsync(Id, PersonalRecordId, exp);
            }


            // Add Skills Record 
            foreach (var skills in model.Skills)
            {
                await _skillsRecord.AddSkillsRecordAsync(Id, PersonalRecordId, skills);
            }




            // Add Language Record
            foreach (var lang in model.Languages)
            {
                await _languageRecord.AddLanguageRecordAsync(Id, PersonalRecordId, lang);
            }
        }




        // Update Education Record
        public async Task<bool> UpdateEducationRecordAsync (int Id, int PersonalRecordId, EducationRecordModel educationRecordModel)
        {
            var isUpdated = await _educationRecord.UpdateEducationRecord(Id, PersonalRecordId, educationRecordModel);   
            return isUpdated;
        }

        // Delete Education Record
        public async Task<bool> DeleteOnlyEducationRecord (int EducationId, int PersonalRecordId)
        {
            var isDeleted = await _educationRecord.DeleteEducationRecord(PersonalRecordId, EducationId);
            return isDeleted;
        }



        // Update Experience Record 
        public async Task<bool> UpdateExperienceRecordAsync(int Id, int PersonalRecordId, ExperienceRecordModel experienceRecordModel)
        {
            var isUpdated = await _experienceRecord.UpdateExperienceRecord(Id, PersonalRecordId, experienceRecordModel);
            return isUpdated;
        }   

        // Delete Experince Record By Id
        public async Task<bool> DeleteExperinceRecordById(int PersonalRecordId, int ExperienceId)
        {
            var isDeletedd = await _experienceRecord.DeleteExperienceRecordById(PersonalRecordId, ExperienceId);
            return isDeletedd;
        }




        // Update ExtraEducation Record 
        public async Task<bool> UpdateExtraEducationRecord (int Id, int PersonalRecordId, ExtraEducationModel extraEducationModel)
        {
            var isUpdated = await _extraEducationRecord.UpdateExtraEducationRecordAsync(Id, PersonalRecordId, extraEducationModel);
            return isUpdated;
        }

        // Delete Extra Education Record
        public async Task<bool> DeleteExtraEducationRecordById (int PersonalRecordId, int ExEducationId)
        {
            var isDeleted = await _extraEducationRecord.DeleteExtraEducationRecordById(PersonalRecordId, ExEducationId);
            return isDeleted;
        }



        // Update Skills 
        public async Task<bool> UpdateSkillsRecordAsync (int Id, int PersonalRecordId, SkillsModel skillsModel)
        {
            var isUpdate = await _skillsRecord.UpdateSkillsRecordAsync(Id, PersonalRecordId, skillsModel);
            return isUpdate;
        }

        // Delete Skill Record ById
        public async Task<bool> DeleteSkillRecordById(int  PersonalRecordId, int SkillId)
        {
            var isDeleted = await _skillsRecord.DeleteSkillsRecordById(PersonalRecordId, SkillId);
            return isDeleted;
        }




        // Update Language Record 
        public async Task<bool> UpdateLanguageRecordAsync (int Id, int PersonalRecordId, LanguageModel languageModel)
        {
            var isUpdated = await _languageRecord.UpdateLanguageRecordAsync(Id, PersonalRecordId, languageModel); ;
            return isUpdated;
        }

        // Delete Language Record
        public async Task<bool> Delete_Language_Record (int PersonalRecordId, int LanguageId)
        {
            var isDeleted = await _languageRecord.DeleteLanguage(PersonalRecordId, LanguageId);
            return isDeleted;
        }





        // Delete Section
        public async Task<bool> DeleteAllRecordsByPersonalRecordId(int personalRecordId, int Id)
        {
            return await _finalResumeRepository.DeleteAllRecordsByPersonalRecordId(personalRecordId, Id);
        }











    }
}