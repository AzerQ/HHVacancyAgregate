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

        // TODO: Сделать преобразование в модели
        public List<string> Relations { get; set; }

        public bool ResponseLetterRequired { get; set; }

        public string SalaryCurrency { get; set; }

        public int? SalaryFrom { get; set; }

        public int? SalaryTo { get; set; }

        public bool? SalaryGross { get; set; }

        public string SnippetRequirement { get; set; }

        public string SinppetResponsibility { get; set; }

        public string VacancyTypeId { get; set; }

        [ForeignKey(nameof(VacancyTypeId))]
        public VacacncyTypeEntity VacacncyType { get; set; }

        public string Url { get; set; }

        public bool AcceptTemporary { get; set; }

    }
}
