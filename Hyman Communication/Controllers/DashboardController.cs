using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hyman_Communication.Models;
using Hyman_Communication.Data;
using Hyman_Communication.Contracts;
using AutoMapper;

namespace Hyman_Communication.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard

        private readonly IDocumentRepository _repo;
        private readonly IMapper _mapper;

        public DashboardController(IDocumentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public ActionResult Index()
        {
            var documents = _repo.FinaAll().ToList();
            var model = _mapper.Map<List<Document>, List<DocumentVM>>(documents);
            return View(model);
            //return View();
        }

        // GET: Dashboard/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var document = _repo.FindById(id);
            var model = _mapper.Map<DocumentVM>(document);
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        // GET: Dashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Document model)
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

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View();
            }
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
                var document= _repo.FindById(id);
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
    }
}