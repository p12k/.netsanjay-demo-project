using NewsModels.Model.DTO;
using NewsModels.Model.DTO.ArticleCategoriesDTO;
using NewsModels.Model.DTO.CategoryDTO;
using NewsServices.Service;
using System.Collections.Generic;
using System.Web.Mvc;


namespace NewsNew1.Controllers
{
    public class ArticleCategoriesController : Controller
    {
        private readonly IArticlesService _articlesService;
        private readonly IArticleCategoriesService _articleCategoriesService;
        private readonly ICategoryService _categoryService;
        public ArticleCategoriesController()
        {
            _articlesService = new ArticlesService();
            _articleCategoriesService = new ArticleCategoriesService();
            _categoryService = new CategoryService();
        }

        // GET: ArticleCategories
        public ActionResult Index()
        {
            IEnumerable<GetArticleCategoriesDTO> articleCategories = _articleCategoriesService.GetArticleCategories();
            return View(articleCategories);
        }

        // GET: ArticleCategories/Details/5
        public ActionResult Details(int id)
        {
            GetArticleCategoriesDTO articleCategory = _articleCategoriesService.GetArticleCategoriesById(id);
            return View(articleCategory);
        }

        // GET: ArticleCategories/Create
        public ActionResult Create()
        {
            IEnumerable<GetArticleDTO> articles = _articlesService.GetArticles();
            ViewBag.articleid = new SelectList(articles, "id", "teaser");
            IEnumerable<GetCategoryDTO> categorys = _categoryService.GetCategories();
            ViewBag.categoryid = new SelectList(categorys, "id", "name");
            return View();
        }

        // POST: ArticleCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,articleid,categoryid")] CreateArticleCategoriesDTO articleCategory)
        {
            if (ModelState.IsValid)
            {
                _articleCategoriesService.NewArticleCategories(articleCategory);
                return RedirectToAction("Index");
            }
            return View(articleCategory);
        }

        // GET: ArticleCategories/Edit/5
        public ActionResult Edit(int id)
        {
            GetArticleCategoriesDTO articleCategory = _articleCategoriesService.GetArticleCategoriesById(id);
            IEnumerable<GetArticleDTO> Articles = _articlesService.GetArticles();
            ViewBag.articleid = new SelectList(Articles, "id", "teaser", articleCategory.articleId);
            IEnumerable<GetCategoryDTO> Categories = _categoryService.GetCategories();
            ViewBag.categoryid = new SelectList(Categories, "id", "name", articleCategory.categoryId);
            return View(articleCategory);
        }

        // POST: ArticleCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,articleid,categoryid")] UpdateArticleCategoriesDTO articleCategory)
        {
            if (ModelState.IsValid)
            {
                _articleCategoriesService.UpdateArticleCategories(articleCategory);
                return RedirectToAction("Index");
            }
            return View(articleCategory);
        }

        // GET: ArticleCategories/Delete/5
        public ActionResult Delete(int id)
        {
            GetArticleCategoriesDTO articleCategory = _articleCategoriesService.GetArticleCategoriesById(id);
            return View(articleCategory);
        }

        // POST: ArticleCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _articleCategoriesService.DeleteArticleCategories(id);
            return RedirectToAction("Index");
        }
    }
}
