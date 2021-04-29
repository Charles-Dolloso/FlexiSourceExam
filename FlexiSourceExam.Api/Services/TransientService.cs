using FlexiSourceExam.Api.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace FlexiSourceExam.Api.Services
{
    public static class TransientService
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITextMatchingService, TextMatchingService>();
        }
    }
}
