using Microsoft.EntityFrameworkCore;

namespace solucion_urbano.Models
{
    public class ProveedorContext : DbContext
    {
        public ProveedorContext(DbContextOptions<ProveedorContext> options): base (options){

        }

        public DbSet<Proveedor> Proveedor {get;set;}
    }
}