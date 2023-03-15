using AutoMapper;
using MediatR;
using TestWebApi.Application.Mappings;

namespace TestWebApi.Application.Aggregates.Position.Commands.CreatePosition;

public class CreatePositionCommand : IRequest<Unit>, IMapTo<Domain.Entities.Position>
{
    /// <summary>
    /// Name of position
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Grade
    /// From 1 to 15
    /// </summary>
    public int Grade { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreatePositionCommand, Domain.Entities.Position>()
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
            .ForMember(d => d.Grade, opt => opt.MapFrom(s => s.Grade));
    }
}