using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Appointment
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 1)]
    public int Id { get; set; }
    public Patient AppPatient { get; set; }
    public Doctor AppDoc { get; set; }
    public Facility Facility { get; set; }
}

