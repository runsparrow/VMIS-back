using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.JwtAuthorize;
using Ocelot.Middleware;

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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseOcelot().Wait();
        }
    }
}
