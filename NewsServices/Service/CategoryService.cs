using NewsModels.Model;
using NewsModels.Model.DTO.CategoryDTO;
using NewsModels.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace NewsServices.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        public CategoryService()
        {
            _categoryRepository = new GenericRepository<Category>();
        }
        public void DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
        }

        public IList<GetCategoryDTO> GetCategories()
        {
            IList<Category> categories = _categoryRepository.Table.ToList<Category>();
            IList<GetCategoryDTO> categoryList = new List<GetCategoryDTO>();
            foreach (var category in categories)
            {
                GetCategoryDTO CategoryDTO = new GetCategoryDTO()
                {
                    id = category.id,
                    name = category.name,
                    displayname = category.displayname

                };
                categoryList.Add(CategoryDTO);
            }

            return categoryList;
        }

        public GetCategoryDTO GetcategoryById(int id)
        {
            Category category = _categoryRepository.GetById(id);
            GetCategoryDTO categoryDTO = null;
            if (id != 0)
            {
                categoryDTO = new GetCategoryDTO()
                {
                    id = category.id,
                    name = category.name,
                    displayname = category.displayname
                };
            }
            return categoryDTO;
        }

        public void NewCategory(CreateCategoryDTO categoryDTO)
        {
            Category category = new Category()
            {
                name = categoryDTO.name,
                displayname = categoryDTO.displayname
            };
            _categoryRepository.Insert(category);
        }

        public void UpdateCategory(UpdateCategoryDTO categoryDTO)
        {
            Category category = new Category()
            {
                id = categoryDTO.id,
                name = categoryDTO.name,
                displayname = categoryDTO.displayname
            };
            _categoryRepository.Update(category);
        }
    }
}