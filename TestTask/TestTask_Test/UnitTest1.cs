using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Models;
using TestTask.Services;
using Xunit;

namespace TestTask_Test
{
    public class UnitTest1
    {
        [Fact]
        public async Task TestMattching()
        {
            //Act
            var server = new TestServer (new WebHostBuilder().UseStartup<TestTask.Startup>());

            var client = server.CreateClient();

            var result = await client.GetStringAsync("");

            //Arrange
            List<NewTransaction> fakeTransactionList = new List<NewTransaction>();
            fakeTransactionList.Add(new NewTransaction { Source = "12345678 - 11111111 - 12345678", Destiny = "12345678-22222222-12345678", Amount = "1000"});
            fakeTransactionList.Add(new NewTransaction { Source = "12345678-22222222-12345678", Destiny = "12345678 - 11111111 - 12345678", Amount = "1000" });
            //Assert
            Assert.Equal(fakeTransactionList, result);
        }
    }
}
