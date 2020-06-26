using System.Collections.Generic;
using Psymend.Domain.Test.PsychoBio.Core.Models;

namespace Psymend.Domain.Test.PsychoBio.Core.Processor
{
    public interface IPsychoBioTestProcessor
    {
        PsychoBioTestResult ProcessData(List<PsychoBioTestAnswer> answers);
    }
}