using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using AppreciationApp.Function.Query;
using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;

namespace AppreciationApp.Function
{
    /// <summary>
    /// This has been written using FunctionMonkey
    /// The docs are here: https://functionmonkey.azurefromthetrenches.com/guides/introduction.html
    /// </summary>
    public class ServerlessConfiguration : IFunctionAppConfiguration
    {
        public void Build(IFunctionHostBuilder builder)
        {
            builder
                .Setup((serviceCollection, commandRegistry) =>
                {
                    commandRegistry.Discover<ServerlessConfiguration>();
                })
                .Functions(functions => functions
                    .HttpRoute("Appreciations", route => route
                        .HttpFunction<GetAppreciationsQuery>(HttpMethod.Get)
                    )
                );
        }
    }
}
