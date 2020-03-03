using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsModels.Model.DTO.AuthorDTO
{
    public class CreateAuthorDTO
    {

        public string name { get; set; }
        public Nullable<System.DateTime> dob { get; set; }
        public string qualification { get; set; }
        public string profession { get; set; }

    }
}