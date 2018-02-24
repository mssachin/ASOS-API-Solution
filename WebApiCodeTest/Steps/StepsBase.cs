using System;
using NUnit.Framework.Internal;
using RestSharp;
using TechTalk.SpecFlow;


namespace WebApiCodeTest.Steps
{
    [Binding]
    public class StepsBase
    {
        protected RestClient Client;
        protected RestRequest Request;
        protected IRestResponse Response;
        protected ScenarioContext ScenarioContext;
       
        
        

        protected readonly Uri BaseUri = new Uri("http://searchapi.asos.com");

        public StepsBase()
        {
            Client = new RestClient(BaseUri);

        }
    }
}