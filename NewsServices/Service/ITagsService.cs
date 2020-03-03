using NewsModels.Model.DTO.TagsDTO;
using System.Collections.Generic;

namespace NewsServices.Service
{
    public interface ITagsService
    {
        IList<GetTagsDTO> GetTags();
        GetTagsDTO GetTagById(int id);
        void NewTag(CreateTagsDTO tagDTO);
        void UpdateTag(UpdateTagsDTO tagDTO);
        void DeleteTag(int id);
    }
}
