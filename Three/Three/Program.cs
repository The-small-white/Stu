using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Three
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
           //�������������ģ����������� ���ô���
           //.ConfigureAppConfiguration((context, configBuilder) =>
           //{
           //    configBuilder.Sources.Clear();//��һ����������Ĭ��'Դ'����
           //    configBuilder.AddJsonFile("nick.json");//�ڶ�������Լ�Ҫ�õ�json�ļ�
           //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                });
    }
}
