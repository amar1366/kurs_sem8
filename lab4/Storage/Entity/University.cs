using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab4.Storage.Entity
{
    public class University
    {

        [Key]
        [Required]
        [Column("UniNomber")]
        public Guid uNomber { get; set; }


        [Required]
        [Column("UniName")]
        public string uName { get; set; }

        [Required]
        [Column("DepartamentId")]
        public Guid DepartamentId { get; set; }
        [ForeignKey(nameof(DepartamentId))]
        public Department Department { get; set; }

        public List<Professor> Professors { get; set; }
    }
}
