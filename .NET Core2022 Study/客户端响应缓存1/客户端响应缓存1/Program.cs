using Zack.ASPNETCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();//注入内存缓存服务
builder.Services.AddScoped<IMemoryCacheHelper, MemoryCacheHelper>();//注入Zack.ASPNETCore的服务 验证数据的安全性和实现随机缓存过期时间
builder.Services.AddScoped<IDistributedCacheHelper, DistributedCacheHelper>();//杨老师针对分布式缓存雪崩问题的组件
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost";
    options.InstanceName = "Zane_";//避免混乱,连接Redis
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseResponseCaching();//启用服务器端缓存

app.MapControllers();

app.Run();
