using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class InvoiceDetailContext : DbContext
    {
        public InvoiceDetailContext(DbContextOptions<InvoiceDetailContext> options) : base(options)
        {

        }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Stavke> Stavke { get; set; }
    }
}
