using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrowdsourcingX.Infra.UnitOfWork;
using CrowdsourcingX.Web.Models;
using CrowdsourcingX.Infra.Entities;

namespace CrowdsourcingX.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _unitOfWork.UserRepository.AsQueryable().ToListAsync();
            return View(users);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,PaymentMethod,Age,Sex,Ethnicity,CountryOfOrigin,CountryOfResidence,Signature")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {

                var user = new User
                {
                    Name = userModel.Name,
                    Email = userModel.Email,
                    PaymentMethod = userModel.PaymentMethod,
                    Age = userModel.Age,
                    Sex = userModel.Sex,
                    Ethnicity = userModel.Ethnicity,
                    CountryOfOrigin = userModel.CountryOfOrigin,
                    CountryOfResidence = userModel.CountryOfResidence,
                    Signature = userModel.Signature.Split(",")[1],
                };
                _unitOfWork.UserRepository.Add(user);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userModel);
        }
    }
}
