namespace Psymend.Infrastructure.Core.Entities.PsychoBioTest
{
    public class PsychoBioTestAnswerResponseEntity
    {
        public int PsychoBioTestAnswerResponseId { get; set; }

        public int PsychoBioTestId { get; set; }
        public int PsychoBioTestAnswerDefinitionId { get; set; }
        public string CustomText { get; set; }

        public PsychoBioTestEntity PsychoBioTest { get; set; }
        public PsychoBioTestAnswerDefinitionEntity PsychoBioTestAnswerDefinition { get; set; }
    }
}