namespace VenturaHR.Domain.Models;

public class AuthenticateResponse
{
    public int Id { get; set; }
    public string Email { get; set; }

    public int Tipo { get; set; }

    public string Token { get; set; }
}