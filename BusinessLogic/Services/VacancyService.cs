using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using DBRepository.Interfaces;
using Models;

namespace BusinessLogic.Services
{
    public class VacancyService : IVacancyService
    {
        private IRepository<Vacancy> vacancyRepository;

        public VacancyService(IRepository<Vacancy> vacancyRepository)
        {
            this.vacancyRepository = vacancyRepository;
        }

        public IQueryable<Vacancy> GetVacancies()
        {
            return vacancyRepository.GetAll();
        }

        public Vacancy GetVacancyById(long id)
        {
            return vacancyRepository.Get(id);
        }

        public void InsertVacancy(Vacancy vacancy)
        {
            vacancyRepository.Insert(vacancy);
        }

        public void InsertVacancies(IEnumerable<Vacancy> vacancies)
        {
            vacancyRepository.InsertVacancies(vacancies);
        }
        public void UpdateVacancy(Vacancy vacancy)
        {
            vacancyRepository.Update(vacancy);
        }

        public void DeleteVacancy(long id)
        {
            Vacancy vacancy = GetVacancyById(id);
            vacancyRepository.Remove(vacancy);
        }
    }
}
