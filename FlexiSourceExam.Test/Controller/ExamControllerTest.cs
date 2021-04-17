using FlexiSourceExam.Api.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace FlexiSourceExam.Test.Controller
{
    public class ExamControllerTest
    {
        [Fact]
        public void Post_ReturnsOk()
        {
            var req = new ExamRequest();
            var mockService = MockServiceGenerator.GetMockTextService();
            var controller = ControllerGenerator.GetTextController(mockService.Object);
            var response = controller.Post(req);
            var result = response as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void Post_ArgumentException_ReturnsBadRequest()
        {
            var req = new ExamRequest();
            var mockService = MockServiceGenerator.GetMockTextService();
            var controller = ControllerGenerator.GetTextController(mockService.Object);

            mockService.Setup(i => i.GetAllIndexResult(It.IsAny<ExamRequest>(), StringComparison.OrdinalIgnoreCase))
               .Throws<ArgumentException>();

            var response = controller.Post(req);
            var result = response as BadRequestObjectResult;
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void Post_ModelStateInvalid_ReturnsBadRequest()
        {
            var req = new ExamRequest();
            var mockService = MockServiceGenerator.GetMockTextService();
            var controller = ControllerGenerator.GetTextController(mockService.Object);
            controller.ModelState.AddModelError("key", "error message");
            var response = controller.Post(req);
            var result = response as BadRequestObjectResult;
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }
    }
}
