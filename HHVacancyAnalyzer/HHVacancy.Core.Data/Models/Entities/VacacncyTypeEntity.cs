using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("VacancyTypes")]
public class VacancyTypeEntity
{
        [Key]
        [Column("VacancyTypeId")]
        public string Id { get; set; }

        public string Name { get; set; }
}