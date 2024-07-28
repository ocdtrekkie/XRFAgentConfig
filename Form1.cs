using SQLite;
using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using System.ServiceProcess;

namespace XRFAgentConfig
{
    public partial class Form1 : Form
    {
        SQLiteConnection conn;

        private void OpenConfigTable()
        {
            conn = new SQLiteConnection(Database_FileURI.Text);
            conn.CreateTable<Config>();
            Sync_ServerURL.Text = GetConfig("Sync_ServerURL");
            Sync_SandstormToken.Text = GetConfig("Sync_SandstormToken");
            Sync_AccessKey.Text = GetConfig("Sync_AccessKey");
        }

        private string CheckInstall()
        {
            if (File.Exists(@"C:\Program Files\XRFAgent\XRFAgent.exe"))
            {
                InstallBtn.Visible = false;
                lblServiceStatus.Text = "Agent Service: " + CheckService();
                return "Agent present";
            }
            else
            {
                InstallBtn.Visible = true;
                lblServiceStatus.Text = "Agent Service: Not installed";
                return "Agent not present";
            }
        }

        private string CheckService()
        {
            try
            {
                ServiceController scAgent = new ServiceController("XRFAgent");
                string status;
                switch (scAgent.Status)
                {
                    case ServiceControllerStatus.Running:
                        status = "Running"; break;
                    case ServiceControllerStatus.Stopped:
                        status = "Stopped"; break;
                    case ServiceControllerStatus.Paused:
                        status = "Paused"; break;
                    case ServiceControllerStatus.StopPending:
                        status = "Stopping"; break;
                    case ServiceControllerStatus.StartPending:
                        status = "Starting"; break;
                    default:
                        status = "Status Changing"; break;
                }
                switch (scAgent.StartType)
                {
                    case ServiceStartMode.Automatic:
                        status = status + " (Automatic)"; break;
                    case ServiceStartMode.Disabled:
                        status = status + " (Disabled)"; break;
                    case ServiceStartMode.Manual:
                        status = status + " (Manual)"; break;
                    default:
                        status = status + " (Unknown)"; break;
                }
                return status;
            }
            catch (InvalidOperationException)
            {
                return "Not installed";
            }
        }

        [Table("CONFIG")]
        public class Config
        {
            [PrimaryKey, MaxLength(100)]
            public string Key { get; set; }

            public string Value { get; set; }
        }

        public int AddConfig(Config config)
        {
            int result = conn.Insert(config);
            return result;
        }

        public int UpdateConfig(Config config)
        {
            int result = 0;
            result = conn.Update(config);
            return result;
        }

        public int AddOrUpdateConfig(Config config)
        {
            int result = UpdateConfig(config);
            if (result == 0)
            {
                result = AddConfig(config);
            }
            return result;
        }

        public string GetConfig(string key)
        {
            var Value = from c in conn.Table<Config>()
                        where c.Key == key
                        select c.Value;
            return Value.FirstOrDefault();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(@"C:\HAC");
            OpenConfigTable();

            Bitmap shieldIcon = new Bitmap(System.Drawing.SystemIcons.Shield.ToBitmap(), new Size(14,14));
            InstallBtn.Image = shieldIcon;
            InstallBtn.ImageAlign = ContentAlignment.MiddleLeft;
            InstallBtn.TextImageRelation = TextImageRelation.ImageBeforeText;

            CheckInstall();
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Dispose();
            OpenConfigTable();
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            AddOrUpdateConfig(new Config { Key = "Sync_ServerURL", Value = Sync_ServerURL.Text });
            AddOrUpdateConfig(new Config { Key = "Sync_SandstormToken", Value = Sync_SandstormToken.Text });
            AddOrUpdateConfig(new Config { Key = "Sync_AccessKey", Value = Sync_AccessKey.Text });

            // The config tool will send a single heartbeat to confirm the Sandstorm offer template
            HttpClient heartbeatClient = new();
            HttpRequestMessage heartbeatMessage = new(HttpMethod.Post, Sync_ServerURL.Text + "?message_type=heartbeat&destination=server&access_key=" + Sync_AccessKey.Text + "&message=none&user_agent=XRFAgentConfig/1.0.0");
            string EncodedCreds = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes("sandstorm:" + Sync_SandstormToken.Text));
            heartbeatMessage.Headers.Add("Authorization", "Basic " + EncodedCreds);
            HttpResponseMessage heartbeatResponse = await heartbeatClient.SendAsync(heartbeatMessage);

            MessageBox.Show("Saved", "Configuration values have been saved", MessageBoxButtons.OK);
        }

        private void InstallBtn_Click(object sender, EventArgs e)
        {
            WebClient UpdateDownloadClient = new WebClient();
            int latestVersion = -1;
            try
            {
                try
                {
                    Directory.Delete(@"C:\HAC\scripts\agenttemp", true);
                }
                catch (DirectoryNotFoundException)
                {
                    // this is fine
                }
                Directory.CreateDirectory(@"C:\HAC\scripts\agenttemp");
                latestVersion = int.Parse(UpdateDownloadClient.DownloadString("https://hac.jacobweisz.com/dl/currentagent.txt"));
                string agentFile = "agent" + latestVersion + ".zip";
                UpdateDownloadClient.DownloadFile("https://hac.jacobweisz.com/dl/" + agentFile, @"C:\HAC\scripts\" + agentFile);
                ZipFile.ExtractToDirectory(@"C:\HAC\scripts\" + agentFile, @"C:\HAC\scripts\agenttemp");
                File.Delete(@"C:\HAC\scripts\" + agentFile);
                Process Installer = new Process();
                Installer.StartInfo.UseShellExecute = true;
                Installer.StartInfo.Verb = "runas";
                Installer.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Installer.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "agentinstall.bat";
                Installer.Start();
                Thread.Sleep(2000);
                CheckInstall();
                Thread.Sleep(2000);
                CheckInstall();
                Thread.Sleep(2000);
                CheckInstall();
                Thread.Sleep(2000);
                CheckInstall();
                Thread.Sleep(2000);
                CheckInstall();
            }
            catch (Exception err)
            {
                // handle this somehow
            }
        }
    }
}
