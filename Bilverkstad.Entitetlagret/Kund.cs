
using System.ComponentModel.DataAnnotations;

public class Kund
{
    
    public int kundnummer {  get; set; }  
    private string förnamn {  get; set; }  
    private string efternamn {  get; set; }    
    private string personnummer {  get; set; } 
    private string gatuadress {  get; set; }
    private int postnummer {  get; set; }
    private string ort {  get; set; }
    private string telnr {  get; set; }
    private string epost {  get; set; }


    public Kund(int kundnummer, string förnamn, string efternamn, string personnummer)
    {
        this.kundnummer = kundnummer;
        this.förnamn = förnamn;
        this.efternamn = efternamn;
        this.personnummer = personnummer;
    }

    public override string ToString()
    {
        return String.Concat(kundnummer,förnamn,efternamn,personnummer);
    }
}







