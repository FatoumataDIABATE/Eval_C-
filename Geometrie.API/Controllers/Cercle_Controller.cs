using Geometrie.API.DTO;
using Geometrie.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Geometrie.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CercleController : ControllerBase
    {
        private readonly IService<Cercle_DTO> _cercleService;

        public CercleController(IService<Cercle_DTO> cercleService)
        {
            _cercleService = cercleService;
        }

        // GET: api/Cercle
        [HttpGet]
        public ActionResult<IEnumerable<Cercle_DTO>> GetAll()
        {
            var cercles = _cercleService.GetAll();
            return Ok(cercles);
        }

        // GET: api/Cercle/{id}
        [HttpGet("{id}")]
        public ActionResult<Cercle_DTO> GetById(int id)
        {
            var cercle = _cercleService.GetById(id);
            if (cercle == null)
            {
                return NotFound($"Cercle with Id = {id} not found.");
            }
            return Ok(cercle);
        }

        // POST: api/Cercle
        [HttpPost]
        public ActionResult<Cercle_DTO> Add([FromBody] Cercle_DTO cercleDTO)
        {
            if (cercleDTO == null)
            {
                return BadRequest("Cercle data is null.");
            }

            var createdCercle = _cercleService.Add(cercleDTO);
            return CreatedAtAction(nameof(GetById), new { id = createdCercle.Id }, createdCercle);
        }

        // PUT: api/Cercle/{id}
        [HttpPut("{id}")]
        public ActionResult<Cercle_DTO> Update(int id, [FromBody] Cercle_DTO cercleDTO)
        {
            if (cercleDTO == null || cercleDTO.Id != id)
            {
                return BadRequest("Invalid Cercle data.");
            }

            var updatedCercle = _cercleService.Update(cercleDTO);
            return Ok(updatedCercle);
        }

        // DELETE: api/Cercle/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingCercle = _cercleService.GetById(id);
            if (existingCercle == null)
            {
                return NotFound($"Cercle with Id = {id} not found.");
            }

            _cercleService.Delete(id);
            return NoContent();
        }
    }
}
