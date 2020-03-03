using NewsModels.Model.DTO.AuthorDTO;
using System.Collections.Generic;

namespace NewsServices.Service
{
    public interface IAuthorService
    {
        IList<GetAuthorDTO> GetAuthors();
        GetAuthorDTO GetAuthorById(int id);
        void NewAuthor(CreateAuthorDTO author);
        void UpdateAuthor(UpdateAuthorDTO author);
        void DeleteAuthor(int id);
        //void Save(Author author);
    }
}
