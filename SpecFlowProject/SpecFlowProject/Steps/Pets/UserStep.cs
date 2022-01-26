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

namespace SpecFlowProject.Steps.Pets
{
    [Binding]
    public sealed class UserStep
    {

        private readonly RestClient _client;
        private readonly RestRequest _request;
        private readonly RestResponse _response;
        private readonly ScenarioContext _scenarioContext;

        public UserStep(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I create body request for user")]
        public void WhenICreateBodyRequestForUser(Table userTable)
        {
            _request.CreateJsonBody(_scenarioContext, JsonConvert.SerializeObject(userTable.CreateInstance<User>()));
        }

        [When(@"I create body request for user with array")]
        public void WhenICreateBodyRequestForUserWithArray(Table userTable)
        {
            _request.CreateJsonBody(_scenarioContext, JsonConvert.SerializeObject(userTable.CreateSet<User>()));
        }

        [When(@"I set url string segment '(.*)' to '(.*)'")]
        public void WhenISetUrlStringSegmentTo(string urlSegment, string value)
        {
            _request.CreateUrlSegment(_scenarioContext, urlSegment, value);
        }


        [Then(@"I get user by his name '(.*)'")]
        public void ThenIGetUserByHisName(string name)
        {
            _response.GetResponseContent<User>(_scenarioContext);
            Assert.AreEqual(name, _scenarioContext.Get<User>("model").Username);
        }

       


    }
}
