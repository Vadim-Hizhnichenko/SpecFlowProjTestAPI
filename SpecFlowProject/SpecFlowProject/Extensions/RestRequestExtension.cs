using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Extensions
{
    public static class RestRequestExtension
    {

        public static IRestRequest CreateRequest(this IRestRequest request, ScenarioContext scenarionContext, Method type, string endPoint)
        {
            request = new RestRequest(endPoint, type);

            scenarionContext.Remove("request");
            scenarionContext.Add("request", request);
            return request;
        }

        public static IRestRequest CreateUrlSegment(this IRestRequest request, ScenarioContext scenarioContext, string urlSegment, int value)
        {
            request = scenarioContext.Get<RestRequest>("request");
            request.AddUrlSegment(urlSegment, value);

            scenarioContext.Remove("request");
            scenarioContext.Add("request", request);
            return request;
        }

        public static IRestRequest CreateUrlParametr(this IRestRequest request, ScenarioContext scenarioContext, string urlParametr, string value)
        {
            request = scenarioContext.Get<RestRequest>("request");
            request.AddParameter(urlParametr, value);

            scenarioContext.Remove("request");
            scenarioContext.Add("request", request);
            return request;
        }

        public static IRestRequest CreateJsonBody(this IRestRequest request, ScenarioContext scenarioContext, object obj)
        {
            request = scenarioContext.Get<RestRequest>("request");
            request.AddJsonBody(obj);

            scenarioContext.Remove("request");
            scenarioContext.Add("request", request);
            return request;
        }

        
        
    }
}
