using FlexiSourceExam.Api.Models.Request;
using FlexiSourceExam.Api.Models.Response;
using FlexiSourceExam.Api.Services.Interface;
using System;
using System.Collections.Generic;

namespace FlexiSourceExam.Api.Services
{
    public class TextMatchingService : ITextMatchingService
    {
        public ExamResponse GetAllIndexResult(ExamRequest request, StringComparison comparisonType)
        {
            if (string.IsNullOrEmpty(request.Text))
                throw new ArgumentNullException("Text is empty");
            if (string.IsNullOrEmpty(request.Subtext))
                throw new ArgumentNullException("Subtext is empty");
            if (request.Subtext.Length > request.Text.Length)
                throw new ArgumentNullException("Subtext is longer than text");

            IList<int> resultIndex = new List<int>();
            int index = request.Text.IndexOf(request.Subtext, comparisonType);
            while (index != -1)
            {
                resultIndex.Add(index);
                index = request.Text.IndexOf(request.Subtext, index + 1, comparisonType);
            }
            return new ExamResponse { Result = string.Join(",", resultIndex) };
        }
    }
}
