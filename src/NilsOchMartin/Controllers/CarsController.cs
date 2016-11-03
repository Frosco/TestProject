using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NilsOchMartin.Models;
using NilsOchMartin.Models.Entities;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NilsOchMartin.Controllers
{
    public class CarsController : Controller
    {
        CarDBContext context;

        // Konstruktor för att ta emot kontexten (prata med databasen)
        public CarsController(CarDBContext context)
        {
            this.context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var viewModel = await context.GetAllCarsAsync();
            return View(viewModel2);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarsCreateVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            await context.AddCarAsync(viewModel);

            return RedirectToAction(nameof(Index));
        }
    }
}
