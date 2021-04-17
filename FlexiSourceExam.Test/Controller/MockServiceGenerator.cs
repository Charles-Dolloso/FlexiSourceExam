
using FlexiSourceExam.Api.Services.Interface;
using Moq;

namespace FlexiSourceExam.Test.Controller
{
    public static class MockServiceGenerator
    {
        public static Mock<ITextMatchingService> GetMockTextService() => new Mock<ITextMatchingService>();
    }
}