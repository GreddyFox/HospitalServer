using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]

        public int Id { get; set; }
        public string FullName { get; set; }
       // public IEnumerable<Facility> Facility { get; set; }
        public string Occupation { get; set; }

    }


