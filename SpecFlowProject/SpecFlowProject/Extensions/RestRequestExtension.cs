using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Extensions
{
    public static class RestRequestExtension
    {

        public static RestRequest CreateRequest(this RestRequest request, ScenarioContext scenarionContext, Method type, string endPoint)
        {
            request = new RestRequest(endPoint, type)
            {
                RequestFormat = DataFormat.Json
            };

            scenarionContext.Remove("request");
            scenarionContext.Add("request", request);
            return request;
        }

        public static RestRequest CreateUrlSegment(this RestRequest request, ScenarioContext scenarioContext, string urlSegment, int value)
        {
            request = scenarioContext.Get<RestRequest>("request");
            request.AddUrlSegment(urlSegment, value);

            scenarioContext.Remove("request");
            scenarioContext.Add("request", request);
            return request;
        }

        public static RestRequest CreateUrlParametr(this RestRequest request, ScenarioContext scenarioContext, string urlParametr, string value)
        {
            request = scenarioContext.Get<RestRequest>("request");
            request.AddParameter(urlParametr, value);

            scenarioContext.Remove("request");
            scenarioContext.Add("request", request);
            return request;
        }

        public static RestRequest CreateJsonBody(this RestRequest request, ScenarioContext scenarioContext, object obj)
        {
            request = scenarioContext.Get<RestRequest>("request");
            request.AddJsonBody(obj);

            
            scenarioContext.Remove("request");
            scenarioContext.Add("request", request);
            return request;
        }

        public static IRestRequest SetNewFile(this IRestRequest request, ScenarioContext scenarioContext,string name, string fullPath)
        {
            request = scenarioContext.Get<RestRequest>("request");
            request.AddFile(name, fullPath);

            scenarioContext.Remove("request");
            scenarioContext.Add("request", request);
            return request;
        }

        
        
    }
}
