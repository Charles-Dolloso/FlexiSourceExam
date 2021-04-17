
using FlexiSourceExam.Api.Services;

namespace FlexiSourceExam.Test.Services
{
    public static class ServiceGenerator
    {
        public static TextMatchingService GetService()
        {
            var service = new TextMatchingService();
            return service;
        }
    }
}
