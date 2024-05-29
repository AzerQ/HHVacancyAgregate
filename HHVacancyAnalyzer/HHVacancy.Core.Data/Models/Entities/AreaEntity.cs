using System;
using System.Collections.Generic;
using System.Text;

namespace HHVacancy.Core.Data.Models.Entities
{
    public class AreaEntity
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
