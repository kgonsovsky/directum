using System.Collections;
using Microsoft.VisualBasic;

namespace MeetingCard
{
    public partial class MeetingForm : Form
    {
        private List<Participant> _internalParticipants;
        private MeetingCard _card;

        public MeetingForm()
        {
            _internalParticipants = new List<Participant>()
            {
                new Participant() { IsExternal = false, Name = "Директор" },
                new Participant() { IsExternal = false, Name = "Бухгалтер" },
                new Participant() { IsExternal = false, Name = "Главный инженер" },
                new Participant() { IsExternal = false, Name = "Секретарь" },
            };
            _card = new MeetingCard()
            {
                Coordinated = false, Organized = false, Protocoled = false,
                Title = "О мерах по борьбе...",Text="Провести...",
                Date = DateTime.Now, Protocol = "Утверждаю, ",
                Participants = _internalParticipants.Take(3).ToList()
             
            };
            InitializeComponent();
        }

        private void Sync(Action a)
        {
            a();
            Display();
        }

        private void MeetingForm_Load(object sender, EventArgs e)
        {
            tab.SelectedTab = tabOrganize;
            ClientSize = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            BindingSource source = new BindingSource();
            source.DataSource = _card.Participants;
            gridParticipant.DataSource = source;
            gridCoordinate.DataSource = source;
            gridParticipant.ReadOnly = false;
            this.ActiveControl = inputName;
            gridParticipant.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridCoordinate.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridParticipant.Columns[2].Visible = false;
            gridCoordinate.Columns[1].Visible = false;
            _internalParticipants.ForEach(a =>
            {
                var b = new ToolStripButton(a.Name);
                b.Tag = a;
                b.Click += btnAddParticipant_Click;
                btnAddPariticipant.DropDownItems.Add(b);
            });
            tabProtocol.Enabled = false;
            this.tabСoordinate.Enabled = false;
            Display();
        }

        private void Display()
        {
            statusName.Text = _card.Title;
            btnOrganize.Enabled = !_card.Organized;
            btnProtocol.Enabled = _card.Organized && !_card.Protocoled;
            btnCoordinate.Enabled = _card.Organized && _card.Protocoled && !_card.Coordinated;
            if (!_card.Organized && !_card.Protocoled && !_card.Coordinated)
                statusState.Text = "[На организации]";
            else if (_card.Organized && !_card.Protocoled && !_card.Coordinated)
                statusState.Text = "[На проведении]";
            else if (_card.Organized && _card.Protocoled && !_card.Coordinated)
                statusState.Text = "[На cогласовнии]";
            else
                statusState.Text = "[Утверждено]";
            statusDate.Text = _card.Date.ToShortDateString();
            inputText.Text = _card.Text;
            inputName.Text = _card.Title;
            inputDate.Text = _card.Date.ToShortDateString();
            textProtocol.Text = _card.Protocol;
        }

        private void btnOrganize_Click(object sender, EventArgs e)
        {
            Sync( () => _card.Organized = true);
            tabProtocol.Enabled = true;
            tab.SelectedTab = tabProtocol;
            this.ActiveControl = textProtocol;
        }

        private void btnProtocol_Click(object sender, EventArgs e)
        {
            Sync(() => _card.Protocoled = true);
            tabСoordinate.Enabled = true;
            tab.SelectedTab = tabСoordinate;
        }

        private void btnCoordinate_Click(object sender, EventArgs e)
        {
            if (_card.Participants.Any(a => a.IsSigned == false))
            {
                MessageBox.Show("Не все подставили подпись");
                return;
            }

            Sync(() => _card.Coordinated = true);
        }

        private void inputText_TextChanged(object sender, EventArgs e)
        {
            Sync(() => _card.Text = (sender as TextBox).Text);
        }

        private void inputName_TextChanged(object sender, EventArgs e)
        {
            Sync(() => _card.Title = (sender as TextBox).Text);
        }

        private void inputDate_ValueChanged(object sender, EventArgs e)
        {
            Sync(() => _card.Date = (sender as DateTimePicker).Value);
        }

        private void btnDelParticipant_Click(object sender, EventArgs e)
        {
            if (gridParticipant.CurrentRow == null)
                return;
            if (gridParticipant.CurrentRow.Index >= (gridParticipant.DataSource as IList).Count)
                return;
            if (gridParticipant.CurrentRow.Index <0)
                return;
            (gridParticipant.DataSource as IList)
                .RemoveAt(gridParticipant.CurrentRow.Index);
        }

        private void btnAddExternalParticipant_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Prompt", "Title");
            if (!string.IsNullOrEmpty(input))
            {
                (gridParticipant.DataSource as IList).Add(new Participant() { IsExternal = true, Name = input });
            }
        }

        private void btnAddParticipant_Click(object sender, EventArgs e)
        {
            (gridParticipant.DataSource as IList).Add(((sender as ToolStripButton).Tag as Participant));
        }

        private void textProtocol_TextChanged(object sender, EventArgs e)
        {
            Sync(() => _card.Protocol = (sender as TextBox).Text);
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (gridCoordinate.CurrentRow == null)
                return;
            if (gridCoordinate.CurrentRow.Index >= (gridCoordinate.DataSource as IList).Count)
                return;
            if (gridCoordinate.CurrentRow.Index < 0)
                return;
            ((gridCoordinate.DataSource as IList)[gridCoordinate.CurrentRow.Index] as Participant).IsSigned = true;
            (gridCoordinate.DataSource as BindingSource).ResetBindings(false);
        }

        private void btnUnsign_Click(object sender, EventArgs e)
        {
            if (gridCoordinate.CurrentRow == null)
                return;
            if (gridCoordinate.CurrentRow.Index >= (gridCoordinate.DataSource as IList).Count)
                return;
            if (gridCoordinate.CurrentRow.Index < 0)
                return;
            ((gridCoordinate.DataSource as IList)[gridCoordinate.CurrentRow.Index] as Participant).IsSigned = false;
            (gridCoordinate.DataSource as BindingSource).ResetBindings(false);
        }
    }
}