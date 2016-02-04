using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyBuilder.Models.Entities
{
    public class SurveyQuestion
    {
        public int SurveyQuestionId { get; set; }
        public string QuestionText { get; set; }
        public virtual IList<MultipleChoiceOption> Options { get; set; }
        public bool MutuallyExclusiveOptions { get; set; }
        public bool Required { get; set; }
        public int Order { get; set; }
    }

    public class MultipleChoiceOption
    {
        public int MultipleChoiceOptionID { get; set; }
        public string Option { get; set; }
    }

}