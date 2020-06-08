using System.Collections.Generic;

namespace Psymend.Domain.Core.Models
{
    public class TestModel
    {
        public int UserId { get; set; }

        public List<TestDescriptionModel> Tests { get; set; }
    }
}