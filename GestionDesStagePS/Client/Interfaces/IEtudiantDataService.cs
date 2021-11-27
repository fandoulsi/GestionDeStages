using GestionDesStagePS.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesStagePS.Client.Interfaces
{
    public interface IEtudiantDataService
    {
        Task<Etudiant> GetEtudiantById(string Id);

        Task<Etudiant> AddEtudiant(Etudiant etudiant);

        Task UpdateEtudiant(Etudiant etudiant);
    }
}
