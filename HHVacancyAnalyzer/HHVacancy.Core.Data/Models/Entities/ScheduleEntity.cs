using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HHVacancy.Core.Data.Models.Entities
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
