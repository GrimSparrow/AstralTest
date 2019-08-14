namespace Models
{
    public class Vacancy : BaseModel
    {
        public string Name { get; set; }
        public string Org { get; set; }
        public int? SalaryFrom { get; set; }
        public int? SalaryTo { get; set; }
    }
}
