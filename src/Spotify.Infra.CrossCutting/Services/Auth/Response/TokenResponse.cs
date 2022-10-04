using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Infra.CrossCutting.Services.Auth.Response
{
    public class TokenResponse
    {
        public string AccessToken { get; init; }
    }
}