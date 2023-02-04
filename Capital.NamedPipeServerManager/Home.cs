using Capital.Core.Model;
using Capital.NamedPipeServer.Classes;
using Capital.NamedPipeServer.Extentions;
using Capital.NamedPipeServerManager.Properties;
using Newtonsoft.Json;
using System.Media;
using System.Text.RegularExpressions;

namespace Capital.NamedPipeServer
{
    public partial class Home : Form
    {
        private readonly PipesManager _manager;
        private readonly MessageSender _sender;

        public Home(PipesManager manager, MessageSender sender)
        {
            InitializeComponent();
            _manager = manager;
            _sender = sender;
        }

        private void txtPipeName_TextChanged(object sender, EventArgs e)
        {
            if (!_manager.Exists(txtPipeName.Text) && Regex.IsMatch(txtPipeName.Text, _manager.PipeNamePattern))
                ValidName();
            else
                InvalidName();
        }

        private void ValidName()
        {
            picValidation.Image = Resources._checked;
            btnStart.Enabled = true;
        }

        private void InvalidName()
        {
            picValidation.Image = Resources._cross;
            btnStart.Enabled = false;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            //var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => FilterTypes(t));

            //cmbAction.DataSource = types.Select(t => t.Name).ToList();
            //cmbAction.SelectedItem = types.FirstOrDefault();
        }

        private static bool FilterTypes(Type t)
            => t.IsClass && t.IsAssignableTo(typeof(IMessageHandler));

        private void btnStart_Click(object sender, EventArgs e)
            => Task.Run(() => CreatePipe(txtPipeName.Text, chkRestart.Checked));

        private async Task CreatePipe(string name, bool restartOnDisconnect)
        {
            var pipe = await _manager.CreatePipe(name, restartOnDisconnect);
            pipe.OnMessageRecived += ProcessMessage;
            await pipe.StartAsync();
        }

        private void ProcessMessage(object sender, string message)
        {
            var tick = JsonConvert.DeserializeObject<MqlTick>(message);
            //SystemSounds.Beep.Play();
            _sender.Publish(tick!);
        }

        //private void RefreshGrid(object sender, string message) => RefreshGrid();

        private void RefreshGrid()
        {
            var entries = _manager.Pipes.OrderBy(k => k.Value.Index).Select(k => k.Key).ToList();
            dgrdCurrent.Rows.Clear();
            foreach (var entry in entries)
            {
                PipeContainer container = _manager.Pipes[entry];
                dgrdCurrent.Rows.Add(container.Index, entry, container.Status);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshGrid();
        }
    }
}