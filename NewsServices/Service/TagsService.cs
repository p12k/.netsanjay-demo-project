using NewsModels.Model;
using NewsModels.Model.DTO.TagsDTO;
using NewsModels.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace NewsServices.Service
{
    public class TagsService : ITagsService
    {
        private readonly IGenericRepository<Tag> _tagRepository;
        public TagsService()
        {
            _tagRepository = new GenericRepository<Tag>();
        }
        public void DeleteTag(int id)
        {
            _tagRepository.Delete(id);
        }

        public GetTagsDTO GetTagById(int id)
        {
            Tag tag = _tagRepository.GetById(id);
            GetTagsDTO tagsDTO = new GetTagsDTO()
            {
                id = tag.id,
                tags = tag.tags
            };
            return tagsDTO;
        }

        public IList<GetTagsDTO> GetTags()
        {
            IList<Tag> tags = _tagRepository.Table.ToList<Tag>();
            IList<GetTagsDTO> tagsList = new List<GetTagsDTO>();
            foreach (var tag in tags)
            {
                GetTagsDTO tagsDTO = new GetTagsDTO()
                {
                    id = tag.id,
                    tags = tag.tags
                };
                tagsList.Add(tagsDTO);
            }
            return tagsList;

        }

        public void NewTag(CreateTagsDTO tagDTO)
        {
            Tag tag = new Tag()
            {
                tags = tagDTO.tags
            };
            _tagRepository.Insert(tag);
        }

        public void UpdateTag(UpdateTagsDTO tagDTO)
        {
            Tag tag = new Tag()
            {
                id = tagDTO.id,
                tags = tagDTO.tags
            };
            _tagRepository.Update(tag);
        }
    }
}