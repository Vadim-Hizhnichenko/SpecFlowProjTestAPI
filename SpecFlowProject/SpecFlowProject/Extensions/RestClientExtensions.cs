using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Extensions
{
    public static class RestClientExtensions
    {

        public static IRestClient SetBaseUrl(this IRestClient client, ScenarioContext scenarionContext)
        {

            var baseUrl = "https://petstore.swagger.io/v2";
            client = new RestClient(baseUrl);

            scenarionContext.Remove("client");
            scenarionContext.Add("client", client);
            return client;
        }


    }
}
