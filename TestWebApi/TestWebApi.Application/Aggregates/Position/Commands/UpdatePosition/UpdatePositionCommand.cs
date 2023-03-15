using AutoMapper;
using MediatR;
using TestWebApi.Application.Mappings;

namespace TestWebApi.Application.Aggregates.Position.Commands.UpdatePosition;

public class UpdatePositionCommand : IRequest<Unit>, IMapTo<Domain.Entities.Position>
{
    /// <summary>
    /// Position id
    /// </summary>
    public int PositionId { get; set; }
    
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
        profile.CreateMap<UpdatePositionCommand, Domain.Entities.Position>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.PositionId))
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
            .ForMember(d => d.Grade, opt => opt.MapFrom(s => s.Grade));
    }
}