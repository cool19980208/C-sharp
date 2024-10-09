using Zack.ASPNETCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();//ע���ڴ滺�����
builder.Services.AddScoped<IMemoryCacheHelper, MemoryCacheHelper>();//ע��Zack.ASPNETCore�ķ��� ��֤���ݵİ�ȫ�Ժ�ʵ������������ʱ��
builder.Services.AddScoped<IDistributedCacheHelper, DistributedCacheHelper>();//����ʦ��Էֲ�ʽ����ѩ����������
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost";
    options.InstanceName = "Zane_";//�������,����Redis
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

//app.UseResponseCaching();//���÷������˻���

app.MapControllers();

app.Run();
