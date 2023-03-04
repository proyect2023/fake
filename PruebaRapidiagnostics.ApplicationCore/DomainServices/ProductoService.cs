using PruebaRapidiagnostics.ApplicationCore.DTOs;
using PruebaRapidiagnostics.ApplicationCore.DTOs.Services;
using PruebaRapidiagnostics.ApplicationCore.Interfaces.Repositories;
using PruebaRapidiagnostics.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaRapidiagnostics.ApplicationCore.DomainServices
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }

        public MethodResponseDto ConsultarProductos()
        {
            MethodResponseDto methodResponseDto = new MethodResponseDto();

            try
            {
                methodResponseDto.Data = productoRepository.GetProductos().Select(c => new ProductoDto(c)).ToList();
                methodResponseDto.Estado = true;
            }
            catch (Exception ex)
            {
                methodResponseDto.TieneErrores = true;
                methodResponseDto.MensajeError = ex.Message;
            }

            return methodResponseDto;
        }

        public MethodResponseDto ConsultarProducto(int id)
        {
            MethodResponseDto methodResponseDto = new MethodResponseDto();

            try
            {
                var producto = productoRepository.GetProducto(id);
                methodResponseDto.Data = new ProductoDto(producto);
                methodResponseDto.Estado = true;
            }
            catch (Exception ex)
            {
                methodResponseDto.TieneErrores = true;
                methodResponseDto.MensajeError = ex.Message;
            }

            return methodResponseDto;
        }

        public MethodResponseDto CrearProducto(ProductoDto productoDto)
        {
            MethodResponseDto methodResponseDto = new MethodResponseDto();

            try
            {
                Producto producto = new Producto
                {
                    Nombre = productoDto.Nombre,
                    Codigo = productoDto.Codigo,
                    Precio = decimal.Parse(productoDto.Precio.Replace(".", "$").Replace(",", ".").Replace("$", ",")),
                    Cantidad = decimal.Parse(productoDto.Cantidad.Replace(".", "$").Replace(",", ".").Replace("$", ",")),
                    FechaCreacion = DateTime.Now,
                    Estado = true,
                    IdTipo = productoDto.Tipo
                };
                
                methodResponseDto.Estado = productoRepository.AddProducto(producto) > 0;
            }
            catch (Exception ex)
            {
                methodResponseDto.TieneErrores = true;
                methodResponseDto.MensajeError = ex.Message;
            }

            return methodResponseDto;
        }

        public MethodResponseDto EditarProducto(ProductoDto productoDto)
        {
            MethodResponseDto methodResponseDto = new MethodResponseDto();

            try
            {
                var producto = productoRepository.GetProducto(productoDto.Id);
                if (producto is null)
                {
                    methodResponseDto.Mensaje = "Producto no encontrado";
                    methodResponseDto.Estado = false;
                    return methodResponseDto;
                }

                producto.IdTipo = productoDto.Tipo;
                producto.Nombre = productoDto.Nombre;
                producto.Codigo = productoDto.Codigo;
                producto.Precio = decimal.Parse(productoDto.Precio.Replace(".", "$").Replace(",", ".").Replace("$", ","));
                producto.Cantidad = decimal.Parse(productoDto.Cantidad.Replace(".", "$").Replace(",", ".").Replace("$", ","));
                producto.FechaModificacion = DateTime.Now;

                methodResponseDto.Estado = productoRepository.UpdateProducto(producto) > 0;
            }
            catch (Exception ex)
            {
                methodResponseDto.TieneErrores = true;
                methodResponseDto.MensajeError = ex.Message;
            }

            return methodResponseDto;
        }
        
        public MethodResponseDto EliminarProducto(int id)
        {
            MethodResponseDto methodResponseDto = new MethodResponseDto();

            try
            {
                var producto = productoRepository.GetProducto(id);
                if (producto is null)
                {
                    methodResponseDto.Mensaje = "Producto no encontrado";
                    methodResponseDto.Estado = false;
                    return methodResponseDto;
                }
                producto.Estado = false;
                producto.FechaEliminacion = DateTime.Now;

                methodResponseDto.Estado = productoRepository.UpdateProducto(producto) > 0;
            }
            catch (Exception ex)
            {
                methodResponseDto.TieneErrores = true;
                methodResponseDto.MensajeError = ex.Message;
            }

            return methodResponseDto;
        }


    }
}
