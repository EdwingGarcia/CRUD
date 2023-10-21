using CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class ProductoController : Controller
        
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "http://localhost:5075";

        public ProductoController()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_url)
            };
        }


        /// /////////////////////// /////////////////////// ////////////////////


        // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            var productos = await _httpClient.GetFromJsonAsync<List<Producto>>("api/Producto");
            return View(productos);
        }

     

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> Create(Producto producto)
        {
            await _httpClient.PostAsJsonAsync("api/Producto", producto);
            return RedirectToAction("Index");
        }

       

        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Details(int IdProducto)
        {
            var producto = await _httpClient.GetFromJsonAsync<Producto>($"api/Producto/{IdProducto}");
            if (producto != null) return View(producto);
            return RedirectToAction("Index"); 
        }


        public async Task<IActionResult> Edit(int IdProducto)
        {
            var producto = await _httpClient.GetFromJsonAsync<Producto>($"api/Producto/{IdProducto}");
            if (producto != null) return View(producto);
            return RedirectToAction("Index");
        }


        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int IdProducto)
        {
            await _httpClient.DeleteAsync($"api/Producto/{IdProducto}");

            return RedirectToAction("Index");
        }


    }
}
