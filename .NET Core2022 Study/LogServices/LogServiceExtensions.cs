using LogServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

//LogServices修改为： Microsoft.Extensions.DependencyInjection  这样免于using
namespace Microsoft.Extensions.DependencyInjection 
{
   public static class LogServiceExtensions
    {
        public static void AddConsoleLog(this IServiceCollection services)//this 不能忘了，不加 this  方法.后会点不出来.
        {
            services.AddScoped <ILogService, LogService > ();
        }
    }
}
