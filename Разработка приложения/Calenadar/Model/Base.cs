namespace Calendar.Model
{
    public abstract record Base
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public string Name { get; set; } = "";
    }
}
