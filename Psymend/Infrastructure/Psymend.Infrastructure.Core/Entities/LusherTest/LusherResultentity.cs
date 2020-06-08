namespace Psymend.Infrastructure.Core.Entities.LusherTest
{
    public class LusherResultEntity
    {
        public int LusherResultId { get; set; }
        public int LusherTestId { get; set; }
        public int LusherInterpretationId { get; set; }
        public bool FirstAnxiety { get; set; }
        public int FirstColor { get; set; }
        public string SecondGroup { get; set; }
        public bool SecondAnxiety { get; set; }
        public int SecondColor { get; set; }
        public int Position { get; set; }

        public LusherTestEntity LusherTest { get; set; }
        public LusherInterpretationEntity LusherInterpretation { get; set; }
    }
}