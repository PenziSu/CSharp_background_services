using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramSample.Events;

namespace TelegramSample
{
    interface ICrawler
    {
        event EventHandler<OnStartEventArgs> OnStart;

        event EventHandler<OnCompletedEventArgs> OnCompleted;

        event EventHandler<OnErrorEventArgs> OnError;

        Task<string> Start(Uri uri, string proxy);
    }
}
