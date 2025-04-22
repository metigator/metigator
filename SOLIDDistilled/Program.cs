using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SolidDistilled;
using SolidDistilled.Data;
using SolidDistilled.Services;
using SolidDistilled.State;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<AppState>();
builder.Services.AddSingleton<BookRepository>();
builder.Services.AddScoped<BookShopService>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
