using Authentication_System_with_Test_Models.Authentication_Folders.Auth_Models.User_Models;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Final_Resume_Model;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Interfaces;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Models;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Repositories;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Authentication_System_with_Test_Models.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class FinalResumeController : ControllerBase
    {
        private readonly FinalResumeService _service;
        private readonly IFinalResumeInterface _interface;

        public FinalResumeController(FinalResumeService finalResumeService, IFinalResumeInterface finalResumeInterface)
        {
            _service = finalResumeService;
            _interface = finalResumeInterface;
        }



        [HttpPost("AddResume")]
        public async Task<IActionResult> AddFinalResume (FinalResumeModel finalResumeModel)
        {
            var Id = int.Parse(User.FindFirst("Id").Value);
            await _service.AddFinalResume(Id, finalResumeModel);
            return Ok(finalResumeModel);
        }





        // Get All Records, when user is loggedIn
        // Updated GET: Fetch all data of the logged-in user only
        [HttpGet("GetAllDataOfLoggedIn")]
        public async Task<IActionResult> GetMyFinalResume()
        {
            // Extract the logged-in user's ID from the JWT token
            var idClaim = User.FindFirst("Id");
            if (idClaim == null)
            {
                return Unauthorized("User ID not found in token. Please log in again.");
            }

            var Id = int.Parse(idClaim.Value);

            // Call the repository to fetch data for the logged-in user
            var result = await _interface.GetAllDataOfLoggedInUser(Id);
            if (result == null)
            {
                return NotFound("No resume data found for the logged-in user.");
            }

            return Ok(result);
        }












        // Update Education Record
        [HttpPut("UpdateEducationRecord/{Id}/{personalRecordId}")]
        public  async Task<IActionResult> UpdateEducationRecord (
            int personalRecordId,
            int Id,
            EducationRecordModel educationRecordModel
            )
        {
            var idClaim = User.FindFirst("Id");
            if (idClaim == null)
            {
                return Unauthorized("User Id Not Found In the Token");
            }
            int id = int.Parse(idClaim.Value);
            var result = await _service.UpdateEducationRecordAsync(Id, personalRecordId, educationRecordModel);
            return Ok(result); 
        }

        // Delete Only EducationRecord
        [HttpDelete("DeleteOnlyEducationRecord/{PersonalRecordId}/{EducationId}")]
        public async Task<IActionResult> DeleteEducationRecordOnly (int PersonalRecordId, int EducationId)
        {
            var claim = User.FindFirst("Id");
            if (claim == null)
            {
                return Unauthorized(" User is not loggedIn");
            }
            int id = int.Parse (claim.Value);
            var result = await _service.DeleteOnlyEducationRecord(EducationId, PersonalRecordId);
            return Ok(result);
        }




        // Update Experience Record 
        [HttpPut("UpdateExperienceRecord/{Id}/{personalRecordId}")]
        public async Task<IActionResult> UpdateExperienceRecordAsync(int Id, int personalRecordId, ExperienceRecordModel experienceRecordModel)
        {
            var idClaim = User.FindFirst("Id");
            if(idClaim == null)
            {
                return Unauthorized(" User is Unauthorized");
            }

            int id = int.Parse (idClaim.Value);
            var result = await _service.UpdateExperienceRecordAsync(Id, personalRecordId, experienceRecordModel);
            return Ok(result);  
        }




        // Update Extra Education Record
        [HttpPut("UpdateExtraEducation/{Id}/{personalRecordId}")]
        public async Task<IActionResult> UpdateExtraEducationRecord (int Id, int personalRecordId, ExtraEducationModel extraEducationModel)
        {
            var idClaim = User.FindFirst("Id");
            if (idClaim == null)
            {
                return Unauthorized(" User is Unauthorized");
            }
            var result = await _service.UpdateExtraEducationRecord(Id, personalRecordId, extraEducationModel);
            return Ok(result);
        }




        // Update Skills Record 
        [HttpPut("UpdateSkillsRecord/{Id}/{PersonalRecordId}")]
        public async Task<IActionResult> UpdateSkillsRecordAsync (int Id, int PersonalRecordId, SkillsModel skillsModel)
        {
            var idClaim = User.FindFirst("Id");
            if( idClaim == null)
            {
                return Unauthorized(" User is Unauthorized");
            }
            var result = await _service.UpdateSkillsRecordAsync(Id, PersonalRecordId, skillsModel);
            return Ok(result);
        }





        // Update Language Record
        [HttpPut("UpdateLanguageRecord/{Id}/{PersonalRecordId}")]
        public async Task<IActionResult> UpdateLanguageRecordAsync (int Id, int PersonalRecordId, LanguageModel languageModel)
        {
            var idClaim = User.FindFirst("Id");
            if( idClaim == null)
            {
                return Unauthorized("User is Unauthorized");
            }
            var result = await _service.UpdateLanguageRecordAsync(Id, PersonalRecordId, languageModel);
            return Ok(result);
        }



        // HTTP DELETE request to delete all records by PersonalRecordId
        [HttpDelete("DeleteRecords/{personalRecordId}")]
        public async Task<IActionResult> DeleteAllRecordsByPersonalRecordId(int personalRecordId)
        {
            var userIdClaim = User.FindFirst("Id"); // Extract UserId from JWT token
            if (userIdClaim == null)
            {
                return Unauthorized("User ID not found in the token.");
            }

            int Id = int.Parse(userIdClaim.Value); // Get UserId from JWT claim

            // Call service to delete records for the logged-in user
            var result = await _service.DeleteAllRecordsByPersonalRecordId(personalRecordId, Id);

            if (result)
            {
                return NotFound("All related records deleted Successfully");
            }

            return Ok("All related records deleted successfully.");
        }
    }
}
