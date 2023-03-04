using PruebaRapidiagnostics.ApplicationCore.DTOs.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace PruebaRapidiagnostics
{
    public partial class EFContext : DbContext
    {
        public EFContext()
            : base("name=EFContext")
        {
            //Database.SetInitializer<EFContext>(new Initializer());
        }

        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<TipoProducto> TipoProducto { get; set; }
        public virtual DbSet<ProductoDto> ProductoDto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Precio)
                .HasPrecision(18, 6);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Cantidad)
                .HasPrecision(18, 6);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<TipoProducto>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<ProductoDto>().MapToStoredProcedures();
        }

        //public virtual List<Producto> QRY_Productos(string accion, int? idProducto, int? idTipo, string nombre, decimal? precio, decimal? cantidad)
        //{
        //    var accionParameter = accion != null ?
        //        new ObjectParameter("Accion", accion) :
        //        new ObjectParameter("Accion", typeof(string));

        //    var idProductoParameter = idProducto.HasValue ?
        //        new ObjectParameter("IdProducto", idProducto) :
        //        new ObjectParameter("IdProducto", typeof(int));

        //    var idTipoParameter = idTipo.HasValue ?
        //        new ObjectParameter("IdTipo", idTipo) :
        //        new ObjectParameter("IdTipo", typeof(int));

        //    var nombreParameter = nombre != null ?
        //        new ObjectParameter("Nombre", nombre) :
        //        new ObjectParameter("Nombre", typeof(string));

        //    var precioParameter = precio.HasValue ?
        //        new ObjectParameter("Precio", precio) :
        //        new ObjectParameter("Precio", typeof(decimal));

        //    var cantidadParameter = cantidad.HasValue ?
        //        new ObjectParameter("Cantidad", cantidad) :
        //        new ObjectParameter("Cantidad", typeof(decimal));

        //    return EnumerableExecutor("QRY_Productos", accionParameter, idProductoParameter, idTipoParameter, nombreParameter, precioParameter, cantidadParameter);
        //}
    }
}
