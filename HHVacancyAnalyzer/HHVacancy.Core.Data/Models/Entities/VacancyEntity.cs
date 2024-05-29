namespace HHVacancy.Core.Data.Models.Entities
{
    public class VacancyEntity
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string AreaId { get; set; }

        public string EmployerId { get; set; }

        public bool HasTest { get; set; }

        public ICollection<ProfessionalRoleEntity> ProfessionalRole { get; set; }

        public DateTime PublishedAt { get; set; }

        public List<string> Relations { get; set; }

        public bool ResponseLetterRequired { get; set; }

        

    }
}
