using MediatR;

namespace WhereIsMyFleet.Services
{
    public class BaseValidator<TRequest> : FluentValidation.AbstractValidator<TRequest>
            where TRequest : IRequest<object>
    {
    }
}
