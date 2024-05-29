using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HHVacancy.Core.Data.Models.Entities
{
    [Table("Shedules")]
    public class ScheduleEntity
    {
        [Key]
        [Column("SheduleId")]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
