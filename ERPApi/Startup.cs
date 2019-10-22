using ERPApi.Entities.WFM;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Ocelot.JwtAuthorize;
using Swashbuckle.AspNetCore.Swagger;
using System.Threading.Tasks;

namespace ERPApi
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
            // 启动基础表的缓存
            Status.Instance.CacheAll();
            // 注册AspNetMvc
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            // 注册Swagger生成器，定义一个和多个Swagger 文档
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("ERPApi", new Info { Title = "ERP Api", Version = "v1" });
            });
            // 注册JWT
            services.AddTokenJwtAuthorize();

            services.AddApiJwtAuthorize((context) =>
            {
                return true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // 启用中间件服务JWT验证
            app.UseAuthentication(); 
            // 启用中间件服务生成Swagger作为JSON终结点
            app.UseSwagger();
            // 启用中间件服务对swagger-ui，指定Swagger JSON终结点
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/ERPApi/swagger.json", "ERPApi V1");
            });
            // 启用中间件服务进行异常处理
            app.UseMiddleware(typeof(ExceptionHandlerMiddleWare));
            // 启动MVC
            app.UseMvc();
            // 启动静态路径
            DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(defaultFilesOptions);
            app.UseStaticFiles();
            // 启动重定向
            app.Run(context =>
            {
                context.Response.Redirect("swagger");
                return Task.FromResult(0);
            });
        }
    }
}
