using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("VacancyTypes")]
public class VacacncyTypeEntity
{
        [Key]
        [Column("VacancyTypeId")]
        public string Id { get; set; }

        public string Name { get; set; }
}