using devops_project.Interfaces;
using devops_project.Models;

namespace devops_project.Helpers;

public class PeriodHelper : IPeriodHelper
{
    public DateTime GetInitialDate(MeteorologiaPeriod period)
    {
        return period switch
        {
            MeteorologiaPeriod.Daily => DateTime.Now.AddDays(-1),
            MeteorologiaPeriod.Weekly => DateTime.Now.AddDays(-7),
            _ => throw new ArgumentOutOfRangeException(nameof(period), $"Not expected period value: {period}"),
        };
    }

    public DateTime GetFinalDate()
    {
        return DateTime.Now;
    }
}
