using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gruppe9.Models;

// Representerer én pollenindeksverdi for en plante på en gitt dato
public class IndexInfo
{
    public int ID { get; set; } // Primærnøkkel i databasen

    [Required]
    public string? Code { get; set; } // Kode for planten (f.eks. "birch")

    [Required]
    public string? DisplayName { get; set; } // Vennlig navn på planten (f.eks. "Bjørk")

    public string? Date { get; set; } // Dato for registreringen (tekstformat)

    public int Value { get; set; } // Pollenverdi (numerisk indeks)

    public string? Category { get; set; } // Kategori (f.eks. "Low", "High")

    [Required]
    public string? IndexDescription { get; set; } // Beskrivelse av pollenindeksen

    [Required]
    public int ColorInfoId { get; set; } // Fremmednøkkel til tilhørende farge

    [ForeignKey("ColorInfoId")]
    public ColorInfo? ColorInfo { get; set; } // Navigasjonsegenskap til fargeinformasjon
}
