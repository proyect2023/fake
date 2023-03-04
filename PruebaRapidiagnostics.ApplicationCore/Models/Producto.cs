namespace PruebaRapidiagnostics
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        public int? IdTipo { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        public decimal? Precio { get; set; }

        public decimal? Cantidad { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public DateTime? FechaEliminacion { get; set; }

        public bool? Estado { get; set; }

        [StringLength(20)]
        public string Codigo { get; set; }

        public virtual TipoProducto TipoProducto { get; set; }
    }
}
