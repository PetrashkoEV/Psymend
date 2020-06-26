using System.Collections.Generic;

namespace Psymend.WebApi.Model
{
    public class PsychoBioTestResponseToQuestionModel
    {
        public int QuestionNumber { get; set; }
        public List<PsychoBioTestAnswerResultModel> Answers { get; set; }
    }
}