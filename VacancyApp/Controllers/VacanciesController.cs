using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using BusinessLogic;
using BusinessLogic.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VacancyApp.Controllers
{
    [Route("api/[controller]")]
    public class VacanciesController : Controller
    { 
        private readonly IVacancyService vacancyService;
        public VacanciesController(IVacancyService vacancyService)
        {
            this.vacancyService = vacancyService;
        }

        [HttpGet("[action]")]
        public JsonResult GetVacanciesFromDb()
        {
            var vacancies = vacancyService.GetVacancies().ToList();

            try
            {
                var reqVacs = HhRequestApiHelper.GetVacanciesFromHh();
                foreach (var item in reqVacs)
                {
                    if (vacancies.All(v => v.Id != item.Id))
                    {
                        vacancyService.InsertVacancy(item);
                        vacancies.Add(item);
                    }
                }
            }
            catch (WebException e)
            {
                return Json(vacancies);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nThe following Exception was raised : {0}", e.Message);
            }
            return Json(vacancies);
        }

        [HttpGet("[action]")]
        public JsonResult FindByString(string search)
        {
          var vacancies = vacancyService.GetVacancies();
            vacancies = String.IsNullOrEmpty(search)
                ? vacancies
                : vacancies.Where(v => v.Name.ToLower().Contains(search.ToLower()) || v.Org.ToLower().Contains(search.ToLower()));
            return Json(vacancies.ToList());
        }
    }
}
