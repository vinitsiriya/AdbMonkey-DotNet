using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vrocky.AdbMonkey
{
    public class InputEvent
    {
        String eventname;
        String shellpath;
        public InputEvent(String eventname)
        {
            shellpath = "/dev/input/" + eventname;

        }
        public InputEvent(int eventnumber)
        {
            shellpath = "/dev/input/event" +eventnumber;
        }


        public String getShellPath()
        {
            return shellpath;
        }
    }
}
