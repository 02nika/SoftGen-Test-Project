namespace DataAccess.Model.General
{
    public abstract class BaseEntity<T> : IBaseEntity
    {
        public T Id { get; set; }

        object IBaseEntity.Id
        {
            get => Id;
            set { }
        }
    }
}
