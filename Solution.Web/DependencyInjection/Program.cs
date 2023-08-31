using DependencyInjection;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices(
    (_, services) => services.AddHostedService<Worker>()
    .AddScoped<IMessageWriter, LoggingMessageWriter>());
    // .AddScoped<IMessageWriter, MessageWriter>());

using var host = builder.Build();

host.Run();
