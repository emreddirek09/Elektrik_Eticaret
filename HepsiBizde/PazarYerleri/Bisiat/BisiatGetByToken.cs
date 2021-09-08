using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HepsiBizde.PazarYerleri.Bisiat
{
    public class BisiatGetByToken
    {
        public class Message
        {
            [JsonProperty("token")]
            public string Token { get; set; }

            [JsonProperty("token_type")]
            public string TokenType { get; set; }

            [JsonProperty("experies_at")]
            public string ExperiesAt { get; set; }

            [JsonProperty("success")]
            public string Success { get; set; }
        }

        public class GetToken
        {
            [JsonProperty("message")]
            public Message Message { get; set; }
        }
    }
}