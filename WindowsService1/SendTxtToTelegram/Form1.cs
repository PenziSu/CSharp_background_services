using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetTelegramBotApi;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi.Types;

namespace SendTxtToTelegram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string accessToken = "239286896:AAHslOboDCVFX0NARtR_qyeBsbN9OmWtg8M";
            int markId = 237116041;
            var bot = new TelegramBot(accessToken);
            
            
            var reqAction = new SendMessage(markId, MsgTo.Text);
            var sendPhoto = new SendPhoto(markId, new FileToSend(MsgTo.Text));
            var sendSticker = new SendSticker(markId, new FileToSend(MsgTo.Text));

            bot.MakeRequestAsync(sendSticker).Wait();
            
            /*
            var me = await bot.MakeRequestAsync(new GetMe());
            if (me == null)
            {
                MessageBox.Show("GetMe() FAILED. Do you forget to add your AccessToken to App.config?");
            }
            FirstName.Text = "Me FirstName->" + me.FirstName;
            UserName.Text = "Me UserName->" + me.Username;
            long offset = 0;
            var updates = bot.MakeRequestAsync(new GetUpdates() { Offset = offset }).Result;
            if (updates != null)
            {
                foreach(var update in updates)
                {
                    offset = update.UpdateId + 1;
                    if (update.Message == null)
                    {
                        continue;
                    }

                    var from = update.Message.From;
                    var text = update.Message.Text;
                    var photos = update.Message.Photo;

                    MsgFrom.Text = "msg from " + from.Id;
                }
                                
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User-Agent
            Cookies
            Session
            ProxyIP

            
        }
    }
}
