using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace API.Extensions
{
    internal static class WebApplicationBuilderExtension
    {
        internal static void RegisterSerilog(this WebApplicationBuilder builder)
        {
            var logging = builder.Logging;
            logging.ClearProviders();

            var env = builder.Environment.EnvironmentName;
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env}.json", true)
                .Build();

            var connectionString = configuration.GetConnectionString("Default");

            var columnOptions = new ColumnOptions()
            {
                TimeStamp = { ConvertToUtc = true, ColumnName = "CreatedTimeUtc" }
            };
            columnOptions.Store.Remove(StandardColumn.MessageTemplate);

            logging.AddSerilog(new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Error)
                .MinimumLevel.Override("Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware", LogEventLevel.Information)
                .WriteTo.MSSqlServer(
                    connectionString: connectionString,
                    sinkOptions: new MSSqlServerSinkOptions
                    {
                        TableName = "Logs",
                        AutoCreateSqlTable = true,
                    },
                    columnOptions: columnOptions)
                .CreateLogger());
        }

        internal static void ConfigureServices(this WebApplicationBuilder builder)
        {
            var services = builder.Services;
            var configuration = builder.Configuration;

            // Add services to the container.
            services.AddRazorPages();
            services.RegisterConnectionString(configuration);
            services.AddHttpContextAccessor();
            services.RegisterServices();
            services.RegisterRepositories();
            services.RegisterAuthentication(configuration);
            services.AddAuthorization();
        }

        internal static WebApplication Configure(this WebApplicationBuilder builder)
        {
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            //app.RegisterSwaggerUI();
            app.MapRazorPages();

            app.InitializeDatabase();
            app.RegisterMapping();

            return app;
        }
    }
}