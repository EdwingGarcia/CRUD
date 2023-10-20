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
                new Producto(){IdProducto=1,Nombre="NICO", Descripcion="LO LOGRASTE, ESTOY ORGULLOSO", Cantidad=12},
                new Producto(){IdProducto=2,Nombre="Sebas", Descripcion="Hola", Cantidad=1},
                new Producto(){IdProducto=5,Nombre="Rusky", Descripcion="Bai", Cantidad=22},
                new Producto(){IdProducto=3,Nombre="Tilin", Descripcion="Setso", Cantidad=4}
                
                );    
        }



    }
}
