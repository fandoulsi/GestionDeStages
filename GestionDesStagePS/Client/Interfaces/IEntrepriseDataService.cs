using GestionDesStagePS.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesStagePS.Client.Interfaces
{
    public interface IEntrepriseDataService
    {
        Task<Entreprise> GetEntrepriseById(string Id);

        Task<Entreprise> AddEntreprise(Entreprise entreprise);

        Task UpdateEntreprise(Entreprise entreprise);
    }
}
