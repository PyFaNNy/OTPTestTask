namespace TestWebApi.Domain.Entities;

public class Employee
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
}