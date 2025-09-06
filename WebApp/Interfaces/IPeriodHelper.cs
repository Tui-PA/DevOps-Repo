using devops_project.Models;

namespace devops_project.Interfaces;

public interface IPeriodHelper
{
    DateTime GetInitialDate(MeteorologiaPeriod period);
    DateTime GetFinalDate();
}
