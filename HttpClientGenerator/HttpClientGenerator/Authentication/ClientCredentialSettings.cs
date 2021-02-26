﻿namespace HttpClientGenerator.Authentication
{
    public class ClientCredentialSettings
    {
        public string TokenEndpoint { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Scope { get; set; }
    }
}
