using GestionDesStagePS.Server.Interface;
using GestionDesStagePS.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionDesStagePS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordonateurController : Controller
    {

        private readonly ICoordonnateurRepository _coordonnateurRepository;

        public CoordonateurController(ICoordonnateurRepository coordonnateurRepository)
        {
            _coordonnateurRepository = coordonnateurRepository;
        }

        [HttpGet("{Id}")]
        public IActionResult GetCoordonateurById(string Id)
        {

            var coordonnateurExiste = _coordonnateurRepository.GetCoordonnateurById(Id);
            if (coordonnateurExiste != null)
            {
                // L'étudiant existe retourner l'entité trouvée
                return Ok(coordonnateurExiste);
            }
            // L'étudiant n'existe pas retourner une instance Coordonateur vide.
            // car retourner null fait bugger la DeserializeAsync dans le dataservice : The input does not contain any JSON tokens. Expected the input to start with a valid JSON token,
            return Ok(new Coordonnateur());
        }

        [HttpPost]
        public IActionResult CreateCoordonateur([FromBody] Coordonnateur coordonnateur)
        {
            if (coordonnateur == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = _coordonnateurRepository.AddCoordonnateur(coordonnateur);

            return Created("coordonnateur", created);
        }

        [HttpPut]
        public IActionResult UpdateCoordonateur([FromBody] Coordonnateur coordonnateur)
        {
            if (coordonnateur == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // S'assurer que le stage existe dans la table avant de faire la mise à jour
            var coordonnateurToUpdate = _coordonnateurRepository.GetCoordonnateurById(coordonnateur.Id.ToString());

            if (coordonnateurToUpdate == null)
                return NotFound();

            _coordonnateurRepository.UpdateCoordonnateur(coordonnateur);

            return NoContent(); //success
        }
    }
}
