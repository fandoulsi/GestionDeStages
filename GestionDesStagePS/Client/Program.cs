using GestionDesStagePS.Client;
using GestionDesStagePS.Client.Interfaces;
using GestionDesStagePS.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GestionStage.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("GestionStage.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("GestionDesStagePS.ServerAPI"));

            builder.Services.AddApiAuthorization();

            // Pour appliquer les policy
            builder.Services.AddAuthorizationCore(authorizationOptions =>
            {
                authorizationOptions.AddPolicy(
                   @GestionDesStagePS.Shared.Policies.Policies.EstEtudiant,
                    GestionDesStagePS.Shared.Policies.Policies.EstEtudiantPolicy());
                authorizationOptions.AddPolicy(
                   @GestionDesStagePS.Shared.Policies.Policies.EstEntreprise,
                    GestionDesStagePS.Shared.Policies.Policies.EstEntreprisePolicy()
                    );
            });

            //TODO: Modifier les points de terminaisons pour la production
            builder.Services.AddHttpClient<IStageDataService, StageDataService>(client => client.BaseAddress = new Uri("https://localhost:44393/"));
            builder.Services.AddHttpClient<IStageStatutDataService, StageStatutDataService>(client => client.BaseAddress = new Uri("https://localhost:44393/"));
            builder.Services.AddHttpClient<IEtudiantDataService, EtudiantDataService>(client => client.BaseAddress = new Uri("https://localhost:44393/"));

            await builder.Build().RunAsync();
        }
    }
}
