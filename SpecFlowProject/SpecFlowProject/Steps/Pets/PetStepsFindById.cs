using NUnit.Framework;
using RestSharp;
using SpecFlowProject.Entity;
using SpecFlowProject.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Steps
{
    [Binding]
    public sealed class PetStepsFindById
    {
        private readonly RestClient _client;
        private readonly RestRequest _request;
        private readonly RestResponse _response;
        private readonly ScenarioContext _scenarioContext;

        public PetStepsFindById(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have base pet url")]
        public void GivenIHaveBasePetUrl()
        {
            _client.SetBaseUrl(_scenarioContext);
        }

        [When(@"I create '(.*)' request to '(.*)'")]
        public void WhenICreateRequestTo(Method type, string endPoint)
        {
            _request.CreateRequest(_scenarioContext, type, endPoint);

        }

        [When(@"I set url segment '(.*)' to '(.*)'")]
        public void WhenISetUrlSegmentTo(string urlSegment, int value)
        {
            _request.CreateUrlSegment(_scenarioContext, urlSegment, value);

        }

        [When(@"I send request to API")]
        public void WhenISendRequestToAPI()
        {
            _response.ExecuteRequest(_scenarioContext);

        }

        [Then(@"I get context API")]
        public void WhenIGetContextAPI()
        {
            
            _response.GetResponseContent<Pet>(_scenarioContext);
            var x = (int)_scenarioContext.Get<Pet>("model").Id;
            Assert.AreEqual(9, x);
        }

    }
}
