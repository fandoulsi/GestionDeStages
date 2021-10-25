﻿using GestionDesStagePS.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesStagePS.Client.Interfaces
{
    public interface IStageDataService
    {
        Task<Stage> AddStage(Stage stage);
        Task<IEnumerable<Stage>> GetAllStages();

        Task<Stage> GetStageByStageId(string stageId);

        Task<PostulerStage> PostulerStage(PostulerStage postulerStage);
    }
}
