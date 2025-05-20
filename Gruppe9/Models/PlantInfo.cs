using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gruppe9.Models;

public class PlanteInfo
{
    public int ID { get; set; } //Primary Key
    [Required]
    public string? Code { get; set; }
    [Required]
    public string? DisplayName { get; set; }
    [Required]
    public bool InSeason { get; set; }
    [Required]
    public int IndexInfoId { get; set; }
}
