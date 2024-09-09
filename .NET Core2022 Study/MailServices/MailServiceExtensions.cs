using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailServices
{
   public static class MailServiceExtensions
    {
        public static void AddMail(this IServiceCollection services)//this 不能忘了，不加 this  方法.后会点不出来.
        {
            services.AddScoped<IMailService, MailService>();
        }
    }
}
