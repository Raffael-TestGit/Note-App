using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_App.Events
{
    public class EventClass
    {
        static public event EventHandler? HasBeenPushed;

        static public void RaiseEvent(EventArgs e)
        {
            HasBeenPushed?.Invoke(null, e);
        }
    }
}
