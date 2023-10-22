using CRUD.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CRUD.Services
{
    public class ProductoService : IProductoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "http://localhost:5075";

        public ProductoService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_url)
            };
        }

        public async Task<List<Producto>> GetAllProductos()
        {
            // Realiza una solicitud HTTP para obtener todos los productos
            var response = await _httpClient.GetFromJsonAsync<List<Producto>>("api/Producto");
            return response;
        }

        public async Task<Producto> GetProducto(int IdProducto)
        {
            // Realiza una solicitud HTTP para obtener un producto por su Id
            var response = await _httpClient.GetFromJsonAsync<Producto>($"api/Producto/{IdProducto}");
            return response;
        }

        public async Task<Producto> CreateProducto(Producto producto)
        {
            // Realiza una solicitud HTTP para crear un producto
            var response = await _httpClient.PostAsJsonAsync("api/Producto", producto);
            return await response.Content.ReadFromJsonAsync<Producto>();
        }

        public async Task<Producto> UpdateProducto(int IdProducto, Producto producto)
        {
            // Realiza una solicitud HTTP para actualizar un producto
            var response = await _httpClient.PutAsJsonAsync($"api/Producto/{IdProducto}", producto);
            return await response.Content.ReadFromJsonAsync<Producto>();
        }

        // Cambiar el tipo de retorno a void
        public async void DeleteProducto(int IdProducto)
        {
            // Realiza una solicitud HTTP para eliminar un producto
             _httpClient.DeleteAsync($"api/Producto/{IdProducto}");
        }

    }
}
