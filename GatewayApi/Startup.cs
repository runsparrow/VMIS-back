using GatewayApi.Logs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;
using Ocelot.DependencyInjection;
using Ocelot.JwtAuthorize;
using Ocelot.Middleware;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;

namespace GatewayApi
{
    public class Startup
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// 属性
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // 注入MVC
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            // 注入Ocelot服务
            services.AddOcelot();
            //// 注入Swagger
            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("Gateway Api", new Info { Title = "网关服务", Version = "v1" });
            //});
            // 注册JWT
            services.AddOcelotJwtAuthorize();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
            loggerFactory.AddFileLogger();
            loggerFactory.AddNLog();

            app.UseMvc();
            app.UseOcelot().Wait();
        }
    }
}
