﻿using AutoMapper;
using TestWebApi.Application.Mappings;

namespace TestWebApi.Application.Aggregates.Position.Queries.GetPosition;

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
    
    /// <summary>
    /// Employees in this position
    /// </summary>
    public List<Employee> Employees { get; set; }
        
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Position, Position>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
            .ForMember(d => d.Grade, opt => opt.MapFrom(s => s.Grade))
            .ForMember(d => d.Employees, opt => opt.MapFrom(s => s.Employees));
    }
}

public class Employee : IMapFrom<Domain.Entities.Employee>
{
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
            .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
            .ForMember(d => d.MiddleName, opt => opt.MapFrom(s => s.MiddleName))
            .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
            .ForMember(d => d.DateBirth, opt => opt.MapFrom(s =>s.DateBirth));
    }
}