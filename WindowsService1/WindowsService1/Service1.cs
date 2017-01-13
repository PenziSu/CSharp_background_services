using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        private Timer MyTimer;
        public Service1()
        {
            InitializeComponent();
            this.AutoLog = false;
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource("MySource", "MyLog");
            }
            eventLog1.Source = "MySource";
        }        
        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("Start Say Hello Timer");
            MyTimer = new Timer();
            MyTimer.Elapsed += new ElapsedEventHandler(MyTimer_Elapsed);
            MyTimer.Interval = 10 * 1000;
            MyTimer.Start();
        }
        private void MyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            eventLog1.WriteEntry("Say Hello Timer Ticked.");
            System.Windows.Forms.MessageBox.Show("Hello Dude");
        }
        protected override void OnStop()
        {
            eventLog1.WriteEntry("Stop Say Hello Timer.");
            MyTimer.Stop();
            MyTimer = null;
        }
    }
}