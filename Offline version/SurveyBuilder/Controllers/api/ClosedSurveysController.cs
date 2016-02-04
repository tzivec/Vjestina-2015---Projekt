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
    public class ClosedSurveysController : ApiController
    {
        private SurveyBuilderContext db = new SurveyBuilderContext();

        // GET: api/ClosedSurveys
        public IQueryable<Survey> GetClosedSurveys()
        {
            IQueryable<Survey> s = db.Surveys.Where(x => x.IsClosed == true).AsQueryable();
            return db.Surveys.Where(x => x.IsClosed == true).AsQueryable();
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