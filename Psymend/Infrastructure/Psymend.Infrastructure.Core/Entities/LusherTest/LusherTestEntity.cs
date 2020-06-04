using System;
using System.Collections.Generic;

namespace Psymend.Infrastructure.Core.Entities.LusherTest
{
    public class LusherTestEntity
    {
        public int LusherTestId { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }

        public List<LusherChoiceEntity> LusherChoices { get; set; }
        public LusherResultEntity LusherResult { get; set; }
        public UserEntity User { get; set; }
    }
}