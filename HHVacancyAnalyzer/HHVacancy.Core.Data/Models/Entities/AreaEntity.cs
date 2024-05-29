using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HHVacancy.Core.Data.Models.Entities
{
    [Table("Areas")]
    public class AreaEntity
    {
        [Key]
        [Column("AreaId")]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
