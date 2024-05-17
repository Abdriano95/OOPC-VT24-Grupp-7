using Bilverkstad.Entitetlagret;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Bokning
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int KundId { get; set; }
    public string FordonRegNr { get; set; }
    public int ReceptionistId { get; set; }
    public int? MekanikerId { get; set; }
    public DateTime InlämningsDatum { get; set; }
    public DateTime? UtlämningsDatum { get; set; }
    public string? SyfteMedBesök { get; set; }
    public Status? BokningStatus { get; set; }


    [NotMapped]
    public string MekanikerFullName { get; set; } // För att kunna visa namn på mekaniker i vyn av bokningar

    [ForeignKey("KundId")]
    public virtual Kund? Kund { get; set; }
    [ForeignKey("FordonRegNr")]
    public virtual Fordon? Fordon { get; set; }
    [ForeignKey("ReceptionistId")]
    public virtual Receptionist? Receptionist { get; set; }
    [ForeignKey("MekanikerId")]
    public virtual Mekaniker? Mekaniker { get; set; }
    public virtual ICollection<Reparation>? Reparation { get; set; } = new List<Reparation>();
}


public enum Status
{
    Inlämnad = 1,
    Pågående = 2,
    Utlämnad = 3,
    Avbruten = 4

}
