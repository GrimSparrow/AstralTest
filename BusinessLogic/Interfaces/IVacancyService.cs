using System.Linq;
using System.Collections.Generic;
using Models;

namespace BusinessLogic.Interfaces
{
    public interface IVacancyService
    {
        IQueryable<Vacancy> GetVacancies();
        Vacancy GetVacancyById(long id);
        void InsertVacancy(Vacancy vacancy);
        void InsertVacancies(IEnumerable<Vacancy> vacancies);
        void UpdateVacancy(Vacancy vacancy);
        void DeleteVacancy(long id);
    }
}
