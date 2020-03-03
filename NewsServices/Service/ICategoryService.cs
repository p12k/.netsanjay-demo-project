using NewsModels.Model.DTO.CategoryDTO;
using System.Collections.Generic;

namespace NewsServices.Service
{
    public interface ICategoryService
    {
        IList<GetCategoryDTO> GetCategories();
        GetCategoryDTO GetcategoryById(int id);
        void NewCategory(CreateCategoryDTO categoryDTO);
        void UpdateCategory(UpdateCategoryDTO categoryDTO);
        void DeleteCategory(int id);
    }
}
