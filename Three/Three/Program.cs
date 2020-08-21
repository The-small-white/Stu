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
           //主机构建上下文，配置生成器 配置代理
           //.ConfigureAppConfiguration((context, configBuilder) =>
           //{
           //    configBuilder.Sources.Clear();//第一步首先清理默认'源'配置
           //    configBuilder.AddJsonFile("nick.json");//第二步添加自己要用的json文件
           //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                });
    }
}
