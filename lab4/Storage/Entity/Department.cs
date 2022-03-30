using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab4.Storage.Entity
{
    public class Department
    {

        

        [Key]
        [Required]
        [Column("DepNomber")]
        public Guid dNomber { get; set; }

        [Required]
        [Column("DepName")]
        public string dName { get; set; }

        public List<University> Universities { get; set; }
    }
}
