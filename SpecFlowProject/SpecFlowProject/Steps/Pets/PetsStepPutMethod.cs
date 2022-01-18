using NUnit.Framework;
using RestSharp;
using SpecFlowProject.Entity;
using SpecFlowProject.Extensions;
using System;
using TechTalk.SpecFlow;


namespace SpecFlowProject.Steps.Pets
{
    [Binding]
    public class PetsStepPutMethod
    {
        private readonly RestClient _client;
        private readonly RestRequest _request;
        private readonly RestResponse _response;
        private readonly ScenarioContext _scenarioContext;

        public PetsStepPutMethod(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Set base url")]
        public void GivenSetBaseUrl()
        {
            _client.SetBaseUrl(_scenarioContext);
        }
        
        [When(@"We created '(.*)' request to '(.*)'")]
        public void WhenWeCreatedRequestTo(Method type, string endPoint)
        {
            _request.CreateRequest(_scenarioContext, type, endPoint);
        }
        
        [When(@"Set data for model '(.*)' to '(.*)'")]
        public void WhenSetDataForModelTo(string data, string value)
        {
            _request.CreateJsonBody(_scenarioContext, value );
        }

        
        [Then(@"We have new Pet")]
        public void ThenWeHaveNewPet()
        {
            _response.ExecuteRequest(_scenarioContext);
            _response.GetResponseContent<Pet>(_scenarioContext);
            var x = _scenarioContext.Get<Pet>("model").Name;
            Assert.AreEqual("Dragon", x);
        }
    }
}
