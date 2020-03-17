using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Releye_List.Models
{
    public class LandLista
    {
        //******* properties ***********
        public int Id { get; set; }

        [StringLength(30)]
        [Display(Name = "Lands namn")]
        [Required(ErrorMessage = "Land namn krävs"),]
        public string Namn { get; set; }
    }
}
