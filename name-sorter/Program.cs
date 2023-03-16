using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using name_sorter;
using name_sorter_library.Service;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
   await services.GetRequiredService<App>().Run(args);
}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}


static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)        
         .ConfigureServices(services =>
         {
             services.AddScoped<IFileService, FileService>();    
             services.AddSingleton<App>(); 
         });
}