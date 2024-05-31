using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Employers")]
public class EmployerEntity
    {
        public string? Name { get; set; }

        public bool Trusted { get; set; }

        public bool AccreditedItEmployer { get; set; }

        public string? AlternateUrl { get; set; }

        [Key]
        [Column("EmployerId")]
        public string Id { get; set; }

        public string Url { get; set; }

        public string VacanciesUrl { get; set; }

        public bool Blacklisted { get; set; }

    }