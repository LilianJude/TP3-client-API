using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationWebASPNET.Models.EntityFramework;
using ApplicationWebASPNET.Models.DataManager;
using ApplicationWebASPNET.Models.Repository;

namespace ApplicationWebASPNET.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompteController : ControllerBase
    {
        private readonly IDataRepository<Compte> _dataRepository;
        public CompteController(IDataRepository<Compte> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Compte
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compte>>> GetCompte()
        {
            return await _dataRepository.GetAll();
        }

        // GET: api/Compte/5
        [HttpGet("{id}")]
        [ActionName("GetCompteById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Compte>> GetCompteById(int id)
        {
            var compte = _dataRepository.GetById(id);

            if (compte == null)
            {
                return NotFound("Compte non trouvé !");
            }

            return Ok(compte);
        }

        // GET: api/Compte/Email
        [HttpGet("{email}")]
        [ActionName("GetCompteByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Compte>> GetCompteByEmail(string email)
        {
            var compte = await _dataRepository.GetByString(email);

            if (compte == null)
            {
                return NotFound();
            }

            return compte;
        }

        // PUT: api/Compte/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutCompte(int id, Compte compte)
        {
            if (id != compte.CompteId)
            {
                return BadRequest();
            }

            var compteToUpdate = await _dataRepository.GetById(id);

            if (compteToUpdate == null)
            {
                return NotFound("Id compte inconnu !");
            }

            await _dataRepository.Update(compteToUpdate.Value, compte);

            return NoContent();
        }

        // POST: api/Compte
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Compte>> PostCompte(Compte compte)
        {
            await _dataRepository.Add(compte);

            return CreatedAtAction("GetCompte", new { id = compte.CompteId }, compte);
        }

        ////DELETE: api/Compte/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Compte>> DeleteCompte(int id)
        //{
        //    var compte = _dataRepository.GetById(id);
        //    if (compte == null)
        //    {
        //        return NotFound("Compte non trouvé !");
        //    }

        //    _dataRepository.Delete(compte.Value);

        //    return compte;
        //}

    }
}
