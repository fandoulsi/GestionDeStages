
using GestionDesStagePS.Server.Data;
using GestionDesStagePS.Server.Interface;
using GestionDesStagePS.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace GestionDesStagePS.Server.Repositories
{
    public class CoordonnateurRepository : ICoordonnateurRepository
    {

        private readonly ApplicationDbContext _appDbContext;
        private readonly ILogger<CoordonnateurRepository> _logger;

        public CoordonnateurRepository(ApplicationDbContext appDbContext, ILogger<CoordonnateurRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }


        public Coordonnateur GetCoordonnateurById(string Id)
        {
            // Obtenir la fiche de l'entreprise
            return _appDbContext.Coordonnateur.AsNoTracking().FirstOrDefault(c => c.Id == Id);
        }

        public Coordonnateur AddCoordonnateur(Coordonnateur coordonnateur)
        {
            try
            {
                var addedEntity = _appDbContext.Coordonnateur.Add(coordonnateur);
                _appDbContext.SaveChanges();
                return addedEntity.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erreur dans la création d'un enregistrement {ex}");
                return null;
            }
        }

        public Coordonnateur UpdateCoordonnateur(Coordonnateur coordonnateur)
        {
            // Rechercher le stage afin d'indiquer au contexte le stage à mettre à jour
            var foundCoordonnateur = _appDbContext.Coordonnateur.FirstOrDefault(e => e.Id == coordonnateur.Id);
            if (foundCoordonnateur != null)
            {
                foundCoordonnateur.Id = coordonnateur.Id;
                foundCoordonnateur.Nom = coordonnateur.Nom;
                foundCoordonnateur.Prenom = coordonnateur.Prenom;
                foundCoordonnateur.TelephoneCellulaire = coordonnateur.TelephoneCellulaire;
                foundCoordonnateur.NomInstitution = coordonnateur.NomInstitution;
                foundCoordonnateur.Remarques = coordonnateur.Remarques;
                _appDbContext.SaveChanges();
            }
            return foundCoordonnateur;
        }

       
    }
}
