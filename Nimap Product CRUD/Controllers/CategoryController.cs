using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nimap_Product_CRUD.Contarcts;
using Nimap_Product_CRUD.Repository;

namespace Nimap_Product_CRUD.Controllers
{
    public class CategoryController : Controller
    {


        readonly ICategoryRepository _categoryRepository;
        readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public IActionResult Category()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SaveCategory(Category category)
        {
            var model = _mapper.Map<Models.Category>(category);
            return Json(await _categoryRepository.SaveCategory(model));
        }

        [HttpGet]
        public async Task<IActionResult> ViewCategory(int CategoryId)
        {
            var category = await _categoryRepository.ViewCategory(CategoryId);
            var response = _mapper.Map<Category>(category);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteCategory(int CategoryId)
        {
            return Json(await _categoryRepository.DeleteCategory(CategoryId));
        }
        [HttpGet]
        public async Task<JsonResult> CategoryList(string search, int start, int length, string sortColumn, string sortDir)
        {
            var dataParameter = new Models.DataParameterList
            {
                Start = start,
                Length = length,
                Search = search ?? "", 
                SortColumn = sortColumn,
                SortDir = sortDir     
            };

            var categories = await _categoryRepository.CategoryList(dataParameter);
            var totalRecords = categories.Select(t => t.TotalCount).FirstOrDefault();
            var data = categories.Select(c => new
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
                InActiveText = c.InActiveText
              
            }).ToList();

            return Json(new
            {
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords, 
                data = data
            });
        }

        [HttpPost]
        public async Task<ActionResult> ValCategory(string categoryName)
        {
            return Json(await _categoryRepository.ValCategory(categoryName));
        }
    }

}
