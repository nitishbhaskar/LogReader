using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FlatFileLogReader.Controllers
{
    public class GetFileContentsController : ApiController
    {
        public HttpResponseMessage Get([FromUri]string FileName)
        {
            var text = File.ReadAllText(this.ReadFromConfig("LogFolder") + FileName);
            return base.Request.CreateResponse(HttpStatusCode.OK, text);
        }

        private string ReadFromConfig(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}