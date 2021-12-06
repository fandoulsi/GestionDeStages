
using GestionDesStagePS.Server.Data;
using GestionDesStagePS.Server.Interface;
using GestionDesStagePS.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace GestionDesStagePS.Server.Repositories
{
    public class EntrepriseRepository : IEntrepriseRepository
    {

        private readonly ApplicationDbContext _appDbContext;
        private readonly ILogger<EntrepriseRepository> _logger;

        public EntrepriseRepository(ApplicationDbContext appDbContext, ILogger<EntrepriseRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }


        public Entreprise GetEntrepriseById(string Id)
        {
            // Obtenir la fiche de l'entreprise
            return _appDbContext.Entreprise.AsNoTracking().FirstOrDefault(c => c.Id == Id);
        }

        public Entreprise AddEntreprise(Entreprise entreprise)
        {
            try
            {
                var addedEntity = _appDbContext.Entreprise.Add(entreprise);
                _appDbContext.SaveChanges();
                return addedEntity.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erreur dans la création d'un enregistrement {ex}");
                return null;
            }
        }

        public Entreprise UpdateEntreprise(Entreprise entreprise)
        {
            // Rechercher le stage afin d'indiquer au contexte le stage à mettre à jour
            var foundEntreprise = _appDbContext.Entreprise.FirstOrDefault(e => e.Id == entreprise.Id);
            if (foundEntreprise != null)
            {
                foundEntreprise.NomEntreprise = entreprise.NomEntreprise;
                foundEntreprise.NomResponsable = entreprise.NomResponsable;
                foundEntreprise.PrenomResponsable = entreprise.PrenomResponsable;
                foundEntreprise.Telephone = entreprise.Telephone;
                foundEntreprise.PosteTelephonique = entreprise.PosteTelephonique;
                foundEntreprise.DateCreation = entreprise.DateCreation;
                foundEntreprise.DateModification = entreprise.DateModification;
                _appDbContext.SaveChanges();
            }
            return foundEntreprise;
        }
    }
}
