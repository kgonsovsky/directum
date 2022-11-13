using Calendar.Model;

namespace Calendar.Bl
{
    public struct EventModify
    {
        public uint Reminder;
    }

    public static class EventExtensions
    {
        public static DateTime End(this Event ev) => ev.Start.AddMinutes(ev.Duration);

        public static bool HasIntersect(this Event ev, Event target)
        {
            return (((ev.Start <= target.Start) && (ev.End() >= target.Start)) ||
                    ((ev.Start <= target.End()) && (ev.End() >= target.End())) ||
                    ((ev.Start >= target.Start) && (ev.End() <= target.End())));
        }

        public static bool HasStartOnDay(this Event ev, DateTime dateTime)
        {
            return ev.Start.Year == dateTime.Year && ev.Start.Month == dateTime.Month && ev.Start.Day == dateTime.Day;
        }

        public static bool HasRemind(this Event ev, DateTime now) => !ev.HasOutOfDate(now) && now > ev.Start.AddMinutes(ev.Reminder * -1);

        public static bool HasOutOfDate(this Event ev, DateTime now) => ev.End() < now;
    }
}
