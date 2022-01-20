using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Steps.Pets
{
    [Binding]
    public sealed class BaseStep
    {

        private readonly RestClient _client;
        private readonly RestRequest _request;
        private readonly RestResponse _response;
        private readonly ScenarioContext _scenarioContext;

        public BaseStep(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
