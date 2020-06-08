using System.Collections.Generic;

namespace Psymend.Core.Models
{
    public class LusherTestResult
    {
        public int Intensity { get; set; }
        public List<LusherResultGroup> Groups { get; set; }
        public List<List<LusherChoice>> ColorSet { get; set; }
    }
}