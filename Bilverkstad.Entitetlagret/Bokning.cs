using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Bilverkstad.Entitetlagret;

public class Bokning
{
	[Key]
	public int Id { get; set; }	
	public Kund Kund { get; set; }
	public Fordon Fordon { get; set; }
	public Receptionist Receptionist { get; set; }
	public DateTime InlämningsDatum { get; set; }
	public DateTime? UtlämningsDatum { get; set; }	
	public string? SyfteMedBesök { get; set; }	
	
	

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
