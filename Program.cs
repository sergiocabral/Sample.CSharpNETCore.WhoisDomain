using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WhoisDomain.Application;
using WhoisDomain.Service;

using var host = Host
    .CreateDefaultBuilder()
    .ConfigureServices((_, services) => services
        .AddTransient<IApplication, Whois>()
        .AddTransient<ITldWhoisServerDatabase, TldWhoisServerDatabaseIniFile>()
        .AddTransient<ITldWhoisServerList, TldWhoisServerDatabaseHardCoded>()
        .AddTransient<IUserInput, UserInputFromCommandLineArgument>()
        .AddTransient<IWhoisQuery, WhoisQueryTcp>()
        .AddTransient<IWhoisQuery, WhoisQueryIpAddress>()
        .AddTransient<IWhoisQuery, WhoisQueryGeolocation>()
        .AddTransient<IWhoisQuery, WhoisQueryFetchHtml>()
    ).Build();

var application = host.Services.GetRequiredService<IApplication>();
application.Run();
