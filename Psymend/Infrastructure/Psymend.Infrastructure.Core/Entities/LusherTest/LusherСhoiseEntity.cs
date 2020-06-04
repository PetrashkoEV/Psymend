using System.Collections.Generic;

namespace Psymend.Infrastructure.Core.Entities.LusherTest
{
    public class LusherChoiceEntity
    {
        public int LusherChoiceId { get; set; }
        public int LusherTestId { get; set; }
        public int ChoiceNumber { get; set; }

        public List<LusherChoiceColorEntity> LusherChoices { get; set; }
        public LusherTestEntity LusherTest { get; set; }
    }
}