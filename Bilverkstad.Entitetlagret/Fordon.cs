using System.ComponentModel.DataAnnotations;

namespace Bilverkstad.Entitetlagret;

public class Fordon
{
	[Key]
	public required string RegNr {  get; set; }	
	public required string Bilmärke {  get; set; }
    public required string Modell { get; set; }
    public required Kund Kund { get; set; }

    //public Fordon(string registreringsnummer, string bilmärke, Kund BokadKund)
    //{
    //	this.registreringsnummer = registreringsnummer;
    //	this.bilmärke = bilmärke;
    //	this.BokadKund = BokadKund;
    //}


    public override string ToString()
    {
        return String.Concat(RegNr, Bilmärke, Modell, Kund);
    }

}
