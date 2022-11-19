namespace StudentManager.Backend.Entities
{
    public class BaseEntity<T>
    {
        public BaseEntity()
        {

        }
        public T Id { get; set; }
        public string Name { get; set; }
    }
}
