﻿using GestionDesStagePS.Server.Models;
using GestionDesStagePS.Shared.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesStagePS.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<StageStatut> StageStatut { get; set; }
        public DbSet<Stage> Stage { get; set; }

        public DbSet<Etudiant> Etudiant { get; set; }
    
        public DbSet<PostulerStage> PostulerStage { get; set; }

        public DbSet<Entreprise> Entreprise { get; set; }

        public DbSet<Coordonnateur> Coordonnateur { get; set; }
    }
}