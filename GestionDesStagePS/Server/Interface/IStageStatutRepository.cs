using GestionDesStagePS.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesStagePS.Server.Interface
{
    public interface IStageStatutRepository
    {
        IEnumerable<StageStatut> GetAllStageStatuts();
    }
}
