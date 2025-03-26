using System.ComponentModel.DataAnnotations;
using GamingReport.Core._Game.Enums;

namespace GamingReportApi.InputModels;

public class ReviewIM
{
    [Required]
    [MaxLength(60)]
    public string Title { get; set; } = null!;
    
    [Required]
    [MinLength(300)]
    public string Content { get; set; } = null!;
    
    [Required]
    [Range(0, 10)]
    public decimal Score { get; set; }
    
    [Required]
    public Platforms Platform { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }
    
    [Required]
    public string GameId { get; set; } = null!;
}