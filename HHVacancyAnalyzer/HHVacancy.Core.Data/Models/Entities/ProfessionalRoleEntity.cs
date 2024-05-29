using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ProfessionalRoles")]
public class ProfessionalRoleEntity
    {
        [Key]
        [Column("ProfessionalRoleId")]
        public string Id { get; set; }

        public string Name { get; set; }
    }