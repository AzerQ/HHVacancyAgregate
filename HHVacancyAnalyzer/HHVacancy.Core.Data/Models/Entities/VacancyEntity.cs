using HHVacancy.Core.Data.Models.Vacancy;
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
        public virtual AreaEntity Area { get; set; }

        public string EmployerId { get; set; }

        [ForeignKey(nameof(EmployerId))]
        public virtual EmployerEntity Employer { get; set; }

        public bool HasTest { get; set; }

        public virtual List<ProfessionalRoleEntity> ProfessionalRoles { get; set; }

        public DateTime PublishedAt { get; set; }

        // JSON SERIALIZED
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
        public virtual VacacncyTypeEntity Type { get; set; }

        public string Url { get; set; }

        public bool AcceptTemporary { get; set; }

        // JSON SERIALIZED
        public Address Address { get; set; }

        public string AdvResponseUrl { get; set; }

        public bool Archived { get; set; }

        // JSON SERIALIZED
        public Contacts Contacts { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ResponseUrl { get; set; }

        public string ScheduleId { get; set; }

        [ForeignKey(nameof(ScheduleId))]
        public virtual ScheduleEntity Schedule { get; set; }

        public double? SortPointDistance { get; set; }

        public string EmploymentId { get; set; }

        [ForeignKey(nameof(EmploymentId))]
        public EmploymentEntity Employment { get; set; }

        public string ExperienceId { get; set; }

        [ForeignKey(nameof(ExperienceId))]
        public ExperienceEntity Experience { get; set; }
    }

}
