using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SurveyBuilder.DAL.Entities;
using SurveyBuilder.Models;
using SurveyBuilder.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using WebGrease.Css.Extensions;

namespace SurveyBuilder.Controllers.api
{
    [Authorize]
    public class StatisticsController : ApiController
    {
        private SurveyBuilderContext db = new SurveyBuilderContext();

        // GET: api/Statistics/5
        public Statistic GetStatistics(int surveyId)
        {
            Statistic stat = new Statistic();
            stat.Questions = new List<Question>();

            Survey survey = db.Surveys.Find(surveyId);
            stat.SurveyName = survey.Name;

            IQueryable<SurveyResponse> responses = db.Response.Where(r => r.SurveyId == surveyId).OrderBy(q => q.SurveyQuestionId).ThenBy(res => res.Response).AsQueryable();
            IList<SurveyQuestion> questions = survey.Questions.ToList();

            foreach (SurveyQuestion sq in questions) {
                Question question = new Question();
                question.QuestionId = sq.SurveyQuestionId;
                question.QuestionName = sq.QuestionText;
                question.AnswersId = new List<int>();
                question.Answers = new List<string>();
                question.Values = new List<int>();
                foreach (MultipleChoiceOption mco in sq.Options) {
                    question.AnswersId.Add(mco.MultipleChoiceOptionID);
                    question.Answers.Add(mco.Option);
                    question.Values.Add(0);
                }
                stat.Questions.Add(question);
            }

            foreach (SurveyResponse sr in responses) {
                stat.Questions.Where(q => q.QuestionId == sr.SurveyQuestionId).First().AnswersId.Where(a => a == int.Parse(sr.Response)).First();
                Question que = stat.Questions.Where(q => q.QuestionId == sr.SurveyQuestionId).First();
                int position = que.AnswersId.Where(a => a == int.Parse(sr.Response)).First();
                que.Values[position]++; 
            }
           
            return stat;
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}