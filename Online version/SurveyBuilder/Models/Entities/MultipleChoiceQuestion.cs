using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurveyBuilder.Models.Entities
{
    public class MultipleChoiceQuestion : SurveyQuestion
    {
        public virtual IList<string> Options { get; set; } 
    }
}