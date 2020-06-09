namespace Psymend.Infrastructure.Core.Entities.LusherTest
{
    public class LusherResultEntity
    {
        public int LusherResultId { get; set; }
        public int LusherTestId { get; set; }
        public int LusherInterpretationId { get; set; }
        public int FirstColor { get; set; }
        public int SecondColor { get; set; }
        public string Group { get; set; }
        public bool Anxiety { get; set; }
        public int Position { get; set; }

        public LusherTestEntity LusherTest { get; set; }
        public LusherInterpretationEntity LusherInterpretation { get; set; }
    }
}