using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using SpecFlowProject.Entity;
using SpecFlowProject.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [When(@"I send request to API with jsonbody params such as the name '(.*)' and id '(.*)'")]
        public void WhenISendRequestToAPIWithJsonbodyParamsSuchAsTheNameAndId(string namePet, int petId)
        {
            _request.CreateJsonBody(_scenarioContext, new { name = namePet, id = petId });
        }


        [When(@"We set url parametr for picture '(.*)' to '(.*)'")]
        public void WhenWeSetUrlParametrForPictureTo(string name, string value)
        {
            _request.SetNewFile(_scenarioContext, name, value);
        }


        [When(@"I create request body for pet")]
        public void WhenICreateRequestBodyForPet(Table petTable)
        {
            _request.CreateJsonBody(_scenarioContext, JsonConvert.SerializeObject(petTable.CreateInstance<Pet>()));

        }


        [Then(@"User should see that new pet with '(.*)' name was created")]
        public void ThenUserShouldSeeThatNewPetWithNameWasCreated(string name)
        {
            _response.GetResponseContent<Pet>(_scenarioContext);
            Assert.AreEqual(name, _scenarioContext.Get<Pet>("model").Name);
        }

        // GET Method. Find pet by status 
        [Then(@"I find pet by status his status '(.*)'")]
        public void ThenIFindPetByStatusHisStatus(string status)
        {
            _response.GetResponseContentWithList<Pet>(_scenarioContext);
            Assert.AreEqual(status, _scenarioContext.Get<List<Pet>>("model")[0].Status);
        }

        [Then(@"I get pet by his id '(.*)'")]
        public void ThenIGetPetByHisId(int petId)
        {
            _response.GetResponseContent<Pet>(_scenarioContext);
            Assert.AreEqual(petId, (int)_scenarioContext.Get<Pet>("model").Id);
        }

        [Then(@"User should be see code status '(.*)' and message '(.*)' id")]
        public void ThenUserShouldBeSeeCodeStatusAndMessage(int codeStatus, string messId)
        {
            _response.GetResponseContent<CodeType>(_scenarioContext);
            Assert.AreEqual(codeStatus, _scenarioContext.Get<CodeType>("model").Code);
            Assert.AreEqual(messId, _scenarioContext.Get<CodeType>("model").Message);
        }


        [Then(@"User should be see code status '(.*)'")]
        public void ThenUserShouldBeSeeCodeStatus(int codeStatus)
        {
            _response.GetResponseContent<CodeType>(_scenarioContext);
            Assert.AreEqual(codeStatus, _scenarioContext.Get<CodeType>("model").Code);
        }
        

        [Then(@"User shod be see update model with name '(.*)' , status '(.*)' and id '(.*)'")]
        public void ThenUserShodBeSeeUpdateModelWithNameStatusAndId(string name, string status, int id)
        {
            _response.GetResponseContent<Pet>(_scenarioContext);
            Assert.AreEqual(name, _scenarioContext.Get<Pet>("model").Name);
            Assert.AreEqual(status, _scenarioContext.Get<Pet>("model").Status);
            Assert.AreEqual(id, _scenarioContext.Get<Pet>("model").Id);
        }

        [When(@"I create request body for pets")]
        public void WhenICreateRequestBodyForPets(Table table)
        {
            var model = table.CreateInstance<Pet>();

            _scenarioContext.Remove("model");
            _scenarioContext.Add("model", model);
            
            
        }
        [When(@"I create request body for category")]
        public void WhenICreateRequestBodyForPetss(Table table)
        {

            var category = table.CreateInstance<Category>();
            var petModel = _scenarioContext.Get<Pet>("model");
            petModel.Category = category;
            _scenarioContext.Remove("model");
            _scenarioContext.Add("model", petModel);

        }
        [When(@"I create request body for tags")]
        public void WhenICreateRequestBodyForPetsss(Table table)
        {
            //var tags = table.CreateInstance<List<Category>>();
            //var petModel = _scenarioContext.Get<Pet>("model");
            //petModel.Tags = tags;

            //_scenarioContext.Remove("model");
            //_scenarioContext.Add("model", petModel);

            var tags = table.CreateSet<Category>();
            
            var petModel = _scenarioContext.Get<Pet>("model");
            petModel.Tags = (List<Category>)tags;

            _scenarioContext.Remove("model");
            _scenarioContext.Add("model", petModel);



        }

        [When(@"request full body to request")]
        public void WhenRequestFullBodyToRequest()
        {
            var obj = _scenarioContext.Get<Pet>("model");
            _request.CreateJsonBody(_scenarioContext,JsonConvert.SerializeObject(obj));

        }


        [Then(@"User shod see Pet Id '(.*)' NamePet '(.*)' status '(.*)' photo urls '(.*)' categoryId '(.*)' categoryName '(.*)' tagsId '(.*)' tagsName '(.*)'")]
        public void ThenUserShodSeePetIdNamePetStatusPhotoUrlsCategoryIdCategoryNameTagsIdTagsName(int idPet, string petName, string status, string photo, int categotyId, string categoryname, int tagsId, string tagsname)
        {
            _response.GetResponseContent<Pet>(_scenarioContext);
            Assert.AreEqual(petName, _scenarioContext.Get<Pet>("model").Name);
            Assert.AreEqual(status, _scenarioContext.Get<Pet>("model").Status);
            Assert.AreEqual(idPet, _scenarioContext.Get<Pet>("model").Id);
            Assert.AreEqual(photo, _scenarioContext.Get<Pet>("model").PhotoUrls[0]);
            Assert.AreEqual(categotyId, _scenarioContext.Get<Pet>("model").Category.Id);


        }








    }
}
