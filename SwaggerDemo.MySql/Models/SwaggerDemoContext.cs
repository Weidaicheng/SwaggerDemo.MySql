using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDemo.MySql.Models
{
    public class SwaggerDemoContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public SwaggerDemoContext(DbContextOptions<SwaggerDemoContext> options)
            : base(options)
        { }
    }
}
