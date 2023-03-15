using AutoMapper;
using TestWebApi.Application.Mappings;

namespace TestWebApi.Application.Aggregates.Employee.Queries.GetEmployee
{
    public class Employee : IMapFrom<Domain.Entities.Employee>
    {
        /// <summary>
        /// Employee id
        /// </summary>
        public int Id { get; set; }
    
        /// <summary>
        /// Employee firstName
        /// </summary>
        public string FirstName { get; set; }
    
        /// <summary>
        /// Employee lastName
        /// </summary>
        public string LastName { get; set; }
    
        /// <summary>
        /// Employee's father's name
        /// </summary>
        public string MiddleName { get; set; }
    
        /// <summary>
        /// Employee date of birth
        /// </summary>
        public DateTime DateBirth { get; set; }
        
        /// <summary>
        /// Employee positions
        /// </summary>
        public List<Position> Positions { get; init; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Employee, Employee>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.MiddleName, opt => opt.MapFrom(s => s.MiddleName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.DateBirth, opt => opt.MapFrom(s =>DateBirth))
                .ForMember(d => d.Positions, opt => opt.MapFrom(s =>s.Positions));
        }
    }

    public class Position : IMapFrom<Domain.Entities.Position>
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
            profile.CreateMap<Domain.Entities.Position, Position>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Grade, opt => opt.MapFrom(s => s.Grade));
        }
    }
}
