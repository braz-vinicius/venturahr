namespace VenturaHR.Domain.Interfaces
{
    /// <summary>
    /// Marker interface that represents a domain entity
    /// </summary>
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}