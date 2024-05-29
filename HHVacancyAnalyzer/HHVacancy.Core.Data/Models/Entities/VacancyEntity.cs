using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HHVacancy.Core.Data.Models.Entities
{
    [Table("Vacancies")]
    public class VacancyEntity
    {
        [Key]
        [Column("VacancyId")]
        public string Id { get; set; }

        public string Name { get; set; }

        public string AreaId { get; set; }

        [ForeignKey(nameof(Area))]
        public AreaEntity Area { get; set; }

        public string EmployerId { get; set; }

        [ForeignKey(nameof(EmployerId))]
        public EmployerEntity Employer { get; set; }

        public bool HasTest { get; set; }

        public ICollection<ProfessionalRoleEntity> ProfessionalRole { get; set; }

        public DateTime PublishedAt { get; set; }

        public List<string> Relations { get; set; }

        public bool ResponseLetterRequired { get; set; }



    }
}
