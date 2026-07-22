using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ellipse.Data.Entities
{
    public class Environment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public bool RequiresTraining { get; set; }

    }
}

