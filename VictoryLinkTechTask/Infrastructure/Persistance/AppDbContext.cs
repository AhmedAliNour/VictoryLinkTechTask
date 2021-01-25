using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VictoryLinkTechTask.Domain.Models;

namespace VictoryLinkTechTask.Infrastructure.Persistance
{
    public class AppDbContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
    }
}