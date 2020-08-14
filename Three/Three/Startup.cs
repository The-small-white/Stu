using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Three.Service;
using Three.Services;

namespace Three
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration) 
        {
            _configuration = configuration;
           // var font = _configuration["Font:BoldDepartmentEmployeeCountThreshold"];
        }
       
        public void ConfigureServices(IServiceCollection services)//主要负责配置依赖注入相关
        {
            //DI的优点
            //解耦，没有强依赖 利于单元测试
            //不需要了解具体的服务类
            //也不需要管理服务类的生命周期
            //services.AddMvc();//最全能的注入
            services.AddControllersWithViews();//开发mvc类型用的
            //注入路径
            services.AddSingleton<IClock, ChinaClock>();//只能有一个实例
            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.Configure<ThreeOptions>(_configuration.GetSection("Font"));//映射字号类
            // services.AddSingleton<IClock,UtcClock>();

            // services.AddControllers();//如果只开发webApi之类的用这个就可以
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline(管道 用来响应http请求).
       // public void ConfigureDevelopment(IApplicationBuilder app, IWebHostEnvironment env) { }//针对不同环境可以有不同方法，自己定义
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())//判断是否开发模式
            {
                app.UseDeveloperExceptionPage();//用来显示错误页
            }


            //注意顺序！！！
            app.UseStaticFiles();//访问静态文件中间件
            app.UseFileServer();
            app.UseHttpsRedirection();//强制转换成https请求
            app.UseAuthentication();//身份认证中间件

            app.UseRouting();//路由中间件

            //(http请求)端点中间件
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllerRoute(
                    name: "dafault",
                    pattern:"{controller=Home}/{action=Index}/{id?}") ;
               // endpoints.MapControllers();这个路由模式也可以
            });
        }
    }
}
