using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace WebApiCodeTest.Steps
{
    [Binding]
    public class CommonSteps : StepsBase
    {
        [When(@"(?i)the response is received")]
        public void WhenIGetTheResponseBackFromApi()
        {
            
            Response = Client.Execute<dynamic>((RestRequest)ScenarioContext.Current["Request"]);
            ScenarioContext.Current["Response"] = Response;
           
        }
    }
}
