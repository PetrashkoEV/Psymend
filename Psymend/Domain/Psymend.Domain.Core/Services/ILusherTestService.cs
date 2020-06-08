using System.Collections.Generic;
using Psymend.Domain.Core.Models;

namespace Psymend.Domain.Core.Services
{
    public interface ILusherTestService
    {
        LusherTestResultModel ProcessData(List<List<int>> colorSet, int userId);

        LusherTestResultModel GetLusherTestResultById(int testId, int userId);
    }
}