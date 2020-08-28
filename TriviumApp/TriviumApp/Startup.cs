using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using TriviumApp.Services;
using TriviumApp.DictionaryUtils;

namespace TriviumApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDictionaryService, DictionaryService>();
            services.AddTransient<IReportService, ReportService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, 
            IDictionaryService dictionaryService, IReportService reportService)
        {
            app.Run(async context =>
            {
                // Getting right header dictionary metadata.
                var rightHeaderDictionaryMetaData = dictionaryService.GetDictionaryMetadataById(1);
                // Getting right header dictionary data.
                var rightHeaderDictionaryData = dictionaryService.GetDictionaryDataById(1, DictionaryType.Buildings);
                // Getting top header dictionary metadata.
                var topHeaderDictionaryMetaData = dictionaryService.GetDictionaryMetadataById(2);
                // Getting top header dictionary data.
                var topHeaderDictionaryData = dictionaryService.GetDictionaryDataById(2, DictionaryType.Versions);
                
                string report = reportService.GetReportByDictionaryMetadata(
                    rightHeaderDictionaryMetaData,
                    topHeaderDictionaryMetaData,
                    rightHeaderDictionaryData, 
                    topHeaderDictionaryData);
                
                var sb = new StringBuilder();
                sb.Append(report);
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync(sb.ToString());
            });

        }
    }
}
