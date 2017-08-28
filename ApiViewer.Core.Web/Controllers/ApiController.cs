////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Controllers\ApiController.cs
//
// summary:	Implements the API controller class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiViewer.Core.Web.Controllers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A controller for handling apis. </summary>
    ///
    /// <remarks>   James Coates, 8/26/2017. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [Produces("application/json")]
    [Route("Api")]
    public class ApiController : Controller
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   (An Action that handles HTTP POST requests) gets the categories. </summary>
        ///
        /// <remarks>   James Coates, 8/26/2017. </remarks>
        ///
        /// <returns>   The categories. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [Route("~/Api/GetCategories")]
        [HttpGet]
        public string GetCategories()
        {
            return JsonConvert.SerializeObject(Standard.Apis.FactoryApi.GetCategories());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   (An Action that handles HTTP POST requests) gets the apis. </summary>
        ///
        /// <remarks>   James Coates, 8/26/2017. </remarks>
        ///
        /// <param name="category"> The category. </param>
        ///
        /// <returns>   The apis. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [Route("~/Api/GetApis/{category}")]
        [HttpGet]
        public string GetApis(string category)
        {
            var data = ApiViewer.Standard.Apis.FactoryApi.GetApis(category);
            var apis = new List<string>();
            data.ForEach(x => apis.Add(x.Value));
            JsonConvert.SerializeObject(apis);
            return JsonConvert.SerializeObject(apis); 
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   (An Action that handles HTTP POST requests) gets a data. </summary>
        ///
        /// <remarks>   James Coates, 8/26/2017. </remarks>
        ///
        /// <param name="api">      The API. </param>
        /// <param name="search">   (Optional) The search. </param>
        ///
        /// <returns>   The data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [Route("~/Api/GetData/{api}/{search?}")]
        [HttpGet]
        public string GetData(string api, string search = "")
        {
            var Api = Standard.Apis.FactoryApi.GetFromName(api.Replace("_"," "));
            var dList = new List<string>();

            var data = Api.Search(search);

            foreach(var v in data)
            {
                dList.Add(v.Name);
            }

            return JsonConvert.SerializeObject(dList);
        }
    }
}
