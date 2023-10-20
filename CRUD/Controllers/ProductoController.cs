using CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class ProductoController : Controller
    {
        // GET: ProductoController
        public IActionResult Index()
        {
            return View(Util.Utils.ListaProducto);
        }

        // GET: ProductoController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Create(Producto producto)
        {
            int id = Util.Utils.ListaProducto.Count() + 1;
            producto.IdProducto = id;
            Util.Utils.ListaProducto.Add(producto);
            return RedirectToAction("Index");
        }

       
        // GET: ProductoController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }
     

        // GET: ProductoController/Delete/5
        public IActionResult Delete(int IdProducto)
        {
            Producto p = Util.Utils.ListaProducto.Find(x => x.IdProducto == IdProducto);
            if(p != null)
            {
                Util.Utils.ListaProducto.Remove(p);
            }
            return RedirectToAction("Index");
        }

  
    }
}
