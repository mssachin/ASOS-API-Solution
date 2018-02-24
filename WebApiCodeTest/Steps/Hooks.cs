using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace WebApiCodeTest.Steps
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private static TestExecutionContext Context = new TestExecutionContext();

        [BeforeTestRun]
        public static void BeforeTestRun()
        {

            Context.EstablishExecutionEnvironment();

        }

      
    }
}
