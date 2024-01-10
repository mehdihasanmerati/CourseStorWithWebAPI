using CourseStor.DAL.DbContexts;
using CourseStor.Models.Frameworks;
using MediatR;

namespace CourseStor.BLL.Frameworks
{
    public abstract class ApplicationServiceHandler<TRequest, TResult> : IRequestHandler<TRequest, ApplicationServiceResponse<TResult>>
        where TRequest : IRequest<ApplicationServiceResponse<TResult>>
    {
        protected readonly CourseStorDbContext _context;
        private readonly ApplicationServiceResponse<TResult> _response = new ApplicationServiceResponse<TResult> { };
        public ApplicationServiceHandler(CourseStorDbContext context)
        {
            _context = context;
        }
        public async Task<ApplicationServiceResponse<TResult>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request, cancellationToken);
            return _response;
        }
        protected abstract Task HandleRequest(TRequest request, CancellationToken cancellationToken);

        public void AddError(string error)
        {
            _response.AddError(error);
        }

        public void AddResult(TResult result) => _response.Result = result;
    }
}
