using Bilverkstad.Entitetlagret;
using System.Collections.Generic;
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
    public string MekanikerFullName { get; set; } // This will hold the mechanic's full name, set manually after fetching the data

    [ForeignKey("KundId")]
    public virtual Kund? Kund { get; set; } //required 
    [ForeignKey("FordonRegNr")]
    public virtual Fordon? Fordon { get; set; } //required 
    [ForeignKey("ReceptionistId")]
    public virtual Receptionist? Receptionist { get; set; } // required 
    [ForeignKey("MekanikerId")]
    public virtual Mekaniker? Mekaniker { get; set; } // optional
    public virtual ICollection<Reparation>? Reparation { get; set; } = new List<Reparation> (); // 1 till många required 
}




    //public Bokning(int bokningsNr,Kund BokadKund)
    //{
    //	this.bokningsNr = bokningsNr;
    //	this.BokadKund = BokadKund;
    //}



public enum Status
{
    Inlämnad = 1,
    Pågående = 2,
    Utlämnad = 3,
    Avbruten = 4

}
