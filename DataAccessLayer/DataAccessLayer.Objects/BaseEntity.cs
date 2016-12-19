namespace DataAccessLayer.Objects
{
    /// <summary>
    /// Базовая модель для всех энтити
    /// </summary>
    /// <typeparam name="T">тип первичного ключа</typeparam>
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
