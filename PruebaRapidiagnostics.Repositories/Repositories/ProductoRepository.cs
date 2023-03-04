using PruebaRapidiagnostics.ApplicationCore.Consts;
using PruebaRapidiagnostics.ApplicationCore.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PruebaRapidiagnostics.Repositories.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        public ProductoRepository()
        {
            
        }

        public List<Producto> GetProductos()
        {
            using (var db = new EFContext())
            {
                var result = db.Producto.Where(x => x.Estado == true).ToList();
                db.Dispose();

                return result;
            }
        }
        
        public int UpdateProducto(Producto producto)
        {
            using (var db = new EFContext())
            {
                db.Entry(producto).State = System.Data.Entity.EntityState.Modified;
                var cont = db.SaveChanges();
                db.Dispose();
                return cont;
            }
        }
        
        public int AddProducto(Producto producto)
        {
            using (EFContext db = new EFContext())
            {
                db.Producto.Add(producto);
                var cont = db.SaveChanges();
                db.Dispose();
                return cont;
            }
        }

        public Producto GetProducto(int id)
        {
            using (var db = new EFContext())
            {
                var result = db.Producto.FirstOrDefault(x => x.IdProducto == id && x.Estado == true);
                db.Dispose();

                return result;
            }
        }
    }
}
