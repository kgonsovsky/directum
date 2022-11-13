using Calendar.Bl;
using Calendar.Model;
using Newtonsoft.Json;

namespace Calendar.Service
{
    public class PersonService
    {
        private readonly Storage _storage;

        public PersonService(Storage storage)
        {
            _storage = storage;
        }

        public Person Add(string name)
        {
            var p = new Person() { Name = name };
            _storage.Run(() =>
            {
                _storage.Person.Add(p);
            });
            return p;
        }

        public List<Person> All => _storage.Person;

        public List<Event> ListEvents(Person person, DateTime date) =>
            _storage.Event.Where(a => 
                a.Participants.Any(p => p.Id == person.Id) && a.HasStartOnDay(date)

                ).ToList();

        public void ExportEvents(Person p, DateTime date, string fileName)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(ListEvents(p, date), Formatting.Indented));
        }
    }
}
