using Application.AppServices.FilesServices;

using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    
    public class FileLoaderController : Controller
    {
        private FileService _fileService;
        public FileLoaderController(FileService fileService)
        {
            _fileService = fileService;
        }
        // GET: FileController
        public ActionResult Index()
        {
            ViewData["userKey"] = "login-user";
            return View();
        }

        [HttpPost]
        // GET: FileController/Details/5
        public ActionResult Load([FromRoute] string userKey, [FromBody] IFormCollection form)
        {
            var f = form;
            var res = _fileService.LoadFile(userKey,f);
            return View();
        }

        // GET: FileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
