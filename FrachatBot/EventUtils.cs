using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrachatBot
{
    class EventUtils
    {
        public static async void CopyTextToClipboard(object sender, EventArgs e)
        {
            if (sender.GetType().Equals(typeof(TextBox)))
            {
                TextBox senderTextBox = sender as TextBox;

                senderTextBox.BackColor = SystemColors.InactiveCaption;

                RunActionOnSTAThread(
                    () => Clipboard.SetText(senderTextBox.Text),
                    () =>
                    {
                        senderTextBox.ForeColor = SystemColors.GrayText;
                        senderTextBox.BackColor = SystemColors.ButtonShadow;
                    });
            }
        }

        public static async Task RunActionOnSTAThread(Action action, Action onCompletion = null)
        {
            Thread staThread = new Thread(new ThreadStart(action));
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.IsBackground = true;
            staThread.Start();
            while (staThread.ThreadState != ThreadState.Stopped)
            {
                await Task.Delay(100);
            }
            onCompletion.Invoke();
        }

        public static void SendEventHandlerEventSafe(EventHandler eventType, object sender, EventArgs args)
        {
            EventHandler eventToSend = eventType;
            eventToSend?.Invoke(sender, args);
        }
    }
}
