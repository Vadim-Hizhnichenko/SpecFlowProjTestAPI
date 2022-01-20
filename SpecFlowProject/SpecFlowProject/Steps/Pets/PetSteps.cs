using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SpecFlowProject.Entity;
using SpecFlowProject.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProject.Steps
{
    [Binding]
    public sealed class PetSteps
    {
        private readonly RestClient _client;
        private readonly RestRequest _request;
        private readonly RestResponse _response;
        private readonly ScenarioContext _scenarioContext;

        public PetSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have base url")]
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



        [When(@"I set url parametr '(.*)' to '(.*)'")]
        public void WhenISetUrlParametrTo(string parametr, string value)
        {
            _request.CreateUrlParametr(_scenarioContext, parametr, value);
        }

        [When(@"I send request to API")]
        public void WhenISendRequestToAPI()
        {
            _response.ExecuteRequest(_scenarioContext);

        }


        [When(@"I send request to API with jsonbody")]
        public void WhenISendRequestToAPIWithJsonbody()
        {
            _request.CreateJsonBody(_scenarioContext, new { name = "Lifo" , id = 4});

        }

        [When(@"We set url parametr for picture '(.*)' to '(.*)'")]
        public void WhenWeSetUrlParametrForPictureTo(string name, string value)
        {
            _request.SetNewFile(_scenarioContext, name, value);
        }


        [When(@"We create  '(.*)' request to '(.*)'")]
        public void WhenWeCreateRequestTo(Method type, string endPoint)
        {
            _request.CreateRequest(_scenarioContext, type, endPoint);
        }

        [When(@"Set data for model '(.*)' to '(.*)'")]
        public void WhenSetDataForModelTo(string data, string value)
        {
            _request.CreateJsonBody(_scenarioContext, value);
        }

        [When(@"I create request body for pet")]
        public void WhenICreateRequestBodyForPet(Table petTable)
        {
            var model = petTable.CreateInstance<Pet>();
            var json = JsonConvert.SerializeObject(model);
            _request.CreateJsonBody(_scenarioContext, json);
        }

        [Then(@"I get context request")]
        public void ThenIGetContextRequest()
        {

            _response.GetResponseContent<Pet>(_scenarioContext);
            var x = _scenarioContext.Get<Pet>("model").Name;
            Assert.AreEqual("Lifo", x);
        }


        [Then(@"I get context  API")]
        public void ThenIGetContextAPI()
        {
            _response.GetResponseContentWithList<Pet>(_scenarioContext);
            var x = _scenarioContext.Get<List<Pet>>("model")[0].Status;

            Assert.AreEqual("available", x);
        }

        [Then(@"I get context API")]
        public void WhenIGetContextAPI()
        {

            _response.GetResponseContent<Pet>(_scenarioContext);
            var x = (int)_scenarioContext.Get<Pet>("model").Id;
            Assert.AreEqual(9, x);
        }
        [Then(@"We get some context")]
        public void ThenWeGetSomeContext()
        {
            _response.GetResponseContent<CodeType>(_scenarioContext);
            var x = _scenarioContext.Get<CodeType>("model").Code;
            Assert.AreEqual(200, x);
        }

        [Then(@"We have new Pet")]
        public void ThenWeHaveNewPet()
        {
            _response.GetResponseContent<Pet>(_scenarioContext);
            var x = _scenarioContext.Get<Pet>("model").Name;
            Assert.AreEqual("Frog", x);
        }
    }
}
