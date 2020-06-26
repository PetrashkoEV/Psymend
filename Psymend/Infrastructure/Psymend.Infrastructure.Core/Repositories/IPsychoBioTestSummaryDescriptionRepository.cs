using Psymend.Core.Enums;
using Psymend.Infrastructure.Core.Entities.PsychoBioTest;

namespace Psymend.Infrastructure.Core.Repositories
{
    public interface IPsychoBioTestSummaryDescriptionRepository
    {
        PsychobioTestSummaryDescriptionEntity GetDescription(PsychoBioTestSummaryDescriptionType type, int value);
    }
}