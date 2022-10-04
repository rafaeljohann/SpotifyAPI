using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Infra.CrossCutting.Services.Auth
{
    public interface ITokenProvider
    {
        Task<string> GetTokenAsync();
    }
}