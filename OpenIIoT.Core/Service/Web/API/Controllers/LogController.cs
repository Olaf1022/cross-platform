﻿using Newtonsoft.Json;
using NLog;
using NLog.RealtimeLogger;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;

namespace OpenIIoT.Core.Service.Web.API
{
    public class LogController : ApiController, IApiController
    {
        private static IApplicationManager manager = ApplicationManager.GetInstance();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        //private static List<string> appArchiveSerializationProperties = new List<string>(new string[] { "FQN", "FileName", "Version", "AppType", "ConfigurationDefinition" });

        [Route("api/log")]
        [HttpGet]
        public HttpResponseMessage GetLog()
        {
            ApiResult<RealtimeLoggerEventArgs[]> retVal = new ApiResult<RealtimeLoggerEventArgs[]>(Request);
            retVal.LogRequest(logger.Info);

            retVal.ReturnValue = RealtimeLogger.LogHistory.ToArray();

            retVal.LogResult(logger);
            return retVal.CreateResponse(JsonFormatter(new List<string>(new string[] { }), ContractResolverType.OptOut));
        }

        public JsonMediaTypeFormatter JsonFormatter(List<string> serializationProperties, ContractResolverType contractResolverType)
        {
            JsonMediaTypeFormatter retVal = new JsonMediaTypeFormatter();

            retVal.SerializerSettings = new JsonSerializerSettings();

            retVal.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            retVal.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            retVal.SerializerSettings.Formatting = Formatting.Indented;
            retVal.SerializerSettings.ContractResolver = new ContractResolver(serializationProperties, contractResolverType);
            retVal.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());

            return retVal;
        }
    }
}