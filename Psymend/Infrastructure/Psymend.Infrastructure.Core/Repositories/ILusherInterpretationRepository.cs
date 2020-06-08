using Psymend.Infrastructure.Core.Entities.LusherTest;

namespace Psymend.Infrastructure.Core.Repositories
{
    public interface ILusherInterpretationRepository
    {
        LusherInterpretationEntity GetInterpretationByKey(string key);
        LusherInterpretationEntity GetDefaultEntity();
    }
}