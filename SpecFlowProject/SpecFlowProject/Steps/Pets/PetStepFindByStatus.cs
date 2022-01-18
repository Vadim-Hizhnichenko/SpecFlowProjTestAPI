using NUnit.Framework;
using RestSharp;
using SpecFlowProject.Entity;
using SpecFlowProject.Extensions;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class PetStepFindByStatus
    {
        private readonly RestClient _client;
        private readonly RestRequest _request;
        private readonly RestResponse _response;
        private readonly ScenarioContext _scenarioContext;

        public PetStepFindByStatus(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have base pet url for this method")]
        public void GivenIHaveBasePetUrlForThisMethod()
        {
            _client.SetBaseUrl(_scenarioContext);
        }
        
        [When(@"We create '(.*)' request to '(.*)'")]
        public void WhenWeCreateRequestTo(Method type, string endPoint)
        {
            _request.CreateRequest(_scenarioContext, Method.GET, endPoint);
        }
        
        [When(@"I set url parametr '(.*)' to '(.*)'")]
        public void WhenISetUrlParametrTo(string parametr, string value)
        {
            _request.CreateUrlParametr(_scenarioContext, parametr, value);
        }
        
        [When(@"I send request to our API")]
        public void WhenISendRequestToOurAPI()
        {
            _response.ExecuteRequest(_scenarioContext);
        }
        
        [Then(@"I get context  API")]
        public void ThenIGetContextAPI()
        {
            _response.GetResponseContentWithList<Pet>(_scenarioContext);
            var x = _scenarioContext.Get<List<Pet>>("model")[0].Status;
            
            Assert.AreEqual("available", x);
        }
    }
}
