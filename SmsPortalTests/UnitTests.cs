using System;
using System.Threading.Tasks;
using SmsPortal;
using Xunit;

namespace SmsPortalTests
{
    public class UnitTests
    {
        [Fact]
        public async Task TestSendMessage()
        {
            var service = new SmsPortalService("https://rest.mymobileapi.com","ClientId","ClientSecret"); 
            var response = await service.SendMessageAsync("Message", "Mobile Number");
            Assert.True(response.Cost > 0);
        }
    }
}