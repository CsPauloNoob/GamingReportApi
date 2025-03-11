using GamingReport.Core._Game.Enums;

namespace GamingReportApi.ViewModels;

public class GameVM
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<Platforms> Platform { get; set; } = new();
}