using GestionDesStagePS.Shared.Models;

namespace GestionDesStagePS.Server.Interface
{
    public interface IEtudiantRepository
    {
        Etudiant GetEtudiantById(string Id);

        Etudiant AddEtudiant(Etudiant etudiant);

        Etudiant UpdateEtudiant(Etudiant etudiant);
    }
}
