using HHVacancy.Models.API.Vacancy;
using HHVacancy.Models.DB.Entities.Links;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HHVacancy.Models.DB.Entities;

[Table("Vacancies")]
public class VacancyEntity
{
    [Key]
    [Column("VacancyId")]
    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? AreaId { get; set; }

    [ForeignKey(nameof(AreaId))]
    public virtual AreaEntity Area { get; set; }

    public string? EmployerId { get; set; }

    [ForeignKey(nameof(EmployerId))]
    public virtual EmployerEntity Employer { get; set; }

    public bool HasTest { get; set; }

    public DateTime PublishedAt { get; set; }

    public bool ResponseLetterRequired { get; set; }

    public string? SalaryCurrency { get; set; }

    public int? SalaryFrom { get; set; }

    public int? SalaryTo { get; set; }

    public bool? SalaryGross { get; set; }

    public string? SnippetRequirement { get; set; }

    public string? SnippetResponsibility { get; set; }

    public string? VacancyTypeId { get; set; }

    [ForeignKey(nameof(VacancyTypeId))]
    public virtual VacancyTypeEntity Type { get; set; }

    public string? Url { get; set; }

    public bool AcceptTemporary { get; set; }

    // JSON SERIALIZED
    public Address Address { get; set; }

    public string? AdvResponseUrl { get; set; }

    public bool Archived { get; set; }

    // JSON SERIALIZED
    public Contacts Contacts { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? ResponseUrl { get; set; }

    public string? ScheduleId { get; set; }

    [ForeignKey(nameof(ScheduleId))]
    public virtual ScheduleEntity Schedule { get; set; }

    public double? SortPointDistance { get; set; }

    public string? EmploymentId { get; set; }

    [ForeignKey(nameof(EmploymentId))]
    public EmploymentEntity Employment { get; set; }

    public string? ExperienceId { get; set; }

    [ForeignKey(nameof(ExperienceId))]
    public ExperienceEntity Experience { get; set; }

    public virtual ICollection<KeySkillVacancyLinkEntity> VacancyKeySkillsLinks { get; set; }

    public virtual ICollection<ProfessionalRoleVacancyLinkEntity> ProfessionalRoleVacancyLink { get; set; }

    public int CountersResponses { get; set; }

    public int CountersTotalResponses { get; set; }
}

