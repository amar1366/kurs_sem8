using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab4.Storage.Entity
{
    public class Professor
    {

        [Required]
        [Column("UniversityId")]
        public Guid UniversityId { get; set; }

        [Key]
        [Required]
        [Column("ProfNomber")]
        public Guid pNomber { get; set; }

        [Required]
        [Column("Surname")]
        public string surname { get; set; }

        [Required]
        [Column("Name")]
        public string name { get; set; }

        [Required]
        [Column("MiddleName")]
        public string middlename { get; set; }

        [Required]
        [Column("Birthday", TypeName = "date")]
        public DateTime birthday { get; set; }
    }
}
