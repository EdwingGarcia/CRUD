using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class ProductoController : Controller
{
    private readonly IProductoService _productoService;

    public ProductoController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    public async Task<IActionResult> Index()
    {
        var productos = await _productoService.GetAllProductos();
        return View(productos);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Producto producto)
    {
        await _productoService.CreateProducto(producto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int IdProducto)
    {
        var producto = await _productoService.GetProducto(IdProducto);
        if (producto != null) return View(producto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int IdProducto)
    {
        var producto = await _productoService.GetProducto(IdProducto);
        if (producto != null) return View(producto);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int IdProducto, Producto producto)
    {
        await _productoService.UpdateProducto(IdProducto, producto);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int IdProducto)
    {
        _productoService.DeleteProducto(IdProducto);
        return RedirectToAction("Index");
    }

}
