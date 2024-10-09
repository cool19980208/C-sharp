using StackExchange.Redis;
using System.Data.SqlClient;
using �ۺ����ü���1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.ConfigureAppConfiguration((hostCtx, configBuilder) => {
    //var configRoot = builder.Configuration;
    //string connStr = configRoot.GetConnectionString("conn1"); 
    string connStr = builder.Configuration.GetSection("ConnStr").Value;//��.Net 6��ֱ��ʹ��builder����  .NET6֮ǰ������configRoot�����������
    configBuilder.AddDbConfiguration(() => new SqlConnection(connStr), reloadOnChange: true, reloadInterval: TimeSpan.FromSeconds(2));
});


builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    //��Program.cs�ж�ȡ���õ�һ�ַ���
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
