namespace VenturaHR.Application.Helpers;

using System.Globalization;

/// <summary>
/// Representa uma classe especializada para disparar e tratar exceções da aplicação
/// </summary>
public class AppException : Exception
{
    public AppException() : base() { }

    public AppException(string message) : base(message) { }

    public AppException(string message, params object[] args)
        : base(string.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}