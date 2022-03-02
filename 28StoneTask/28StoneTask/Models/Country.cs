namespace _28StoneTask.Models;

public class Country
{
    public string Name { get; set; }
    public double Area { get; set; }
    public int Population { get; set; }
    public List<string> TopLevelDomain { get; set; }
    public string NativeName { get; set; }
    public bool Independent { get; set; }
}