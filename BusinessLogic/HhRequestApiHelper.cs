using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace BusinessLogic
{
    public static class HhRequestApiHelper
    {
        private static string url = "https://api.hh.ru/vacancies?per_page=50";

        public static List<Vacancy> GetVacanciesFromHh()
        {
            List<Vacancy> vacancies = new List<Vacancy>();

            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myHttpWebRequest.Headers.Add("User-Agent", "HttpClient");

            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

            if (myHttpWebResponse.StatusCode == HttpStatusCode.OK)
            {
                Stream dataStream = myHttpWebResponse.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string strResponse = reader.ReadToEnd();
                dataStream.Close();

                JObject response = JObject.Parse(strResponse);

                var results = response["items"].Children();
                foreach (var res in results)
                {
                    var id = (int)res.SelectToken("id");
                    string name = (string)res.SelectToken("name");
                    string org = (string)res.SelectToken("employer.name");
                    var salaryFrom = (int?)res.SelectToken("salary.from");
                    var salaryTo = (int?)res.SelectToken("salary.to");

                    vacancies.Add(new Vacancy { Id = id, Name = name, Org = org, SalaryFrom = salaryFrom, SalaryTo = salaryTo, AddedDate = DateTime.Now });
                }
            }
            myHttpWebResponse.Close();
            return vacancies;
        }
    }
}
