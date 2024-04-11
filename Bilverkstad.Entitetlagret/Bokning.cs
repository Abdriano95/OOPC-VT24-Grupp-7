using System;
using System.Security.Cryptography;
using Bilverkstad.Entitetlagret;

public class Bokning
{
	private int bokningsNr;
	public Kund BokadKund { get; private set; }
	private DateTime inlämningsDatum;
	private DateTime utlämningsDatum;
	private string syfteMedBesök;
	public Mekaniker BokadMekaniker { get; private set; }
	public Reservdel BokadDel { get; private set; }

	public Bokning(int bokningsNr,Kund BokadKund)
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

	public string HämtaReservdel()
	{
		return BokadDel.reservdelsnummer;
	}
	public override string ToString()
    {
        return String.Concat(bokningsNr, BokadKund);
    }
}
