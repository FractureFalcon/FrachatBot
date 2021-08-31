using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrachatBot
{
    public static class ControlExtensions
    {
        public static void InvokeWithRequiredCheck(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action.Invoke();
            }
        }
    }
}
