using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.Models.Frameworks
{
    public class ApplicationServiceResponse
    {
        private readonly List<string> _errors = new();
        public bool isFailure => _errors.Any();
        public bool IsSuccess => !isFailure;

        public void AddError(string errorMessage)
        {
            _errors.Add(errorMessage);
        }

        public IReadOnlyList<string> Errors => _errors;
    }

    public class ApplicationServiceResponse<TResult>: ApplicationServiceResponse
    {
        public TResult Result { get; set; }
    }
}
