namespace Psymend.Infrastructure.Core.Entities.LusherTest
{
    public class LusherChoiceColorEntity
    {
        public int LusherChoiceColorId { get; set; }
        public int LusherChoiceId { get; set; }
        public int Color { get; set; }
        public string Group { get; set; }
        public bool Anxiety { get; set; }
        public int Intensity { get; set; }
        public int Position { get; set; }

        public LusherChoiceEntity LusherChoice { get; set; }
    }
}