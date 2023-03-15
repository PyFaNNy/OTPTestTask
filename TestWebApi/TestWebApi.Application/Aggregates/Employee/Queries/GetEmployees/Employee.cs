using AutoMapper;
using TestWebApi.Application.Mappings;

namespace TestWebApi.Application.Aggregates.Employee.Queries.GetEmployees;

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

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Employee, Employee>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
            .ForMember(d => d.MiddleName, opt => opt.MapFrom(s => s.MiddleName))
            .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
            .ForMember(d => d.DateBirth, opt => opt.MapFrom(s => s.DateBirth.Date));
    }
}