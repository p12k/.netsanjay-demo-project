using NewsModels.Model.DTO.TagsDTO;
using NewsServices.Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NewsNew1.Controllers
{
    public class TagsController : Controller
    {
        private readonly ITagsService _tagsService;
        public TagsController()
        {
            _tagsService = new TagsService();
        }

        // GET: Tags
        public ActionResult Index()
        {
            IEnumerable<GetTagsDTO> Tags = _tagsService.GetTags();
            return View(Tags);
        }

        // GET: Tags/Details/5
        public ActionResult Details(int id)
        {
            GetTagsDTO tag = _tagsService.GetTagById(id);
            return View(tag);
        }

        // GET: Tags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tags")] CreateTagsDTO tag)
        {
            if (ModelState.IsValid)
            {
                _tagsService.NewTag(tag);
                return RedirectToAction("Index");
            }

            return View(tag);
        }

        // GET: Tags/Edit/5
        public ActionResult Edit(int id)
        {
            GetTagsDTO tag = _tagsService.GetTagById(id);
            return View(tag);
        }

        // POST: Tags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tags")] UpdateTagsDTO tag)
        {
            if (ModelState.IsValid)
            {
                _tagsService.UpdateTag(tag);
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        // GET: Tags/Delete/5
        public ActionResult Delete(int id)
        {
            GetTagsDTO tag = _tagsService.GetTagById(id);
            return View(tag);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _tagsService.DeleteTag(id);
            return RedirectToAction("Index");
        }

    }
}
