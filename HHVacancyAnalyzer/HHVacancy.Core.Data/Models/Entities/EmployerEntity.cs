 public class Employer
    {
        public string Name { get; set; }

        public bool Trusted { get; set; }

        public bool AccreditedItEmployer { get; set; }

        public string AlternateUrl { get; set; }

        [Key]
        public string Id { get; set; }

        public string Url { get; set; }

        public string VacanciesUrl { get; set; }

        public bool Blacklisted { get; set; }

    }