using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Releye_List.Models;

namespace Releye_List.Data
{
    public class Releye_ListContext : DbContext
    {
        public Releye_ListContext (DbContextOptions<Releye_ListContext> options)
            : base(options)
        {
        }

        public DbSet<Releye_List.Models.KundLista> KundLista { get; set; }

        public DbSet<Releye_List.Models.LandLista> LandLista { get; set; }
    }
}
