namespace Clean_arch.Domain.Shared
{
    public class BaseEntity
    {
        public long Id { get; private set; }
        public DateTime CreationDate { get; }

        public BaseEntity()
        {
            CreationDate = new DateTime();
        }
    }
}