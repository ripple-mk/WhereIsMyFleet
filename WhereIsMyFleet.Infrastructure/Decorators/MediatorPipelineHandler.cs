using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WhereIsMyFleet.Core.Abstractions;
using WhereIsMyFleet.Core.Abstractions.Exceptions;
using WhereIsMyFleet.Services;

namespace WhereIsMyFleet.Infrastructure.Decorators
{
    public class MediatorPipelineHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
                where TRequest : IRequest<TResponse>
                where TResponse : class
    {
        private readonly IRequestHandler<TRequest, TResponse> _handler;
        private readonly IConfigurationService _configurationService;
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public MediatorPipelineHandler(
                                IRequestHandler<TRequest, TResponse> handler,
                                IEnumerable<IValidator<TRequest>> validators,
                                IConfigurationService configurationService)
        {
            _handler = handler;
            _configurationService = configurationService;

            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            TResponse response = default(TResponse);
            var errors = Validate(request);
            if (errors.Any())
                throw new ValidationException(errors);

            response = await _handler.Handle(request, System.Threading.CancellationToken.None);

            try
            {
                await (Task)_handler.GetType()
                                .GetMethod(nameof(BaseHandler<BaseRequest<BaseResponse>, BaseResponse>.SaveChanges))
                                .Invoke(_handler, null);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw new CustomException("Cannot store your data in our database. Please try again later. If this error persists, please contact our customer support.");
            }
            return response;
        }

        private IEnumerable<ValidationFailure> Validate(TRequest request)
        {
            ValidatorOptions.Global.LanguageManager.Enabled = true;
            ValidatorOptions.Global.LanguageManager.Culture = Thread.CurrentThread.CurrentCulture;
            var context = new ValidationContext<TRequest>(request);
            return _validators
                .Select(validator => validator.Validate(context))
                .SelectMany(result => result.Errors);
        }
    }
}
