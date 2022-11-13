namespace Calendar.Model
{
    public record Notice: Base
    {
        public Person Participant { get; init; }

        public Event Event { get; init; }
    }
}
