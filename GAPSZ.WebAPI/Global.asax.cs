﻿using GAPSZ.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace GAPSZ.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public object BundleConfig { get; private set; }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
