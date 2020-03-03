using NewsModels.Model.DTO.AuthorDTO;
using NewsServices.Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NewsNew1.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;
        public AuthorsController()
        {
            _authorService = new AuthorService();
        }

        // GET: Authors
        public ActionResult Index()
        {
            IEnumerable<GetAuthorDTO> author = _authorService.GetAuthors();
            return View(author);
        }

        // GET: Authors/Details/5
        public ActionResult Details(int id)
        {

            GetAuthorDTO author = _authorService.GetAuthorById(id);
            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,dob,qualification,profession")] CreateAuthorDTO author)
        {
            if (ModelState.IsValid)
            {
                _authorService.NewAuthor(author);
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int id)
        {
            GetAuthorDTO author = _authorService.GetAuthorById(id);
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,dob,qualification,profession")] UpdateAuthorDTO author)
        {
            if (ModelState.IsValid)
            {
                _authorService.UpdateAuthor(author);
                //_authorService.Save(author);
                return RedirectToAction("Index");
            }
            else
            {
                return View(author);
            }
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int id)
        {
            GetAuthorDTO author = _authorService.GetAuthorById(id);
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _authorService.DeleteAuthor(id);
            return RedirectToAction("Index");
        }
    }
}
