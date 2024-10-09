using BlazorWebApp.Components;
using Syncfusion.Blazor;
using Syncfusion.Blazor.SmartComponents;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSyncfusionBlazor();

string apiKey = "api-key";
string deploymentName = "deploymentName"; 
string endpoint = "";

builder.Services.AddSyncfusionSmartComponents()
.ConfigureCredentials(new AIServiceCredentials(apiKey, deploymentName, endpoint))
.InjectOpenAIInference();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
