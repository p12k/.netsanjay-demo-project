using NewsModels.Model.DTO.CategoryDTO;
using NewsServices.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewsAPIs.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService _categoryRepository;

        public CategoriesController()
        {
            _categoryRepository = new CategoryService();
        }
        // GET: api/Categories
        public IHttpActionResult Get()
        {
            IList<GetCategoryDTO> category = _categoryRepository.GetCategories();
            if(category!=null)
                return Ok<IList<GetCategoryDTO>>(category);
            return NotFound();
        }

        // GET: api/Categories/5
        public IHttpActionResult Get(int id)
        {
            GetCategoryDTO category = _categoryRepository.GetcategoryById(id);
            if(category!=null)
                return Ok<GetCategoryDTO>(category);
            return NotFound();
        }
    }

        // POST: api/Categories
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Categories/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Categories/5
        public void Delete(int id)
        {
        }
    }
}
