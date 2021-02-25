using System;

namespace HttpClientGenerator.AccessTokenManagment
{
    public class ClientAccessToken
    {
        /// <summary>
        /// The access token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// The access token expiration
        /// </summary>
        public DateTimeOffset Expiration { get; set; }
    }
}
