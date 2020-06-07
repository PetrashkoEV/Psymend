using Psymend.Core.Models;

namespace Psymend.Domain.Test.Lusher.Core.Services
{
    public interface ITestLusherProcessor
    {
        void ProcessData(LusherTest test);
    }
}