using Psymend.Core.Enums;

namespace Psymend.Core.Models
{
    public class LusherResultGroup
    {
        public bool FirstAnxiety { get; set; }
        public int FirstColor { get; set; }
        public GroupType SecondGroup { get; set; }
        public bool SecondAnxiety { get; set; }
        public int SecondColor { get; set; }
        public int Position { get; set; }
    }
}