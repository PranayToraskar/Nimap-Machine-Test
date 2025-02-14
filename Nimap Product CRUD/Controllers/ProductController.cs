using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nimap_Product_CRUD.Contarcts;
using Nimap_Product_CRUD.Repository;

namespace Nimap_Product_CRUD.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductRepository _productRepository;
        readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Product()
        {
            var product = await _productRepository.ProductDropDown();
            var response = _mapper.Map<Product>(product);
            return View(response);
        }

        [HttpPost]
        public async Task<ActionResult> SaveProduct(Product product)
        {
            var data = _mapper.Map<Models.Product>(product);
            return Json(await _productRepository.SaveProduct(data));
        }

        [HttpGet]
        public async Task<IActionResult> ViewProduct(int ProductId)
        {
            var product = await _productRepository.ViewProduct(ProductId);
            var response = _mapper.Map<Product>(product);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteProduct(int ProductId)
        {
            return Json(await _productRepository.DeleteProduct(ProductId));
        }

        [HttpPost]
        public async Task<ActionResult> ValProduct(string ProductName,int CategoryID)
        {
            return Json(await _productRepository.ValProduct(ProductName, CategoryID));
        }

        [HttpGet]
        public async Task<JsonResult> ProductList(string search, int start, int length, string sortColumn, string sortDir)
        {
            var dataParameter = new Models.DataParameterList
            {
                Start = start,
                Length = length,
                Search = search ?? "",
                SortColumn = sortColumn,
                SortDir = sortDir
            };

            var products = await _productRepository.ProductList(dataParameter);
            var totalRecords = products.Select(t => t.TotalCount).FirstOrDefault();
            var data = products.Select(c => new
            {
                ProductID = c.ProductID,
                ProductName = c.ProductName,
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,

            }).ToList();

            return Json(new
            {
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
                data = data
            });
        }

    }
}
