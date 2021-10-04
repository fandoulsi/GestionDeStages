using GestionDesStagePS.Client.Interfaces;
using GestionDesStagePS.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesStagePS.Client.Pages
{
    public partial class StageView
    {
            [Inject]
            public IStageDataService StageDataService { get; set; }

            public List<Stage> Stages { get; set; } = new List<Stage>();

            protected override async Task OnInitializedAsync()
            {
                // Appel du service pour obtenir la liste des TOUS stages actifs
                Stages = (await StageDataService.GetAllStages()).ToList();
            }
        
    }
}
