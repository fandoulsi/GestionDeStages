using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDesStagePS.Shared.Models;

namespace GestionDesStagePS.Server.Interface
{
    public interface IEntrepriseRepository
    {
        Entreprise GetEntrepriseById(string Id);

        Entreprise AddEntreprise(Entreprise entreprise);

        Entreprise UpdateEntreprise(Entreprise entreprise);

    }
}
