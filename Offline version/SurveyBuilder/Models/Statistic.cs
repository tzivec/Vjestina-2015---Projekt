using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyBuilder.Models
{
    public class Statistic
    {
        public string SurveyName { get; set; }
        public List<Question> Questions { get; set; }
    }
}