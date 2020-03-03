using NewsModels.Model.DTO;
using NewsModels.Model.DTO.AuthorDTO;
using NewsServices.Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NewsNew1.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticlesService _articlesService;
        private readonly IAuthorService _authorService;

        public ArticlesController()
        {
            _articlesService = new ArticlesService();
            _authorService = new AuthorService();
        }

        // GET: Articles
        public ActionResult Index()
        {
            IEnumerable<GetArticleDTO> articles = _articlesService.GetArticles();
            return View(articles);
        }

        // GET: Articles/Details/5
        public ActionResult Details(int id)
        {
            GetArticleDTO article = _articlesService.GetArticleById(id);
            return View(article);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            IEnumerable<GetAuthorDTO> author = _authorService.GetAuthors();
            ViewBag.authorid = new SelectList(author, "id", "name");
            //IEnumerable<Author> author = _authorService.GetAuthors();
            //ViewBag.authorid = new SelectList(items: author, dataValueField: "id", dataTextField: "name", selectedValue: article.authorid);
            //ViewBag.authorid = _articlesService.Foreign(Author);
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,teaser,headline,subtitle,byline,lead,content,credit,authorid,leadimage,leadcaption,leadcredit,date,createddate")] CreateArticleDTO article)
        {
            if (ModelState.IsValid)
            {
                //var authorId = int.Parse(Request.Form["authorid"]);
                //article.authorid = authorId;
                _articlesService.NewArticle(article);
                //_categoryRepository.Save();
                return RedirectToAction("Index");
            }

            return View(article);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int id)
        {
            GetArticleDTO article = _articlesService.GetArticleById(id);
            IEnumerable<GetAuthorDTO> author = _authorService.GetAuthors();
            ViewBag.authorid = new SelectList(author, "id", "name");

            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,teaser,headline,subtitle,byline,lead,content,credit,authorid,leadimage,leadcaption,leadcredit,date,createddate")] UpdateArticleDTO article)
        {
            if (ModelState.IsValid)
            {
                _articlesService.UpdateArticle(article);
                //_articlesService.Save(article);
                return RedirectToAction("Index");
            }
            else
            {
                return View(article);
            }

        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int id)
        {
            GetArticleDTO article = _articlesService.GetArticleById(id);
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _articlesService.DeleteArticle(id);
            return RedirectToAction("Index");
        }


    }
}
