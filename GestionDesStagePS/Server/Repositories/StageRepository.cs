using GestionDesStagePS.Server.Interface;
using GestionDesStagePS.Shared.Models;
using GestionDesStagePS.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesStagePS.Server.Repositories
{
    public class StageRepository : IStageRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly ILogger<StageRepository> _logger;

        public StageRepository(ApplicationDbContext appDbContext, ILogger<StageRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public Stage AddStage(Stage stage)
        {
            var addedEntity = _appDbContext.Stage.Add(stage);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public IEnumerable<Stage> GetAllStages()
        {
            // Obtenir TOUS (n'importe quelle entreprise) les stages actifs
            return _appDbContext.Stage.Where(c => c.StageStatutId == 1).Include(c => c.StageStatut).OrderByDescending(t => t.DateCreation);
        }

        public Stage GetStageByStageId(string StageId)
        {
            // Obtenir un stage précis d'une entreprise
            return _appDbContext.Stage.Include(c => c.StageStatut).Include(c => c.Entreprise).FirstOrDefault(c => c.StageId == new Guid(StageId));
        }

        public PostulerStage PostulerStage(PostulerStage postulerStage)
        {
            try
            {
                // Vérifier si l'étudiant n'a pas déjà postuler pour ce stage.
                var foundPostulerStage = _appDbContext.PostulerStage.FirstOrDefault(e => e.StageId == postulerStage.StageId && e.Id == postulerStage.Id);

                // Si null il n'a pas postulé
                if (foundPostulerStage == null)
                {
                    var addedEntity = _appDbContext.PostulerStage.Add(postulerStage);
                    _appDbContext.SaveChanges();
                    return addedEntity.Entity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erreur dans la création d'un enregistrement {ex}");
                return null;
            }
        }
    }
}
