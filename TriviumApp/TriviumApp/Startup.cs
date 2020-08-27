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
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDictionaryService dictionaryService)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.Run(async context =>
            {
                var sb = new StringBuilder();
                
                sb.Append("<table>");
                // Получаем метаданные справочника и выводим заголовки.
                var dictionaryMetadata = dictionaryService.GetDictionaryMetadataById(2);
                sb.Append("<tr>");
                foreach (DictionaryAttribute attribute in dictionaryMetadata.Attributes)
                {
                    sb.Append($"<th>{attribute.Name}</th>");
                }
                sb.Append("</tr>");
                
                // Получаем данные словаря по его id и типу и выводим данные.
                var dictionaryData = dictionaryService.GetDictionaryDataById(2, DictionaryType.Versions);
                foreach (IDictionaryRow row in dictionaryData.Rows)
                {
                    sb.Append("<tr>");
                    foreach (var item in row.Items) 
                    {
                        sb.Append($"<td>{item}</td>");
                    }
                    sb.Append("</tr>");
                }

                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync(sb.ToString());
            });

        }
    }
}
