using MediatR;

namespace WhereIsMyFleet.Services
{
    public abstract class BaseRequest<TResponse> : IRequest<TResponse>
        where TResponse : BaseResponse
    {
    }
}
