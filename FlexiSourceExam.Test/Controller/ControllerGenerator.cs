using FlexiSourceExam.Api.Controllers;
using FlexiSourceExam.Api.Services.Interface;

namespace FlexiSourceExam.Test.Controller
{
    public static class ControllerGenerator
    {
        public static ExamController GetTextController(ITextMatchingService service) => new ExamController(service);
    }
}