using Calendar.Bl;
using Calendar.Model;
using Microsoft.Extensions.Logging;

namespace Calendar.Service
{
    public class NoticeService 
    {
        private readonly ILogger<NoticeService> _logger;
        
        private readonly EventService _eventService;

        private readonly Storage _storage;

        public NoticeService(ILogger<NoticeService> logger, EventService eventService, Storage storage)
        {
            _logger = logger;
            _eventService = eventService;
            _storage = storage;
        }

        public void Process()
        {
            var now = DateTime.Now;
            var upComingEvents = _eventService.All.Where(ev => ev.HasRemind(now)).ToList();
            var newNotices = upComingEvents
                .SelectMany(ev => ev.Participants, (ev, pa) => new Notice() { Event = ev, Participant = pa })
                .Where(a => !_storage.Notice.Any(notice =>
                    notice.Event.Id == a.Event.Id && notice.Participant.Id == a.Participant.Id)).ToList();
            newNotices.ForEach(notice =>
            {
                _storage.Notice.Add(notice);
                _logger.LogInformation($" Notice about event {notice.Event.Name} for person {notice.Participant.Name}");
            });
            _storage.Notice.RemoveAll(notice => notice.Event.HasOutOfDate(now));
        }

        public List<Notice> All => _storage.Notice;
    }
}
