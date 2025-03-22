using System.ComponentModel.DataAnnotations;

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
    public DateTime CreatedAt { get; set; }
    
    [Required]
    public string GameId { get; set; } = null!;
}