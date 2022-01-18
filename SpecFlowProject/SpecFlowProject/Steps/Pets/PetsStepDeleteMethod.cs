using NUnit.Framework;
using RestSharp;
using SpecFlowProject.Entity;
using SpecFlowProject.Extensions;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Steps.Pets
{
    [Binding]
    public class PetsStepDeleteMethod
    {
        private readonly RestClient _client;
        private readonly RestRequest _request;
        private readonly RestResponse _response;
        private readonly ScenarioContext _scenarioContext;

        public PetsStepDeleteMethod(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Set base url Api")]
        public void GivenSetBaseUrlApi()
        {
            _client.SetBaseUrl(_scenarioContext);
        }
        
        [When(@"We created request '(.*)' to '(.*)'")]
        public void WhenWeCreatedRequestTo(Method type, string endPoint)
        {
            _request.CreateRequest(_scenarioContext, type, endPoint);
        }
        
        [When(@"We set '(.*)' to (.*)")]
        public void WhenWeSetTo(string urlSegment, int value)
        {
            _request.CreateUrlSegment(_scenarioContext, urlSegment, value);
        }
        
        [Then(@"We get contex with status")]
        public void ThenWeGetContexWithStatus()
        {
            _response.ExecuteRequest(_scenarioContext);
            _response.GetResponseContent<CodeType>(_scenarioContext);
            var x = _scenarioContext.Get<CodeType>("model").Code;
            Assert.AreEqual(200, x);
        }
    }
}
