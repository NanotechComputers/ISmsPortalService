using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ServiceStack;
using SmsPortal.Extensions;
using SmsPortal.Models;

namespace SmsPortal
{
    public class SmsPortalService : ISmsPortalService
    {
        // ReSharper disable once InconsistentNaming
        private string _clientSecret { get; set; }

        // ReSharper disable once InconsistentNaming
        private string _url { get; set; }

        // ReSharper disable once InconsistentNaming
        private string _clientId { get; set; }

        // ReSharper disable once InconsistentNaming
        private string _token { get; set; }

        // ReSharper disable once InconsistentNaming
        private DateTime _tokenExpires { get; set; }

        // ReSharper disable once UnusedMember.Global
        public SmsPortalService(IOptions<SmsPortalServiceOptions> options)
        {
            _url = options.Value.Url;
            _clientId = options.Value.ClientId;
            _clientSecret = options.Value.ClientSecret;
        }

        // ReSharper disable once UnusedMember.Global
        public SmsPortalService(string url, string clientId, string clientSecret)
        {
            _url = url;
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        private async Task GetTokenAsync()
        {
            var token = $"{_clientId}:{_clientSecret}".ToBase64();
            var response = await $"{_url}/Authentication".GetJsonFromUrlAsync(requestFilter: httpReq => { httpReq.Headers.Add(new NameValueCollection {{"Authorization", $"Basic {token}"}}); });
            var getTokenResponse = JsonConvert.DeserializeObject<TokenResponse>(response);
            _token = getTokenResponse.Token;
            _tokenExpires = DateTime.Now.AddMinutes(getTokenResponse.ExpiresInMinutes - 1);
        }

        private bool TokenExpired()
        {
            return _tokenExpires <= DateTime.Now || string.IsNullOrWhiteSpace(_token);
        }

        public async Task<MessageResponse> SendMessageAsync(string message, string mobile)
        {
            if (TokenExpired())
            {
                await GetTokenAsync();
            }

            var messages = new List<Message>
            {
                new Message
                {
                    Content = message,
                    Destination = mobile
                }
            };
            var response = await $"{_url}/bulkmessages".PostJsonToUrlAsync(new {Messages = messages}, requestFilter:
                httpReq => { httpReq.Headers.Add(new NameValueCollection {{"Authorization", $"Bearer {_token}"}}); }
            );
            var sendMessageResponse = JsonConvert.DeserializeObject<MessageResponse>(response);
            return sendMessageResponse;
        }

        public async Task<MessageResponse> SendMessagesAsync(List<Message> messages)
        {
            if (TokenExpired())
            {
                await GetTokenAsync();
            }

            if (messages.Count > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(messages));
            }

            var response = await $"{_url}/bulkmessages".PostJsonToUrlAsync(new {Messages = messages}, requestFilter:
                httpReq => { httpReq.Headers.Add(new NameValueCollection {{"Authorization", $"Bearer {_token}"}}); }
            );
            var sendMessageResponse = JsonConvert.DeserializeObject<MessageResponse>(response);
            return sendMessageResponse;
        }
    }
}