using NUnit.Framework;
using RestSharp;
using SpecFlowProject.Entity;
using SpecFlowProject.Extensions;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class PetsStepsPostPets
    {
        private readonly RestClient _client;
        private readonly RestRequest _request;
        private readonly RestResponse _response;
        private readonly ScenarioContext _scenarioContext;

        public PetsStepsPostPets(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have base pet url for POST")]
        public void GivenIHaveBasePetUrlForPOST()
        {
            _client.SetBaseUrl(_scenarioContext);
        }
        
        [When(@"We create  '(.*)' request to '(.*)'")]
        public void WhenWeCreateRequestTo(Method type, string endPoint)
        {
            _request.CreateRequest(_scenarioContext, Method.POST, endPoint);
        }
        
        [When(@"I send  request to API")]
        public void WhenISendRequestToAPI()
        {
            _request.CreateJsonBody(_scenarioContext, new { name = "Fifo" });
        }
        
        [Then(@"I get  context")]
        public void ThenIGetContext()
        {
            _response.ExecuteRequest(_scenarioContext);
            _response.GetResponseContent<Pet>(_scenarioContext);
            var x = _scenarioContext.Get<Pet>("model").Name;
            Assert.AreEqual("Fifo", x);            
        }
    }
}
