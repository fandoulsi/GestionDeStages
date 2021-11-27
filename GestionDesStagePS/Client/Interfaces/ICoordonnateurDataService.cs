using GestionDesStagePS.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesStagePS.Client.Interfaces
{
    public interface ICoordonnateurDataService
    {
        Task<Coordonnateur> GetCoordonnateurById(string Id);

        Task<Coordonnateur> AddCoordonnateur(Coordonnateur coordonateur);

        Task UpdateCoordonnateur(Coordonnateur coordonnateur);
    }
}
