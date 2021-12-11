using GestionDesStagePS.Shared.Models;

namespace GestionDesStagePS.Server.Interface
{
    public interface ICoordonnateurRepository
    {
        Coordonnateur GetCoordonnateurById(string Id);

        Coordonnateur AddCoordonnateur(Coordonnateur coordonnateur);

        Coordonnateur UpdateCoordonnateur(Coordonnateur coordonnateur);
    }
}
