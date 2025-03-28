using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoDefeitosProduto
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        // Injeção de dependência para facilitar testes e manutenção (D - Dependency Inversion)
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public List<ProductDefect> GetAllProducts() => _repository.GetAll();

        public List<ProductDefect> SearchByTrackID(string trackID)
        {
            return _repository.GetByTrackID(trackID);
        }

        public void AddProduct(ProductDefect product)
        {
            // Aqui podemos adicionar regras de negócio se necessário
            product.DataHora = System.DateTime.Now;  // Data e Hora automáticas
            _repository.Add(product);
        }

        public void UpdateProduct(ProductDefect product)
        {
            _repository.Update(product);
        }

        public void DeleteProduct(ProductDefect product)
        {
            _repository.Delete(product);
        }
    }
}