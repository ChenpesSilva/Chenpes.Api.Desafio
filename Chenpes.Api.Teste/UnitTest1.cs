using Chenpes.Api.Desafio.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace Chenpes.Api.Teste
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodGetSucesso()
        {
            var Uri = @ResourceBase.UriBase;
            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(Uri))
                {
                    Assert.AreEqual(response.Result.IsSuccessStatusCode, true);
                }
            }
        }
        [TestMethod]
        public void TestMethodGetErro()
        {
            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(@ResourceBase.UriBase))
                {
                    Assert.AreNotEqual(response.Result.IsSuccessStatusCode, false);
                }
            }
        }
    }
}
