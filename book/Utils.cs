using book.Data.Services;
using Microsoft.AspNetCore.Server.IIS.Core;
using System.Runtime.CompilerServices;

namespace ServicesMethods
{
    public static class Utils
    {
        public static void ConnectServices(this WebApplicationBuilder o)
        {
            o.Services.AddControllers();
            o.Services.AddTransient<BookService>();
            o.Services.AddTransient<PublisherService>();
            o.Services.AddTransient<AuthorService>();
        }

    }
}
