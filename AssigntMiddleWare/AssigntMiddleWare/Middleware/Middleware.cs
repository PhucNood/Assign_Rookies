using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AssigntMiddleWare.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //xu ly thong tin trong context
            string requestBodyContent;
            var httpRequest = context.Request;
            var schema = httpRequest.Scheme;
            var host = httpRequest.Host.Host;
            var path = httpRequest.Path.ToString();
            var queryString = httpRequest.QueryString.HasValue ? httpRequest.QueryString.Value : null;
            var requestBody = httpRequest.Body;
            if (requestBody != null)
            {
                //doc body
                using (var reader = new StreamReader(requestBody, Encoding.UTF8, false))
                {
                    requestBodyContent = await reader.ReadToEndAsync();
                    // use the body, process the stuff...

                }
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Schema: {schema} \n Host: {host} \n Path: {path} \n QueryString: {queryString} \n Request Body: {requestBody}");
            string normalized = Regex.Replace(stringBuilder.ToString(), @"\r\n|\n\r|\n|\r", "\r\n");
            //append line
            // call write file
            WriteFile(normalized);
            await _next(context);
        }

        private async void WriteFile(string  content)
        {
            await File.WriteAllTextAsync("./LogText/LogInfor.txt",content);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
