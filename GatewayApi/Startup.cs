using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;

namespace GatewayApi
{
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // 注入Ocelot验证
            //var authenticationProviderKey = "OcelotKey";
            //services.AddAuthentication().AddJwtBearer(authenticationProviderKey, x => {
            //    x.Authority = "test";
            //    x.Audience = "test";
            //});
            // 注入Ocelot服务
            services.AddOcelot();
            // 注入MVC
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //// 注入Swagger
            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("Gateway Api", new Info { Title = "网关服务", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseOcelot().Wait();
            app.UseMvc();
        }
    }
}
