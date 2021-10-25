
using GestionDesStagePS.Server.Data;
using GestionDesStagePS.Server.Interface;
using GestionDesStagePS.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace GestionDesStagePS.Server.Repositories
{
    public class EtudiantRepository : IEtudiantRepository
    {

        private readonly ApplicationDbContext _appDbContext;
        private readonly ILogger<EtudiantRepository> _logger;

        public EtudiantRepository(ApplicationDbContext appDbContext, ILogger<EtudiantRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }


        public Etudiant GetEtudiantById(string Id)
        {
            // Obtenir la fiche de l'�tudiant
            return _appDbContext.Etudiant.AsNoTracking().FirstOrDefault(c => c.Id == Id);
        }

        public Etudiant AddEtudiant(Etudiant etudiant)
        {
            try
            {
                var addedEntity = _appDbContext.Etudiant.Add(etudiant);
                _appDbContext.SaveChanges();
                return addedEntity.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erreur dans la cr�ation d'un enregistrement {ex}");
                return null;
            }
        }

        public Etudiant UpdateEtudiant(Etudiant etudiant)
        {
            // Rechercher le stage afin d'indiquer au contexte le stage � mettre � jour
            var foundEtudiant = _appDbContext.Etudiant.FirstOrDefault(e => e.Id == etudiant.Id);
            if (foundEtudiant != null)
            {
                foundEtudiant.Prenom = etudiant.Prenom;
                foundEtudiant.Nom = etudiant.Nom;
                foundEtudiant.TelephoneCellulaire = etudiant.TelephoneCellulaire;
                _appDbContext.SaveChanges();
            }
            return foundEtudiant;
        }
    }
}
