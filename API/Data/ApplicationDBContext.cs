using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApplicationDBContext:DbContext
    {
        
        public ApplicationDBContext( DbContextOptions<ApplicationDBContext> options ) : base( options ) { }      
        public DbSet<Producto> Producto {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasData( 
                new Producto(){IdProducto=1,Nombre="Teléfono", Descripcion="Xiaomi Mi 9T Pro", Cantidad=12},
                new Producto(){IdProducto=2,Nombre="Casco", Descripcion="LS2 Raptor", Cantidad=1},
                new Producto(){IdProducto=5,Nombre="Audífono", Descripcion="Xiaomi Bunds 4", Cantidad=22},
                new Producto(){IdProducto=3,Nombre="Pc Gamer", Descripcion="Asus Tuf", Cantidad=4}
                
                );    
        }



    }
}
