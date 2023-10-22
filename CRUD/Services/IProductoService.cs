using CRUD.Models;

namespace CRUD.Services
{
    public interface IProductoService
    {
        Task<List<Producto>> GetAllProductos();
        Task<Producto> GetProducto(int IdProducto);
        Task<Producto> CreateProducto(Producto producto);
        Task<Producto> UpdateProducto(int IdProducto, Producto producto);
        void DeleteProducto(int IdProducto);
    }
}
