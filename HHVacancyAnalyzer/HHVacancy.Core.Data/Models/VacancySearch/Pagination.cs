using System;

namespace HHVacancy.Core.Data.Models.VacancySearch
{
    public class Pagination
    {
        public int TotalSize { get; set; }

        public int PageSize { get; set; }

        public int PagesCount => (int) Math.Ceiling((float) TotalSize / PageSize);
    }
}
