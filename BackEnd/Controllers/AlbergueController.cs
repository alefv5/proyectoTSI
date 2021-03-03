using Albergue.Exceptions;
using Albergue.Models;
using Albergue.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Albergue.Controllers
{

    [Route("api/[controller]")]
    //[ApiController]
    public class AlbergueController : ControllerBase
    {
        private IPetServices _petService;
        public AlbergueController(IPetServices petService)
        {
            _petService = petService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PetModel>> GetPets()
        {
            try
            {
                return Ok(_petService.GetPets());
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }

        }
        [HttpGet("{petId:int}", Name = "GetPet")]
        public ActionResult<PetModel> GetPet(int petId)
        {
            try
            {
                return Ok(_petService.GetPet(petId));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpPost]
        public ActionResult<PetModel> CreatePet([FromBody] PetModel petModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(petModel);
                }
                var url = HttpContext.Request.Host;
                var createdPet = _petService.CreatePet(petModel);
                return CreatedAtRoute("GetPet", new { petId = createdPet.Id }, createdPet);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

        [HttpDelete("{petId:int}")]
        public ActionResult<bool> DeletePet(int petId)
        {
            try
            {
                return Ok(_petService.DeletePet(petId));
            }
            catch (NotFoundException ex)
            {

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpPut("{petId:int}")]
        public ActionResult<PetModel> UpdatePet(int petId, [FromBody] PetModel petModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var pair in ModelState)
                    {
                        if (pair.Key == nameof(petModel.Description) && pair.Value.Errors.Count > 0)
                        {
                            return BadRequest(pair.Value.Errors);
                        }
                    }
                }
                return _petService.UpdatePet(petId, petModel);
            }

            catch (NotFoundException ex)
            {

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
    }
}
