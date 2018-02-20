using Microsoft.AspNetCore.Mvc.RazorPages;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vote.Common
{
    public class BasePageModel : PageModel
    {
        public string HostName { get; set; } = Environment.MachineName;
        public Option OptionA { get; private set; }
        public Option OptionB { get; private set; }

        protected ConnectionMultiplexer Redis { get; private set; }

        public BasePageModel()
        {
            OptionA = new Option
            {
                Title = "Tabs"
            };
            OptionB = new Option
            {
                Title = "Spaces"
            };

            var options = new ConfigurationOptions
            {
                AbortOnConnectFail = false,
                EndPoints = { "redis" }
            };

            Redis = ConnectionMultiplexer.Connect(options);
            IDatabase db = Redis.GetDatabase();

            OptionA.Counter = (int)db.StringGet(OptionA.Title);
            OptionB.Counter = (int)db.StringGet(OptionB.Title);
        }
    }

    public class Option
    {
        public string Title { get; set; }

        public int Counter { get; set; }
    }
}
