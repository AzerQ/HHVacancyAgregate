namespace HHVacancy.Models.API.VacancySearch
{
    public class Pagination
    {
        public int TotalSize { get; set; }

        public int PageSize { get; set; }

        public int PagesCount => (int)Math.Ceiling((float)TotalSize / PageSize);
    }
}
