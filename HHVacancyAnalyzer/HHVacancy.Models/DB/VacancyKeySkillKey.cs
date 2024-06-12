namespace HHVacancy.Models.DB
{
    public class VacancyKeySkillKey
    {
        public string VacancyId { get; set; }

        public string KeySkillId { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is VacancyKeySkillKey key &&
                   VacancyId == key.VacancyId &&
                   KeySkillId == key.KeySkillId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(VacancyId, KeySkillId);
        }
    }
}
