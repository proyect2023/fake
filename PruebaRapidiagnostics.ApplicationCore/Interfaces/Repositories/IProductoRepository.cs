using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaRapidiagnostics.ApplicationCore.Interfaces.Repositories
{
    public interface IProductoRepository
    {
        List<Producto> GetProductos();

        int UpdateProducto(Producto producto);
        int AddProducto(Producto producto);
        Producto GetProducto(int id);
    }
}
