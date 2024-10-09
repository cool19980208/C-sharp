using ClassLibrary1;
using ClassLibrary2;
using Zack.Commons;

namespace DIWebAPI1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<MyService1>();//Diע��
            builder.Services.AddScoped<TestService>();//Diע��
            //������Ŀ��ע�����
            /* builder.Services.AddScoped<Class1>();
             builder.Services.AddScoped<Class2>();
             builder.Services.AddScoped<Class3>();
             builder.Services.AddScoped<Class4>();*/
            var assemblies = ReflectionHelper.GetAllReferencedAssemblies();//��ʼ��DI����
            builder.Services.RunModuleInitializers(assemblies);

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
