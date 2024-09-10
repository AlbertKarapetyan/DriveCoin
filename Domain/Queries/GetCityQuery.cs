using DTO;
using MediatR;

namespace Domain.Queries
{
    public record GetCityQuery(short id) : IRequest<CityDTO?>;
}
