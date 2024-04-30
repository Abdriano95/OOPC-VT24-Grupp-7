using System.ComponentModel.DataAnnotations;

namespace Bilverkstad.Entitetlagret;

public class Fordon
{
    [Key]
    public string? RegNr { get; set; }
    public string? Bilmärke { get; set; }
    public string? Modell { get; set; }
    public int KundId { get; set; }
    public virtual Kund? Kund { get; set; } 

    

    public override string ToString()
    {
        return String.Concat(RegNr, Bilmärke, Modell, Kund);
    }

}
