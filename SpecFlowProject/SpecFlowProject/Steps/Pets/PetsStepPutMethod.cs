using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;
using SpecFlowProject.Entity;
using SpecFlowProject.Extensions;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;



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

        [When(@"I create request body for pet")]
        public void WhenICreateRequestBodyForPet(Table petTable)
        {
            var model = petTable.CreateInstance<Pet>();
            model.Tags.Add(new Category());
            model.PhotoUrls.Add("first");
            var json = JsonConvert.SerializeObject(model);
            _request.CreateJsonBody(_scenarioContext, json);
        }


        [Then(@"We have new Pet")]
        public void ThenWeHaveNewPet()
        {
            _response.ExecuteRequest(_scenarioContext);
            _response.GetResponseContent<Pet>(_scenarioContext);
            var x = _scenarioContext.Get<Pet>("model").Name;
            Assert.AreEqual("Frog", x);
        }
    }
}
