using GestionDesStagePS.Server.Interface;
using GestionDesStagePS.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionDesStagePS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtudiantController : Controller
    {

        private readonly IEtudiantRepository _etudiantRepository;

        public EtudiantController(IEtudiantRepository etudiantRepository)
        {
            _etudiantRepository = etudiantRepository;
        }

        [HttpGet("{Id}")]
        public IActionResult GetEtudiantById(string Id)
        {

            var etudiantExiste = _etudiantRepository.GetEtudiantById(Id);
            if (etudiantExiste != null)
            {
                // L'�tudiant existe retourner l'entit� trouv�e
                return Ok(etudiantExiste);
            }
            // L'�tudiant n'existe pas retourner une instance Etudiant vide.
            // car retourner null fait bugger la DeserializeAsync dans le dataservice : The input does not contain any JSON tokens. Expected the input to start with a valid JSON token,
            return Ok(new Etudiant());
        }

        [HttpPost]
        public IActionResult CreateEtudiant([FromBody] Etudiant etudiant)
        {
            if (etudiant == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = _etudiantRepository.AddEtudiant(etudiant);

            return Created("etudiant", created);
        }

        [HttpPut]
        public IActionResult UpdateEtudiant([FromBody] Etudiant etudiant)
        {
            if (etudiant == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // S'assurer que le stage existe dans la table avant de faire la mise � jour
            var etudiantToUpdate = _etudiantRepository.GetEtudiantById(etudiant.Id.ToString());

            if (etudiantToUpdate == null)
                return NotFound();

            _etudiantRepository.UpdateEtudiant(etudiant);

            return NoContent(); //success
        }
    }
}