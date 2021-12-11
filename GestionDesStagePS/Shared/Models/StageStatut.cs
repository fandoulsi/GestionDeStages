﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesStagePS.Shared.Models
{
    public class StageStatut
    {
        [Key]
        public int StageStatutId { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Le titre est trop long.")]
        public string Titre { get; set; }
    }
}