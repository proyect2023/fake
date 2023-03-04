using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaRapidiagnostics.ApplicationCore.DTOs
{
    public class MethodResponseDto
    {
        public dynamic Data { get; set; }
        public bool Estado { get; set; }
        public string  Mensaje { get; set; }
        public bool TieneErrores { get; set; }
        public string MensajeError { get; set; }
    }
}
