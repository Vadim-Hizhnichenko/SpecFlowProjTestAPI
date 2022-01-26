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
    public sealed class StoreStep
    {
        private readonly RestClient _client;
        private readonly RestRequest _request;
        private readonly RestResponse _response;
        private readonly ScenarioContext _scenarioContext;

        public StoreStep(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I create body request for order")]
        public void WhenICreateBodyRequestForOrder(Table orderTable)
        {
            _request.CreateJsonBody(_scenarioContext, JsonConvert.SerializeObject(orderTable.CreateInstance<Order>()));
        }

        
        [Then(@"User should be see order data Id '(.*)' PetId '(.*)' Quantity '(.*)' ShipDate '(.*)' Status'(.*)' Complete '(.*)'")]
        public void ThenUserShouldBeSeeOrderDataIdPetIdQuantityShipDateStatusComplete(int id, int petId, int quantity, string shipDate, string status, bool complete)
        {
            _response.GetResponseContent<Order>(_scenarioContext);
            Assert.AreEqual(id, _scenarioContext.Get<Order>("model").Id);
            Assert.AreEqual(petId, _scenarioContext.Get<Order>("model").PetId);
            Assert.AreEqual(quantity, _scenarioContext.Get<Order>("model").Quantity);
            Assert.AreEqual(shipDate, _scenarioContext.Get<Order>("model").ShipDate.Replace("+0000", "Z"));
            Assert.AreEqual(status, _scenarioContext.Get<Order>("model").Status);
            Assert.AreEqual(complete, _scenarioContext.Get<Order>("model").Complete);

        }


        [Then(@"I get order by his id '(.*)'")]
        public void ThenIGetOrderByHisId(int orderId)
        {
            _response.GetResponseContent<Order>(_scenarioContext);
            Assert.AreEqual(orderId, _scenarioContext.Get<Order>("model").Id);
        }

        [Then(@"User should be see '(.*)' status")]
        public void ThenUserShouldBeSeeStatus(string status)
        {
            _response.GetResponseContent<Order>(_scenarioContext);
            Assert.AreEqual(status, "available");
        }




    }
}
