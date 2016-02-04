using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyBuilder.Models
{
    public class Question
    {
        public int QuestionId { get; set; } 
        public string QuestionName { get; set; }
        public List<int> AnswersId { get; set; }
        public List<string> Answers { get; set; }
        public List<int> Values { get; set; }
    }
}