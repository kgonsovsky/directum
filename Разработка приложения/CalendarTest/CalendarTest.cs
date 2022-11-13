using Calendar;
using Calendar.Bl;
using Calendar.Model;
using Calendar.Service;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace CalendarTest
{
    [TestClass]
    public class CalendarTest
    {
        private static TestSuite TestSuite()
        {
            var services = Program.CreateHostBuilder(null).Build().Services;
            return new TestSuite()
            {
                EventSvc = services.GetRequiredService<EventService>(),
                PersonSvc = services.GetRequiredService<PersonService>(),
                NoticeSvc = services.GetRequiredService<NoticeService>(),
                Now = DateTime.Now
            };
        }

        [TestMethod]
        public void EventAddition()
        {
            var a = TestSuite();
            a.PersonSvc.Add("Me");
            a.PersonSvc.Add("Him");
            a.EventSvc.Add(new Event()
            {
                Name = "Dayly", 
                Participants = a.PersonSvc.All,
                Start = a.Now.AddMinutes(30), 
                Duration = 60,
                Reminder = 35
            });
            a.NoticeSvc.Process();
            var results = a.NoticeSvc.All;
            Assert.IsTrue(
                results.Count == 2
                && results.Any(a=> a.Participant.Name=="Me" )
                && results.Any(a => a.Participant.Name == "Him")
                );
        }

        [TestMethod]
        public void EventIntersection()
        {
            try
            {
                var a = TestSuite();
                a.PersonSvc.Add("Me");
                a.EventSvc.Add(new Event()
                {
                    Name = "Dayly",
                    Participants = a.PersonSvc.All,
                    Start = a.Now.AddMinutes(30),
                    Duration = 60,
                    Reminder = 15
                });
                a.EventSvc.Add(new Event()
                {
                    Name = "Dayly",
                    Participants = a.PersonSvc.All,
                    Start = a.Now.AddMinutes(35),
                    Duration = 60,
                    Reminder = 15
                });
                a.NoticeSvc.Process();
                Assert.IsFalse(true);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
            }
        }

        [TestMethod]
        public void ReminderChange()
        {
            var a = TestSuite();
            a.PersonSvc.Add("Me");
            a.EventSvc.Add(new Event()
            {
                Name = "Dayly",
                Participants = a.PersonSvc.All,
                Start = a.Now.AddMinutes(30),
                Duration = 60,
                Reminder = 25
            });
            a.NoticeSvc.Process();
            var results = a.NoticeSvc.All;
            Assert.IsTrue(results.Count ==0);
            var ev = a.EventSvc.All.First();
            a.EventSvc.Modify(ev, new EventModify(){Reminder = 45});
            a.NoticeSvc.Process();
            results = a.NoticeSvc.All;
            Assert.IsTrue(results.Count==1);
        }

        [TestMethod]
        public void ExportCalendar()
        {
            var a = TestSuite();
            var me = a.PersonSvc.Add("Me"); 
            var day = a.Now.AddMinutes(30);
            a.EventSvc.Add(new Event()
            {
                Name = "Dayly",
                Participants = a.PersonSvc.All,
                Start = day,
                Duration = 60,
                Reminder = 25
            });
            a.NoticeSvc.Process();
            a.PersonSvc.ExportEvents(me, day, "test.xml");
            var exported = a.PersonSvc.ListEvents(me, day);
            var imported = JsonConvert.DeserializeObject<List<Event>>(System.IO.File.ReadAllText("test.xml"));
            try
            {
                var yes = exported.First().Participants.First().Equals(imported.First().Participants.First());
                Assert.IsTrue(yes);
            }
            catch (Exception e)
            {
                Assert.IsTrue(false,e.Message);
            }
        }
    }
}