using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurveyBuilder.Models.Entities
{
    public class SurveyResponse
    {
        public int SurveyResponseId { get; set; }
        public int SurveyId { get; set; }
        public string Response { get; set; }
        public int SurveyQuestionId { get; set; }
        public virtual string UserId { get; set; }
    }
}