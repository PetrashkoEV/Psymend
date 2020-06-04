using System.Collections.Generic;

namespace Psymend.Domain.Core.Services
{
    public interface ILusherTestService
    {
        void Start(List<List<int>> colorSet, int userId);
    }
}