﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SurveyBuilder.Models.Entities;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SurveyBuilder.Startup))]

namespace SurveyBuilder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
          //  Database.SetInitializer(new NullDatabaseInitializer<SurveyBuilderContext>());
        }
    }
}
