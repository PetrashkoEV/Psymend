using Psymend.Core.Models;

namespace Psymend.Domain.Test.Lusher.Core.Services
{
    public interface ITestLusherProcessor
    {
        LusherTestResult ProcessData(LusherTest test);
    }
}