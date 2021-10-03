using GestionDesStagePS.Server.Interface;
using GestionDesStagePS.Shared.Models;
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
    public class StageController : ControllerBase

    {
        private readonly IStageRepository _stageRepository;
        private readonly IStageStatutRepository stageStatutRepository;

        public StageController(IStageRepository stageRepository, IStageStatutRepository stageStatutRepository)
        {
            this._stageRepository = stageRepository;
            this.stageStatutRepository = stageStatutRepository;
        }
        [HttpPost]
        public IActionResult CreateStage([FromBody] Stage stage)
        {
            if (stage == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = _stageRepository.AddStage(stage);

            return Created("stage", created);
        }
    }
}
