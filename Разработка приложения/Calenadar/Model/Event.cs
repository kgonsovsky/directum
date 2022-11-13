namespace Calendar.Model
{
    public record Event: Base
    {
        public DateTime Start { get; init; }

        public uint Duration { get; init; }

        public uint Reminder { get; set; }

        public List<Person> Participants { get; set; }

    }
}
