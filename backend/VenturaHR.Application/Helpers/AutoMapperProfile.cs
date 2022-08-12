namespace VenturaHR.Application.Helpers;

using AutoMapper;
using VenturaHR.Domain.Entities.Usuario;
using VenturaHR.Domain.Models;

/// <summary>
/// Perfil de automapeamento entre classes de entidade e DTOs
/// </summary>
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // User -> AuthenticateResponse
        CreateMap<Usuario, AuthenticateResponse>();

        // RegisterRequest -> User
        CreateMap<RegisterRequest, Usuario>();

        // UpdateRequest -> User
        CreateMap<UpdateRequest, Usuario>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignorar nulos e strings vazias
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));
    }
}