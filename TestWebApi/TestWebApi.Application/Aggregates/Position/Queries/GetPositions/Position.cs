using AutoMapper;
using TestWebApi.Application.Mappings;

namespace TestWebApi.Application.Aggregates.Position.Queries.GetPositions;

public class Position : IMapFrom<Domain.Entities.Position>
{
    /// <summary>
    /// Id of position
    /// </summary>
    public int Id { get; set; }
    
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
        profile.CreateMap<Domain.Entities.Position, Position>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
            .ForMember(d => d.Grade, opt => opt.MapFrom(s => s.Grade));
    }
}