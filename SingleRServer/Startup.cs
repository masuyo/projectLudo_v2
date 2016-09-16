﻿using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Owin;

namespace SignalRServer
{
    internal class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            // Create JsonSerializer with StringEnumConverter.
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new StringEnumConverter());

            // Register the serializer.
            GlobalHost.DependencyResolver.Register(typeof(JsonSerializer), () => serializer);

            app.Map("/signalr", map =>
            {
                // Setup the cors middleware to run before SignalR.
                // By default this will allow all origins. You can 
                // configure the set of origins and/or http verbs by
                // providing a cors options with a different policy.
                map.UseCors(CorsOptions.AllowAll);

                var hubConfiguration = new HubConfiguration
                {
                    // You can enable JSONP by uncommenting line below.
                    // JSONP requests are insecure but some older browsers (and some
                    // versions of IE) require JSONP to work cross domain
                    // EnableJSONP = true
                };

                hubConfiguration.EnableDetailedErrors = true;
                // Run the SignalR pipeline. We're not using MapSignalR
                // since this branch is already runs under the "/signalr"
                // path.
                map.RunSignalR(hubConfiguration);
            });
        }
    }
}