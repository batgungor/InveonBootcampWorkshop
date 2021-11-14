using Bootcamp.Workshop.App.API.Controllers;
using Bootcamp.Workshop.Business.Engines.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bootcamp.Workshop.Test.UnitTest.Business
{
    [TestClass]
    public class CatalogEngineTests
    {
        [TestMethod]
        public void CatalogEngine_Sum_ShouldReturnZeroWhenTheNumbersAreZero()
        {
            var catalogEngine = new CatalogEngine(null,null);

            var result = catalogEngine.Sum(5.3, 6.2);

            Assert.IsTrue(result == 11.5);
        }
    }
}
