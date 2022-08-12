namespace VenturaHR.Domain.Models;

public class UpdateRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
}