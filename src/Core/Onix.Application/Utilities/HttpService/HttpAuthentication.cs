﻿using Onix.Application.Enums;

namespace Onix.Application.Utilities.HttpService
{
    public class HttpAuthentication
    {
        private AuthorizationScheme _authorization { get; set; }
        public string AuthenticationKey { get; set; }
        public HttpAuthentication(AuthorizationScheme authorization, string authKey)
        {
            _authorization = authorization;
            AuthenticationKey = authKey;
        }

        public string AuthenticationSchemeName => Enum.GetName<AuthorizationScheme>(_authorization);
            
    }
}
