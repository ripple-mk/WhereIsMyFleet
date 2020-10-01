using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Threading;
using System.Threading.Tasks;
using WhereIsMyFleet.Core.Abstractions.Exceptions;
using WhereIsMyFleet.Core.Features.Fleet;

namespace WhereIsMyFleet.Services.Features.ToDos
{
    public class AddDrone
    {
        public class Request : BaseRequest<Response>
        {
            public string Name { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }

        public class Response : BaseResponse
        {
            public Guid Id { get; set; }
        }

        public class Validator : BaseValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
                RuleFor(x => x.Latitude).NotNull();
                RuleFor(x => x.Longitude).NotNull();
            }
        }

        public class Handler : BaseHandler<Request, Response>
        {
            public override async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                if (await Query<Drone>().AnyAsync(x => x.Name == request.Name))
                    throw new CustomException("A drone with the same name already exists");

                var item = new Drone
                {
                    Name = request.Name,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude
                };
                var id = Add(item);
                return new Response
                {
                    Id = id
                };
            }
        }
    }
}
