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
    public class LogFileNamesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var dir = new DirectoryInfo(this.ReadFromConfig("LogFolder"));
            var fileDetails = dir.EnumerateFiles("*.txt", SearchOption.AllDirectories);
            return base.Request.CreateResponse(HttpStatusCode.OK, fileDetails);
        }

        public HttpResponseMessage Get([FromUri]string filterText)
        {
            var dir = new DirectoryInfo(this.ReadFromConfig("LogFolder"));
            var fileDetails = dir.EnumerateFiles("*"+filterText+"*.txt", SearchOption.AllDirectories);
            return base.Request.CreateResponse(HttpStatusCode.OK, fileDetails);
        }

        private string ReadFromConfig(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}