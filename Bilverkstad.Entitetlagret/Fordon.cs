

public class Fordon
{
	private string registreringsnummer {  get; set; }	
	private string bilmärke {  get; set; }	
	public Kund BokadKund {  get; private set; }	
	 
	public Fordon(string registreringsnummer, string bilmärke, Kund BokadKund)
	{
		this.registreringsnummer = registreringsnummer;
		this.bilmärke = bilmärke;
		this.BokadKund = BokadKund;
	}
			
	public int HämtaKundNr()
	{ 
		return BokadKund.kundnummer;
	}

    public override string ToString()
    {
        return String.Concat(registreringsnummer, bilmärke, BokadKund);
    }

}
