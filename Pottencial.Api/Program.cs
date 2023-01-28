using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Pottencial.Domain.Handlers;
using Pottencial.Domain.Repositories;
using Pottencial.Infra.Context;
using Pottencial.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

ConfigureMvc(builder);
builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("Database"));

Dependencies(builder);
ConfigureSwagger(builder);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();


void Dependencies(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IItemRepository, ItemRepository>();
    builder.Services.AddTransient<ISellerRepository, SellerRepository>();
    builder.Services.AddTransient<IOrderRepository, OrderRepository>();

    builder.Services.AddTransient<ItemHandler, ItemHandler>();
    builder.Services.AddTransient<SellerHandler, SellerHandler>();
    builder.Services.AddTransient<OrderHandler, OrderHandler>();
}

void ConfigureMvc(WebApplicationBuilder builder)
{
    builder.Services
        .AddControllers().AddNewtonsoftJson(x =>
        {
            x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            x.SerializerSettings.Converters.Add(new StringEnumConverter());
        })
        .ConfigureApiBehaviorOptions(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        })
        .AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
        });
}


void ConfigureSwagger(WebApplicationBuilder builder)
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}
