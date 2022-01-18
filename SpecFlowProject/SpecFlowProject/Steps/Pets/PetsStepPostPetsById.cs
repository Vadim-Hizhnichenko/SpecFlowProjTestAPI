using NUnit.Framework;
using RestSharp;
using SpecFlowProject.Entity;
using SpecFlowProject.Extensions;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class PetsStepPostPetsById
    {
        private readonly RestClient _client;
        private readonly RestRequest _request;
        private readonly RestResponse _response;
        private readonly ScenarioContext _scenarioContext;

        public PetsStepPostPetsById(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have base url for this method")]
        public void GivenIHaveBaseUrlForThisMethod()
        {
            _client.SetBaseUrl(_scenarioContext);
        }
        
        [When(@"I created '(.*)' request to '(.*)'")]
        public void WhenICreatedRequestTo(Method type, string endPoint)
        {
            _request.CreateRequest(_scenarioContext, Method.POST, endPoint);
        }
        
        [When(@"I set url segments  '(.*)' to '(.*)'")]
        public void WhenISetUrlSegmentsTo(string urlSegment, int value)
        {
            _request.CreateUrlSegment(_scenarioContext, urlSegment, value);

        }

        [When(@"I set url paramet for '(.*)' to '(.*)'")]
        public void WhenISetUrlParametForTo(string urlParametr, string value)
        {
            _request.CreateUrlParametr(_scenarioContext, urlParametr, value);
        }


        [When(@"I set url parametrs '(.*)' to '(.*)'")]
        public void WhenISetUrlParametrsTo(string urlParametr, string value)
        {
            _request.CreateUrlParametr(_scenarioContext, urlParametr, value);
        }
        
        [When(@"Set last parametr '(.*)' to '(.*)'")]
        public void WhenSetLastParametrTo(string urlParametr, string value)
        {
            _request.CreateUrlParametr(_scenarioContext, urlParametr, value);
        }
        
        [Then(@"We get some context")]
        public void ThenWeGetSomeContext()
        {
            _response.ExecuteRequest(_scenarioContext);
            _response.GetResponseContent<CodeType>(_scenarioContext);
            var x = _scenarioContext.Get<CodeType>("model").Code;
            Assert.AreEqual(200, x);
        }
    }
}
