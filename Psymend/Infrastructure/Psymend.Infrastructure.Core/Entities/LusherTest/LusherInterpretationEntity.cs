using System.Collections.Generic;

namespace Psymend.Infrastructure.Core.Entities.LusherTest
{
    public class LusherInterpretationEntity
    {
        public int LusherInterpretationId { get; set; }
        public string Key { get; set; }
        public string Text { get; set; }

        public List<LusherResultEntity> LusherResults { get; set; }
    }
}