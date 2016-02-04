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
    public class ActiveSurveysController : ApiController
    {
        private SurveyBuilderContext db = new SurveyBuilderContext();

        // GET: api/Surveys
        public IQueryable<Survey> GetActiveSurveys()
        {
            string currentUserId = User.Identity.GetUserId();
            IList<Survey> surveysList = new List<Survey>(); ;

            IQueryable<Survey> surveys = db.Surveys.Where(x => x.IsClosed == false).AsQueryable();
            foreach (Survey s in surveys)
            {
                IList<SurveyResponse> responses = s.Responses;
                bool isForAdd = true;
                foreach (SurveyResponse sr in responses)
                {
                    if (sr.UserId == currentUserId)
                    {
                        isForAdd = false;
                        break;
                    }
                }

                if (isForAdd == true)
                {
                    surveysList.Add(s);
                }
            }

            return surveysList.AsQueryable();
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