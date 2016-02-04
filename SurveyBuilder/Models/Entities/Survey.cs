using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyBuilder.Models;
using SurveyBuilder.Models.Entities;

namespace SurveyBuilder.DAL.Entities
{
    public class Survey
    {
        public int SurveyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CompletionMessage { get; set; }
        public bool IsClosed { get; set; }

        public virtual string UserId { get; set; }
        public virtual IList<SurveyQuestion> Questions { get; set; }
        public virtual IList<SurveyResponse> Responses { get; set; } 
    }
}
