using System;
using Psymend.Infrastructure.Core.Entities.LusherTest;
using Psymend.Infrastructure.Core.Entities.PsychoBioTest;

namespace Psymend.Infrastructure.Core.Entities
{
    public class TestEntity
    {
        public int TestId { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string TestType { get; set; }
        public int? LusherTestId { get; set; }
        public int? PsychobioTestId { get; set; }

        public UserEntity User { get; set; }
        public LusherTestEntity LusherTest { get; set; }
        public PsychoBioTestEntity PsychoBioTest { get; set; }
    }
}