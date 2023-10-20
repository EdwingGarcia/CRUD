using CRUD.Models;

namespace CRUD.Util
{
    public class Utils
    {
        public static List<Producto> ListaProducto = new List<Producto>()
        {
            new Producto()
            {
                IdProducto = 1,
                Nombre="P",
                Descripcion="D",
                Cantidad=1
            }
        };

    }
}
