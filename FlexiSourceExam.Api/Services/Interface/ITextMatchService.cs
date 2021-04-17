
using FlexiSourceExam.Api.Models.Request;
using FlexiSourceExam.Api.Models.Response;
using System;

namespace FlexiSourceExam.Api.Services.Interface
{
    public interface ITextMatchingService
    {
        public ExamResponse GetAllIndexResult(ExamRequest request, StringComparison comparisonType);
    }
}
