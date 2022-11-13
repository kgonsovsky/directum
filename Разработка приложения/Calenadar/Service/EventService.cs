using Calendar.Bl;
using Calendar.Model;

namespace Calendar.Service
{
    public class EventService
    {
        private readonly Storage _storage;

        public EventService(Storage storage)
        {
            _storage = storage;
        }

        public void Add(Event ev)
        {
            _storage.Run(() =>
            {
                if (ev.Start < DateTime.Today)
                {
                    throw new ArgumentException("Планируются только на будущее время.");
                }
                if (_storage.Event.Any(ev.HasIntersect))
                {
                    throw new ArgumentException("Встречи пересекаются");
                }
                _storage.Event.Add(ev);
            });
        }

        public void Remove(Event ev)
        {
            _storage.Run(() =>
            {
                var a = _storage.Event.FirstOrDefault(a => a.Id == ev.Id);
                if (a == null)
                {
                    throw new ArgumentException("Встреча не найдена");
                }
                _storage.Event.Remove(a);
            });
        }

        public void Modify(Event ev, EventModify modify)
        {
            _storage.Run(() =>
            {
                var a =_storage.Event.FirstOrDefault(a => a.Id == ev.Id);
                if (a == null)
                {
                    throw new ArgumentException("Встреча не найдена");
                }

                if (a.Reminder == modify.Reminder)
                {
                    throw new ArgumentException("Нет изменений");
                }
                a.Reminder = modify.Reminder;
            });
        }

        public IEnumerable<Event> All => _storage.Event;
    }
}
