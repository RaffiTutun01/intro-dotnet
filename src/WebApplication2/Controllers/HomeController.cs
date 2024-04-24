using DataProvider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonRepository _personRepository;
        

        public HomeController(ILogger<HomeController> logger, IPersonRepository personRepository)
        {
            _logger = logger;
            _personRepository = personRepository;
        }

        public IActionResult Index()
        {
            return View(getData());
        }

        public List<Person> getData()
        {
            return _personRepository.GetAll().ToList();
        }

        [HttpPost]

        public IActionResult Create([FromForm] string firstName, [FromForm] string lastName, [FromForm]  string age)
        {
            _personRepository.Create(firstName, lastName, int.Parse(age));
            return Redirect("/");
        }

        [HttpPost]
        
        public IActionResult Delete([FromForm] Guid id)
        {
            _personRepository.Delete(id);
            return Redirect("/");
        }

        public IActionResult Update([FromForm] Guid id, [FromForm] string firstName, [FromForm] string lastName, [FromForm] string age)
        {
            _personRepository.Update(id, firstName, lastName, int.Parse(age));
            return Redirect("/");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
