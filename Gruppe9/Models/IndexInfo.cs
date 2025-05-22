using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gruppe9.Models;

public class IndexInfo
{
    public int ID { get; set; } //Primary Key
    [Required]
    public string? Code { get; set; }
    [Required]
    public string? DisplayName { get; set; }

    public string? Date { get; set; }

    public int Value { get; set; }

    public string? Category { get; set; }
    [Required]

    public string? IndexDescription { get; set; }
    [Required]
    public int ColorInfoId { get; set; }
    [ForeignKey("ColorInfoId")]
    public ColorInfo? ColorInfo { get; set; }
}

