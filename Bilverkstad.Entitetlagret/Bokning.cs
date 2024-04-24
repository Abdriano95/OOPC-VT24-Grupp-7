using Bilverkstad.Entitetlagret;
using System.ComponentModel.DataAnnotations;

public class Bokning
{
    [Key]
    public int Id { get; set; }
    public Kund? Kund { get; set; } //required 
    public Fordon? Fordon { get; set; } //required 
    public Receptionist? Receptionist { get; set; } // required 
    public DateTime InlämningsDatum { get; set; }
    public DateTime? UtlämningsDatum { get; set; }
    public string? SyfteMedBesök { get; set; }
    public ICollection<Reparation>? Reparation { get; set; } // 1 till många required 



    //public Bokning(int bokningsNr,Kund BokadKund)
    //{
    //	this.bokningsNr = bokningsNr;
    //	this.BokadKund = BokadKund;
    //}


    public override string ToString()
    {
        return String.Concat(Id, Kund, Fordon, InlämningsDatum, UtlämningsDatum, SyfteMedBesök);
    }
}
