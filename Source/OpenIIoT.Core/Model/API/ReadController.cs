﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;
using NLog;
using OpenIIoT.Core.Model;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Model;

namespace OpenIIoT.Core.Model.API
{
    public class ReadController : ApiController
    {
        #region Private Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     The ApplicationManager for the application.
        /// </summary>
        private static IApplicationManager manager = ApplicationManager.GetInstance();

        private static Item model = manager.GetManager<ModelManager>().Model;

        #endregion Private Fields

        #region Public Methods

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

        [Route("api/read")]
        [HttpGet]
        public HttpResponseMessage Read()
        {
            IList<Item> result = model.Children;
            return Request.CreateResponse(HttpStatusCode.OK, result, JsonFormatter(new List<string>(new string[] { "FQN", "Timestamp", "Quality", "Value", "Children" }), ContractResolverType.OptIn));
        }

        [Route("api/read/{fqn}")]
        [HttpGet]
        public HttpResponseMessage Read(string fqn)
        {
            return Read(fqn, false);
        }

        [Route("api/read/{fqn}/{fromSource}")]
        [HttpGet]
        public HttpResponseMessage Read(string fqn, bool fromSource)
        {
            // TODO: Fix this so all url encodings are translated
            fqn = fqn.Replace("%25", "%");

            Item foundItem = manager.GetManager<IModelManager>().FindItem(fqn);

            if (fromSource)
            {
                foundItem.ReadFromSource();
            }

            return Request.CreateResponse(HttpStatusCode.OK, foundItem.Value, JsonFormatter(new List<string>(new string[] { "FQN", "Timestamp", "Quality", "Value", "Children" }), ContractResolverType.OptIn));
        }

        #endregion Public Methods
    }
}