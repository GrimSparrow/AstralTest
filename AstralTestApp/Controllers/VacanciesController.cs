using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interfaces;
using Models;
using AstralTestApp.Helpers;

namespace AstralTestApp.Controllers
{
    public class VacanciesController : Controller
    {
        private readonly IVacancyService vacancyService;

        public VacanciesController(IVacancyService vacancyService)
        {
            this.vacancyService = vacancyService;
        }
        public IActionResult Index()
        {
            //HtmlParser.GetHtml();

            /*Vacancy vac = new Vacancy {AddedDate = DateTime.Today ,Name = "Test", Org = "TestOrg", Salary = 1500000};
            Vacancy vac2 = new Vacancy { AddedDate = DateTime.Today, Name = "Test2", Org = "TestOrg2", Salary = 100000 };
            vacancyService.InsertVacancy(vac);
            vacancyService.InsertVacancy(vac2);
            List<Vacancy> vacs = new List<Vacancy>();
            vacs.Add(new Vacancy { AddedDate = DateTime.Today, Name = "Range1", Org = "TestOrg", Salary = 1500000 });
            vacs.Add(new Vacancy { AddedDate = DateTime.Today, Name = "Range2", Org = "TestOrg", Salary = 1500000 });
            vacancyService.InsertVacancies(vacs);*/
            //await _repository.CreateAsync(vac);
            return View();
        }

        public void Load()
        {
            HtmlParser.GetHtml();

            /*Vacancy vac = new Vacancy {AddedDate = DateTime.Today ,Name = "Test", Org = "TestOrg", Salary = 1500000};
            Vacancy vac2 = new Vacancy { AddedDate = DateTime.Today, Name = "Test2", Org = "TestOrg2", Salary = 100000 };
            vacancyService.InsertVacancy(vac);
            vacancyService.InsertVacancy(vac2);
            List<Vacancy> vacs = new List<Vacancy>();
            vacs.Add(new Vacancy { AddedDate = DateTime.Today, Name = "Range1", Org = "TestOrg", Salary = 1500000 });
            vacs.Add(new Vacancy { AddedDate = DateTime.Today, Name = "Range2", Org = "TestOrg", Salary = 1500000 });
            vacancyService.InsertVacancies(vacs);*/
            //await _repository.CreateAsync(vac);
        }
    }
}