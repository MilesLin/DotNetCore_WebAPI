using DotNetCore_WebAPI.Entities;
using DotNetCore_WebAPI.Models;
using DotNetCore_WebAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace DotNetCore_WebAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Add the CORS services            
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",                        
                    builder => builder.WithOrigins("http://localhost:2038"));
            });

            // Add framework services.
            services.AddMvc()
                .AddXmlDataContractSerializerFormatters();
            //.AddMvcOptions(o =>
            //{
            //    這兩種方式都可以得到一樣的結果
            //    o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            //});
#if DEBUG
            services.AddTransient<IMailService, LocalMailService>();
#else
            services.AddTransient<IMailService, CloudMailService>();
#endif
            services.Configure<MailSettings>(options => Configuration.GetSection("mailSettings").Bind(options));

            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=CityInfoDB;Trusted_Connection=True;";
            services.AddDbContext<CityInfoContext>(o => o.UseSqlServer(connectionString));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            CityInfoContext cityInfoContext)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //loggerFactory.AddProvider(new NLog.Extensions.Logging.NLogLoggerProvider());
            loggerFactory.AddNLog();

            cityInfoContext.EnsureSeedDataForContext();

            app.UseStatusCodePages();

            app.UseCors("AllowSpecificOrigin");

            app.UseMvc();
        }
    }
}