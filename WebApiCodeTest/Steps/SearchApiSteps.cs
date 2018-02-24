using System.Net;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApiCodeTest.Steps
{
    [Binding]
    public class SearchApiSteps : StepsBase
    {
        private const string SearchV1Path = "/product/search/V1/";
        private const string Accept = "application/json";
        private const string Store = "1";
        private const string Lang = "en";
        private const string Currency = "GBP";
        private const string OffSet = "0";
        private const string Q = "";
        private const string Limit = "10";
        private const HttpStatusCode statusCode = HttpStatusCode.OK;

        [Given(@"(?i)I search for (.*) items")]
        public void GivenISearchForItems(string searchTerm)
        {
            Request = new RestRequest(Method.GET)
            {
                Resource = SearchV1Path
            };

            Request.AddHeader("Accept", Accept);
            Request.AddParameter("store", Store);
            Request.AddParameter("lang", Lang);
            Request.AddParameter("currency", Currency);
            Request.AddParameter("offset", OffSet);
            Request.AddParameter("q", searchTerm);
            Request.AddParameter("limit", Limit);
            ScenarioContext.Current["Request"] = Request;
        }

        [Then(@"(?i)I will receive an (.*) response")]
        public void ThenIWillReceiveAnResponse(HttpStatusCode statusCode)
        {
            statusCode = HttpStatusCode.OK;
            Response = (IRestResponse)ScenarioContext.Current["Response"];
            Assert.That(Response.StatusCode, Is.EqualTo(statusCode));
        }


        [Given(@"I search without a search term")]
        public void GivenISearchWithoutASearchTerm()
        {
            Request = new RestRequest(Method.GET)
            {
                Resource = SearchV1Path
            };

            Request.AddHeader("Accept", Accept);
            Request.AddParameter("store", Store);
            Request.AddParameter("lang", Lang);
            Request.AddParameter("currency", Currency);
            Request.AddParameter("offset", OffSet);
            Request.AddParameter("q", "");
            Request.AddParameter("limit", Limit);
            ScenarioContext.Current["Request"] = Request;
        }

        [Then(@"I will receive a ""(.*)"" response")]
        public void ThenIWillReceiveAResponse(HttpStatusCode statusCode)
        {

            statusCode = HttpStatusCode.BadRequest;
            Response = (IRestResponse)ScenarioContext.Current["Response"];
            Assert.That(Response.StatusCode, Is.EqualTo(statusCode));

        }


        [Given(@"I search with an incorrect or correct '(.*)'")]
        public void GivenISearchWithAnIncorrectOrCorrect(string searchTerm)
        {
            Request = new RestRequest(Method.GET)
            {
                Resource = SearchV1Path
            };

            Request.AddHeader("Accept", Accept);
            Request.AddParameter("store", Store);
            Request.AddParameter("lang", Lang);
            Request.AddParameter("currency", Currency);
            Request.AddParameter("offset", OffSet);
            Request.AddParameter("q", searchTerm);
            Request.AddParameter("limit", Limit);
            ScenarioContext.Current["Request"] = Request;
        }


        

        [Then(@"the response contains spell-check correction '(.*)'")]
        public void ThenTheResponseContainsSpell_CheckCorrection(bool flag)
        {
            Response = (IRestResponse)ScenarioContext.Current["Response"];
            var apiResponse = JObject.Parse(Response.Content);
            var searchMetaPassObject = apiResponse.Value<JObject>("searchPassMeta");
            bool actualFlagValue = (bool)searchMetaPassObject.Property("isSpellcheck");
            Assert.IsTrue(flag.Equals(actualFlagValue));
            
        }


    }
}