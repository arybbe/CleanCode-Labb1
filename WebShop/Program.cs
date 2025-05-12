using WebShop.Extensions;
using WebShop.Notifications;
using WebShop.Repositories;
using WebShop.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repository & UoW
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Observer-pattern (får ligga kvar om du vill ha flera observatörer)
builder.Services.AddTransient<INotificationObserver, EmailNotification>();

// Strategy-pattern
builder.Services.AddScoped<INotificationStrategy, EmailNotificationStrategy>();
builder.Services.AddScoped<INotificationStrategy, SmsNotificationStrategy>();
builder.Services.AddScoped<NotificationContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapProductEndpoints();


app.Run();
