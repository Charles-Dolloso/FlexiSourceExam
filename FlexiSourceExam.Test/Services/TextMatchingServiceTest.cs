
using FlexiSourceExam.Api.Models.Request;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FlexiSourceExam.Test.Services
{
    public class TextMatchingServiceTest
    {
        public TextMatchingServiceTest() { }

        [Theory]
        [InlineData("sampleSAMPLESampleSamPlesamPle", "sample", "0,6,12,18,24")]
        [InlineData("sampleSampleSampleSampleSampleMeSample", "sample", "0,6,12,18,24,32")]
        [InlineData("0101001111001010", "1", "1,3,6,7,8,9,12,14")]
        public void StringSearch_ReturnsListInt(string valueText, string valueSubtext, string valueResult)
        {
            var service = ServiceGenerator.GetService();
            var request = new ExamRequest { Text = valueText, Subtext = valueSubtext };
            var result = service.GetAllIndexResult(request, StringComparison.OrdinalIgnoreCase);
            Assert.NotNull(result);
            Assert.Equal(result.Result, valueResult);
        }

        [Theory]
        [InlineData("", "sample")] // empty text request
        [InlineData("sample", "")] // empty subtext request
        [InlineData("sample", "SampleMe")] // text length greater than subtext
        public void StringSearch_ThrowsArgumentException(string valueText, string valueSubtext)
        {
            var request = new ExamRequest { Text = valueText, Subtext = valueSubtext };
            var service = ServiceGenerator.GetService();
            Assert.Throws<ArgumentNullException>(() => service.GetAllIndexResult(request, StringComparison.OrdinalIgnoreCase));
        }
    }
}
