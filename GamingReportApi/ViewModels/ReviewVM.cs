namespace GamingReportApi.ViewModels;

public class ReviewVM
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;

    public decimal Score { get; set; }

    public int UpPoints { get; set; }
    public int DownPoints { get; set; }
    
    
}