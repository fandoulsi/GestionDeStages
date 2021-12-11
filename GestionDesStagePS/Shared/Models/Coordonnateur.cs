using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesStagePS.Shared.Models
{
    public class Coordonnateur
    {
        [Key]
        [StringLength(450)]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        [Required]
        [StringLength(100)]
        public string Prenom { get; set; }

        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string TelephoneCellulaire { get; set; }

        [StringLength(300)]
        public string NomInstitution { get; set; }

        [StringLength(500)]
        public string Remarques { get; set; }
    }
}
