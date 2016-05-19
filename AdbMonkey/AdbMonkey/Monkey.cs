using SharpAdbClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vrocky.AdbMonkey
{
  public class Monkey
    {

        DeviceData device;

        ConsoleOutputReceiver receiver;

        InputEvent inputEvent;
        public Monkey(DeviceData deviceData,InputEvent inputEvent)
        {
            this.device = deviceData;
            this.inputEvent = inputEvent;
            receiver = new ConsoleOutputReceiver();
   
        }

        public void Down(UInt32 x, UInt32 y)
        {
            List<UInt32[]> aas = new List<UInt32[]>();

            aas.Add(new UInt32[] { KeyCodes.EV_KEY, KeyCodes.BTN_TOUCH, KeyCodes.DOWN });
            aas.Add(new UInt32[] { KeyCodes.EV_ABS, KeyCodes.ABS_MT_PRESSURE, 1 });
            aas.Add(new UInt32[] { KeyCodes.EV_ABS, KeyCodes.ABS_MT_POSITION_X, x });
            aas.Add(new UInt32[] { KeyCodes.EV_ABS, KeyCodes.ABS_MT_POSITION_Y, y });
            aas.Add(new UInt32[] { KeyCodes.EV_SYN, KeyCodes.SYN_MT_REPORT, 0 });
            aas.Add(new UInt32[] { KeyCodes.EV_SYN, KeyCodes.SYN_REPORT, 0 });
            executeCommand(aas);
        }

        public void SetXY(UInt32 x, UInt32 y)
        {
            List<UInt32[]> aas = new List<UInt32[]>();
            aas.Add(new UInt32[] { KeyCodes.EV_ABS, KeyCodes.ABS_MT_POSITION_X, x });
            aas.Add(new UInt32[] { KeyCodes.EV_ABS, KeyCodes.ABS_MT_POSITION_Y, y });
            aas.Add(new UInt32[] { KeyCodes.EV_SYN, KeyCodes.SYN_MT_REPORT, 0 });
            aas.Add(new UInt32[] { KeyCodes.EV_SYN, KeyCodes.SYN_REPORT, 0 });
            executeCommand(aas);

        }

        public void Up()
        {
            List<UInt32[]> aas = new List<UInt32[]>();
            aas.Add(new UInt32[] { KeyCodes.EV_KEY, KeyCodes.BTN_TOUCH, KeyCodes.UP });
            aas.Add(new UInt32[] { KeyCodes.EV_SYN, KeyCodes.SYN_MT_REPORT, 0 });
            aas.Add(new UInt32[] { KeyCodes.EV_SYN, KeyCodes.SYN_REPORT, 0 });
            executeCommand(aas);
        }

        private void executeCommand(List<UInt32[]> cmds)
        {
            AdbClient.Instance.ExecuteRemoteCommand(getCommand(cmds), device, receiver);
        }


        private String getCommand(List<UInt32[]> aas)
        {
            String command = "";
            foreach (UInt32[] uints in aas)
            {
                command += "sendevent "+ inputEvent.getShellPath() + " " + uints[0] + " " + uints[1] + " " + uints[2] + ";";

            }
            return command;
        }
    }
}
