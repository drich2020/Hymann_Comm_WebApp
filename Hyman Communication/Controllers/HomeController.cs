using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hyman_Communication.Models;
using Hyman_Communication.Data;
using Hyman_Communication.Contracts;
using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace Hyman_Communication.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IDocumentRepository _repo;
        private readonly IMapper _mapper;



        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

       
        public HomeController(IDocumentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Dashboard()
        {
            var documents = _repo.FinaAll().ToList();
            var model = _mapper.Map<List<Document>, List<DocumentVM>>(documents);
            return View(model);
           
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DocumentVM model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var document = _mapper.Map<Document>(model);
                document.DateCreated = DateTime.Now;

                var isSuccess = _repo.Create(document);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Market));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View();
            }
     
        }

        public IActionResult Search()
        {
            return View();
        }


        public IActionResult Publish()
        {
            return View();
        }

        public IActionResult Views()
        {
            return View();
        }

        // GET: Dashboard/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var document = _repo.FindById(id);
            var model = _mapper.Map<DocumentVM>(document);
            return View();
        }

        // POST: Dashboard/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DocumentVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var document = _mapper.Map<Document>(model);
                var isSuccess = _repo.Update(document);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong...");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View();
            }
        }

        // GET: Dashboard/Delete/5
        public ActionResult Delete(int id)
        {
            var document = _repo.FindById(id);
            if (document == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(document);
            if (!isSuccess)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Dashboard/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DocumentVM model)
        {
            try
            {
                // TODO: Add delete logic here
                var document = _repo.FindById(id);
                if (document == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(document);
                if (!isSuccess)
                {
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


#region Sample Upload Code 
/*
 
     public async Task UploadFile(IFileListEntry file, string picName)
        {
            try
            {
                var ms = new MemoryStream();
                await file.Data.CopyToAsync(ms);

                var path = $"{_env.WebRootPath}\\uploads\\{picName}";

                using(FileStream fs = new FileStream(path, FileMode.Create))
                {
                    ms.WriteTo(fs);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
     */
#endregion