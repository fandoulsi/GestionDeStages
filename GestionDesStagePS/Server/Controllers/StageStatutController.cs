using GestionDesStagePS.Server.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesStagePS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StageStatutController : Controller
    {
        private readonly IStageStatutRepository _stageStatutRepository;

        public StageStatutController(IStageStatutRepository stageStatutRepository)
        {
            _stageStatutRepository = stageStatutRepository;
        }

        [HttpGet]
        public IActionResult GetAllStageStatuts()
        {
            return Ok(_stageStatutRepository.GetAllStageStatuts());
        }
    }
}
