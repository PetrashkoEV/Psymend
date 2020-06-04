namespace Psymend.Infrastructure.Core.Entities.LusherTest
{
    public class LusherResultEntity
    {
        public int LusherResultId { get; set; }
        public int LusherTestId { get; set; }
        public int PositionNumber { get; set; }
        public int Anxiety { get; set; }
        public int Compensation { get; set; }

        public LusherTestEntity LusherTest { get; set; }
    }
}