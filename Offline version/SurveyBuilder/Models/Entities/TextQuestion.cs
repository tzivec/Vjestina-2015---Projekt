using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyBuilder.Models.Entities
{
    public class TextQuestion : SurveyQuestion
    {
        public TextQuestion()
        {
            base.Options = null;
        }
    }
}