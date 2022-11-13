using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCard
{
    public class MeetingCard
    {
        public bool Organized { get; set; }

        public bool Protocoled { get; set; }

        public bool Coordinated { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string Protocol { get; set; }

        public DateTime Date { get; set; }

        public List<Participant> Participants { get; set; }


    }

    public class Participant
    {
        [DisplayName("Имя")]
        public string Name { get; set; }

        [DisplayName("Внешний")]
        public bool IsExternal { get; set; }

        [DisplayName("Подписан")]
        public bool IsSigned { get; set; }
    }
}
