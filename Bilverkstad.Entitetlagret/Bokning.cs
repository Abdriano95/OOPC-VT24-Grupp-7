using System;
using System.Security.Cryptography;

public class Bokning
{
	private int bokningsNr;
	public Kund BokadKund { get; private set; }
	private DateTime inlämningsDatum;
	private DateTime utlämningsDatum;
	private string syfteMedBesök;
	public Mekaniker BokadMekaniker { get;private set }





	public Bokning(int bokningsNr, BokadKund)
	{
		this.bokningsNr = bokningsNr;
		this.BokadKund = BokadKund;
	}

	public int HämtaKund() 
	{
		return BokadKund.kundnummer;
	}

	public int HämtaAnställningNr()
	{
		return BokadMekaniker.anställningNr;

    }
}
