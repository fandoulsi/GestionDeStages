using GestionDesStagePS.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesStagePS.Client.Interfaces
{
    public interface IStageStatutDataService
    {
        Task<IEnumerable<StageStatut>> GetAllStageStatuts();
    }
}
