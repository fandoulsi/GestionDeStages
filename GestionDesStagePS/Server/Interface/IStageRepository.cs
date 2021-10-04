using GestionDesStagePS.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesStagePS.Server.Interface
{
    public interface IStageRepository
    {
        Stage AddStage(Stage stage);
        IEnumerable<Stage> GetAllStages();
    }
}
