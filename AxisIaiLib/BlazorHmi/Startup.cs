using BlazorHmi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PLCConnector;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TcOpen.Inxton.TcoCore.Blazor.Extensions;
using Vortex.Presentation.Blazor.Services;

namespace BlazorHmi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddVortexBlazorServices();
            services.AddTcoCoreExtensions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            TcOpen.Inxton.TcoAppDomain.Current.Builder.SetUpLogger(
                new TcOpen.Inxton.Logging.SerilogAdapter(
                    new Serilog.LoggerConfiguration().WriteTo.Console()
                )
            );

            Entry.Plc.Connector.BuildAndStart();

            Entry.Plc.MAIN._app._logger.StartLoggingMessages(TcoCore.eMessageCategory.Error, 10);
        }
    }
}
