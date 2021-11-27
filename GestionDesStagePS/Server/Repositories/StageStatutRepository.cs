using GestionDesStagePS.Server.Interface;
using GestionDesStagePS.Shared.Models;
using GestionDesStagePS.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesStagePS.Server.Repositories
{
    public class StageStatutRepository : IStageStatutRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public StageStatutRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<StageStatut> GetAllStageStatuts()
        {
            return _appDbContext.StageStatut;
        }
    }
}
