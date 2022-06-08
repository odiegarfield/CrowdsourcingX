using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrowdsourcingX.Infra.UnitOfWork;
using CrowdsourcingX.Web.Models;
using CrowdsourcingX.Infra.Entities;

namespace CrowdsourcingX.Web.Controllers
{
    public class PictureController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PictureController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var Pictures = await _unitOfWork.PictureRepository.AsQueryable().ToListAsync();
            return View(Pictures);
        }

        // GET: Picture/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Picture/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] PictureModel PictureModel)
        {
            if (ModelState.IsValid)
            {
                var Picture = new Picture
                {
                };
                _unitOfWork.PictureRepository.Add(Picture);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(PictureModel);
        }
    }
}
