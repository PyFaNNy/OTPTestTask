namespace TestWebApi.Domain.Entities;

public class Position
{
    /// <summary>
    /// Position id
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
    /// Employees of position
    /// </summary>
    public List<Employee> Employees { get; set; }
}