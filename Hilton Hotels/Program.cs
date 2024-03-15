using Hilton_Hotels.Services;
using Hilton_Hotels.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<ICustomerService, CustomerServiceJson>();
builder.Services.AddSingleton<IRoomService, RoomServiceJson>();
builder.Services.AddSingleton<IPaymentService, PaymentService>();
builder.Services.AddSingleton<IBookingServices, BookingService>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
