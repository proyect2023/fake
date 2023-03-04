using Microsoft.Build.Framework;
using PruebaRapidiagnostics.ApplicationCore.DomainServices;
using PruebaRapidiagnostics.ApplicationCore.DTOs.Services;
using PruebaRapidiagnostics.ApplicationCore.Interfaces.Services;
using PruebaRapidiagnostics.Injectors;
using PruebaRapidiagnostics.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaRapidiagnostics.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoService productoService;

        public ProductoController()
        {
            var repo = new ProductoRepository();
            productoService = new ProductoService(repo);
        }

        public ActionResult Index()
        {
            List<ProductoDto> productos = new List<ProductoDto>();

            try
            {
                var result = productoService.ConsultarProductos();
                if (result.TieneErrores) throw new Exception(result.MensajeError);
                if (!result.Estado) TempData["Mensaje"] = result.Mensaje;
                else productos = result.Data;
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return View(productos);
        }

        public ActionResult Registrar(int? id)
        {
            ProductoDto producto = new ProductoDto();

            try
            {
                if ((id ?? 0) > 0)
                {
                    var result = productoService.ConsultarProducto(id ?? 0);
                    if (result.TieneErrores) throw new Exception(result.MensajeError);
                    if (!result.Estado) TempData["Mensaje"] = result.Mensaje;
                    else producto = result.Data;
                }
            }
            catch (Exception ex)
            {
                producto = new ProductoDto();
                TempData["Error"] = ex.Message;
            }

            return View(producto);
        }

        [HttpPost]
        public ActionResult Registrar(ProductoDto model)
        {
            ProductoDto producto = new ProductoDto();

            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {
                        var result = productoService.EditarProducto(model);
                        if (result.TieneErrores) throw new Exception(result.MensajeError);
                        if (result.Estado)
                        {
                            TempData["Mensaje"] = "Producto modificado";
                            return RedirectToAction("Index");
                        }
                        ModelState.AddModelError(string.Empty, result.Mensaje);
                    }
                    else
                    {
                        var result = productoService.CrearProducto(model);
                        if (result.TieneErrores) throw new Exception(result.MensajeError);
                        if (result.Estado)
                        {
                            TempData["Mensaje"] = "Producto creado";
                            return RedirectToAction("Index");
                        }
                        ModelState.AddModelError(string.Empty, result.Mensaje);
                    }
                }
            }
            catch (Exception ex)
            {
                producto = new ProductoDto();
                TempData["Error"] = ex.Message;
            }

            return View(producto);
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                var result = productoService.EliminarProducto(id);
                if (result.TieneErrores) throw new Exception(result.MensajeError);

                return Json(new { estado = result.Estado, mensaje = result.Mensaje });
            }
            catch (Exception ex)
            {
                return Json(new { estado = false, mensaje = ex.Message });
            }
        }
    }
}