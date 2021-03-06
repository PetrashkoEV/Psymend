﻿using System;
using System.Collections.Generic;

namespace Psymend.Infrastructure.Core.Entities.LusherTest
{
    public class LusherTestEntity
    {
        public int LusherTestId { get; set; }
        public DateTime CreateDate { get; set; }
        public int Intensity { get; set; }

        public List<LusherChoiceEntity> LusherChoices { get; set; }
        public List<LusherResultEntity> LusherResults { get; set; }
        public List<TestEntity> Tests { get; set; }
    }
}