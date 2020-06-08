using System.Collections.Generic;

namespace Psymend.Domain.Core.Models
{
    public class LusherTestResultModel
    {
        public int LusherTestId { get; set; }
        public int Intensity { get; set; }
        public List<string> Interpretations { get; set; }
    }
}