using NewsModels.Model.DTO.CategoryDTO;
using NewsServices.Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NewsNew1.Controllers
{
    public class CategoriesController : Controller
    {
        //private NewsDBEntities db = new NewsDBEntities();

        private readonly ICategoryService _categoryRepository;

        public CategoriesController()
        {
            _categoryRepository = new CategoryService();
        }

        //public CategoriesController(ICategoryRepository categoryRepository)
        //{
        //    _categoryRepository = categoryRepository;
        //}

        // GET: Categories
        public ActionResult Index()
        {
            IEnumerable<GetCategoryDTO> category = _categoryRepository.GetCategories();
            return View(category);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            GetCategoryDTO category = _categoryRepository.GetcategoryById(id);
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            //return PartialView("~/ View / Shared / _Layout.cshtml",PartialView);
            return PartialView("PartialCreate");
        }

       
        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,displayname")] CreateCategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.NewCategory(category);
                //_categoryRepository.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            GetCategoryDTO category = _categoryRepository.GetcategoryById(id);
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,displayname")] UpdateCategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.UpdateCategory(category);
                //_categoryRepository.Save(category);
                return RedirectToAction("Index");

            }
            else
            {
                return View(category);
            }
        }

        // GET: Categories/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            GetCategoryDTO category = _categoryRepository.GetcategoryById(id);
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _categoryRepository.DeleteCategory(id);
            //_categoryRepository.Save();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
