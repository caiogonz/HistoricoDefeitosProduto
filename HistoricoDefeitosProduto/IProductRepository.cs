using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoDefeitosProduto
{
    public interface IProductRepository
    {
        List<ProductDefect> GetAll();
        List<ProductDefect> GetBySerialNumber(string numeroSerie);
        void Add(ProductDefect product);
        void Update(ProductDefect product);
        void Delete(ProductDefect product);
    }

}
