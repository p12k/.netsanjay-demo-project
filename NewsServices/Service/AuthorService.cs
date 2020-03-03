using NewsModels.Model;
using NewsModels.Model.DTO.AuthorDTO;
using NewsModels.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace NewsServices.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IGenericRepository<Author> _Repository;
        public AuthorService()
        {
            //_dbContext = context;
            _Repository = new GenericRepository<Author>();
        }
        public void DeleteAuthor(int id)
        {
            _Repository.Delete(id);
        }

        public GetAuthorDTO GetAuthorById(int id)
        {
            Author author = _Repository.GetById(id);
            GetAuthorDTO authorDTO = null;
            if (id != 0)
            {
                authorDTO = new GetAuthorDTO()
                {
                    id = author.id,
                    name = author.name,
                    dob = author.dob,
                    qualification = author.qualification,
                    profession = author.profession
                };
            }
            return authorDTO;
        }

        public IList<GetAuthorDTO> GetAuthors()
        {
            IList<Author> authors = _Repository.Table.ToList<Author>();
            IList<GetAuthorDTO> authorList = new List<GetAuthorDTO>();
            foreach (var author in authors)
            {
                GetAuthorDTO authorDTO = new GetAuthorDTO()
                {
                    id = author.id,
                    name = author.name,
                    dob = author.dob,
                    qualification = author.qualification,
                    profession = author.profession
                };
                authorList.Add(authorDTO);
            }
            return authorList;
        }

        public void NewAuthor(CreateAuthorDTO authorDTO)
        {
            Author author = new Author()
            {
                name = authorDTO.name,
                dob = authorDTO.dob,
                qualification = authorDTO.qualification,
                profession = authorDTO.profession
            };
            _Repository.Insert(author);
        }

        //public void Save(Author author)
        //{
        //    _Repository.Save(author);
        //}

        public void UpdateAuthor(UpdateAuthorDTO authorDTO)
        {
            Author author = new Author()
            {
                id = authorDTO.id,
                name = authorDTO.name,
                dob = authorDTO.dob,
                qualification = authorDTO.qualification,
                profession = authorDTO.profession
            };
            _Repository.Update(author);
        }
    }
}