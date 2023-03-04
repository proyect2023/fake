using PruebaRapidiagnostics.ApplicationCore.DTOs;
using PruebaRapidiagnostics.ApplicationCore.DTOs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaRapidiagnostics.ApplicationCore.Interfaces.Services
{
    public interface IProductoService
    {
        MethodResponseDto ConsultarProductos();
        MethodResponseDto ConsultarProducto(int id);
        MethodResponseDto CrearProducto(ProductoDto productoDto);
        MethodResponseDto EditarProducto(ProductoDto productoDto);
        MethodResponseDto EliminarProducto(int id);
    }
}
