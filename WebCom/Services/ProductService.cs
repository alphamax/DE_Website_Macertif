using WebCom.Data;
using WebCom.Services.Interfaces;

namespace WebCom.Services
{
    public class ProductService : IProductService
    {
        private WebComContext _Context;
        public ProductService(WebComContext context)
        {
            _Context = context;
        }

        public List<Product> GetProducts()
        {
            var products = _Context.Products.ToList();
            return products;
        }
    }
}
