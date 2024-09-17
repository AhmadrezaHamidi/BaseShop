using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmadShop.Application.CQRS.Commands.User
{
    public class TokenDto 
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        //[JsonProperty("refresh_token")]
        //public string RefreshToken { get; set; }
        //public int UserId { get; set; }

        //public string Email { get; set; }
        //public string Roles { get; set; }

    }
}
