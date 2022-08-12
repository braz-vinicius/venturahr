namespace VenturaHR.Application.Helpers;

using System.Globalization;

/// <summary>
/// Representa uma classe especializada para disparar e tratar exce��es da aplica��o
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