using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WhereIsMyFleet.Core.Features.Fleet;

namespace WhereIsMyFleet.Services.Features.Fleet
{
    public class ListDrones
    {
        public class Request : BaseRequest<Response>
        {

        }

        public class Response : BaseResponse
        {
            public List<Drone> List { get; set; }
            public class Drone
            {
                public Guid Id { get; set; }
                public string Name { get; set; }
                public double Latitude { get; set; }
                public double Longitude { get; set; }
            }
        }

        public class Handler : BaseHandler<Request, Response>
        {
            public override async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var items = await Query<Drone>().ToListAsync();
                return new Response
                {
                    List = items?.Select(x => new Response.Drone
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Latitude = x.Latitude,
                        Longitude = x.Longitude
                    })?.ToList()
                };
            }
        }
    }
}
