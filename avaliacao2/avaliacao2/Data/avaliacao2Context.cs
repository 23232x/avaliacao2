using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using avaliacao2.Models;

namespace avaliacao2.Data
{
    public class avaliacao2Context : DbContext
    {
        public avaliacao2Context (DbContextOptions<avaliacao2Context> options)
            : base(options)
        {
        }

        public DbSet<avaliacao2.Models.Postagens>? Postagens { get; set; }
    }
}
