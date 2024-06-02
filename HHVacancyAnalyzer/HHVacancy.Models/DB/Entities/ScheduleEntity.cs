using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HHVacancy.Models.DB.Entities
{
    [Table("Schedules")]
    public class ScheduleEntity
    {
        [Key]
        [Column("ScheduleId")]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
