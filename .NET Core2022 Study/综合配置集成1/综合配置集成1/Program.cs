using StackExchange.Redis;
using System.Data.SqlClient;
using 综合配置集成1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.ConfigureAppConfiguration((hostCtx, configBuilder) => {
    //var configRoot = builder.Configuration;
    //string connStr = configRoot.GetConnectionString("conn1"); 
    string connStr = builder.Configuration.GetSection("ConnStr").Value;//在.Net 6中直接使用builder即可  .NET6之前都是用configRoot来做这个动作
    configBuilder.AddDbConfiguration(() => new SqlConnection(connStr), reloadOnChange: true, reloadInterval: TimeSpan.FromSeconds(2));
});


builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    //在Program.cs中读取配置的一种方法
    string constr = builder.Configuration.GetSection("Redis").Value;
    return ConnectionMultiplexer.Connect(constr);
});

builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("Smtp"));

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
