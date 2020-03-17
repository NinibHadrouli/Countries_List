using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Releye_List.Models
{
    public class KundLista
    {
        //******* properties ***********
        public int Id { get; set; }

        [StringLength(30)]
        [Display(Name = "KundNamn")]
        [Required (ErrorMessage ="Kundnamn krävs"),]
        public string Namn { get; set; }

        //******* Navigation properties ***********
        public int LandListaId { get; set; }
        public LandLista LandLista { get; set; }
    }
}
