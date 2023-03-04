using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaRapidiagnostics.ApplicationCore.DTOs.Services
{
    public class ProductoDto
    {
        public ProductoDto()
        {

        }

        public ProductoDto(Producto productoDb)
        {
            Id = productoDb.IdProducto;
            Nombre = productoDb.Nombre;
            Codigo = productoDb.Codigo;
            Cantidad = (productoDb.Cantidad ?? 0).ToString("N2").Replace(".", "$").Replace(",", ".").Replace("$", ",");
            Precio = (productoDb.Precio ?? 0).ToString("N2").Replace(".", "$").Replace(",", ".").Replace("$", ",");
            Tipo = productoDb.IdTipo ?? 0;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Cantidad { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Precio { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int Tipo { get; set; }
    }
}
