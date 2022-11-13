using Calendar.Model;

namespace Calendar.Service
{
    public class Storage
    {
        private readonly object LockObject = new();

        public readonly List<Person> Person = new();

        public readonly List<Event> Event = new();

        public readonly List<Notice> Notice =new();

        public void Run(Action action)
        {
            lock (LockObject)
            {
                action();
            }
        }
    }
}
