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
       
        public void ConfigureServices(IServiceCollection services)//��Ҫ������������ע�����
        {
            //DI���ŵ�
            //���û��ǿ���� ���ڵ�Ԫ����
            //����Ҫ�˽����ķ�����
            //Ҳ����Ҫ������������������
            //services.AddMvc();//��ȫ�ܵ�ע��
            services.AddControllersWithViews();//����mvc�����õ�
            //ע��·��
            services.AddSingleton<IClock, ChinaClock>();//ֻ����һ��ʵ��
            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.Configure<ThreeOptions>(_configuration.GetSection("Font"));//ӳ���ֺ���
            // services.AddSingleton<IClock,UtcClock>();

            // services.AddControllers();//���ֻ����webApi֮���������Ϳ���
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline(�ܵ� ������Ӧhttp����).
       // public void ConfigureDevelopment(IApplicationBuilder app, IWebHostEnvironment env) { }//��Բ�ͬ���������в�ͬ�������Լ�����
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())//�ж��Ƿ񿪷�ģʽ
            {
                app.UseDeveloperExceptionPage();//������ʾ����ҳ
            }


            //ע��˳�򣡣���
            app.UseStaticFiles();//���ʾ�̬�ļ��м��
            app.UseFileServer();
            app.UseHttpsRedirection();//ǿ��ת����https����
            app.UseAuthentication();//�����֤�м��

            app.UseRouting();//·���м��

            //(http����)�˵��м��
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllerRoute(
                    name: "dafault",
                    pattern:"{controller=Home}/{action=Index}/{id?}") ;
               // endpoints.MapControllers();���·��ģʽҲ����
            });
        }
    }
}
