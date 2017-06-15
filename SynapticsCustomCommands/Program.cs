using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SYNCOMLib;
using SYNCTRLLib;

namespace SynapticsCustomCommands
{

    class Program
    {
        static SynAPICtrl api = new SynAPICtrl();
        static SynDeviceCtrl device = new SynDeviceCtrl();
        static SynPacketCtrl packet = new SynPacketCtrl();
        static int deviceHandle;
        static int counter;
        static int moveCounter;

        static void Main(string[] args)
        {
            api.Initialize();
            api.Activate();
            //select the first device found
            deviceHandle = api.FindDevice(SynConnectionType.SE_ConnectionAny, SynDeviceType.SE_DeviceTouchPad, -1);
            device.Select(deviceHandle);
            device.Activate();
            device.OnPacket += SynTP_Dev_OnPacket;
            Console.ReadLine();
        }

        static private void SynTP_Dev_OnPacket()
        {
            var result = device.LoadPacket(packet);

            SynFingerFlags fingerState;
            SynMultiFingerGestureFlags multiFingerGestureState = SynMultiFingerGestureFlags.SF_UnacquireAllGestures;

            // if (Enum.TryParse(packet.FingerState.ToString(), out fingerState))
            // {
            //     if (fingerState.HasFlag(SynFingerFlags.SF_FingerTap3))
            //     {
            //         Console.WriteLine($"You tapped with 3 fingers and moved");
            //     }
            // }
            Console.WriteLine("FingerState: " + packet.FingerState + ", ExtendedState: " + packet.ExtendedState);
            //doFingerState(multiFingerGestureState);
            doExtendedState(multiFingerGestureState);
            //doExtendedState2(multiFingerGestureState);
        }
        static private void doFingerState(SynMultiFingerGestureFlags multiFingerGestureState)
        {
            if (Enum.TryParse(packet.FingerState.ToString(), out multiFingerGestureState))
            {
                if (multiFingerGestureState.HasFlag(SynMultiFingerGestureFlags.SF_ThreeFingerHorizontalFlick))
                {
                    Console.WriteLine("From DoFingerState: A three finger horizontal flick has been detected");
                }
                if (multiFingerGestureState.HasFlag(SynMultiFingerGestureFlags.SF_FourFingerFlick))
                {
                    Console.WriteLine("From DoFingerState: A four finger horizontal flick has been detected");
                }
                if (multiFingerGestureState.HasFlag(SynMultiFingerGestureFlags.SF_FourFingerScrolling))
                {
                    Console.WriteLine("From DoFingerState: A four finger scrolling has been detected");
                }
                if (multiFingerGestureState.HasFlag(SynMultiFingerGestureFlags.SF_FourFingerTap))
                {
                    Console.WriteLine("From DoFingerState: A four finger tap has been detected");
                }
                if (multiFingerGestureState.HasFlag(SynMultiFingerGestureFlags.SF_FourFingerFlick))
                {
                    Console.WriteLine("From DoFingerState: A four finger horizontal flick has been detected");
                }
                if (multiFingerGestureState.HasFlag(SynMultiFingerGestureFlags.SF_ThreeFingerFlick))
                {
                    Console.WriteLine("From DoFingerState: A three finger flick has been detected");
                }
                if (multiFingerGestureState.HasFlag(SynMultiFingerGestureFlags.SF_ThreeFingerVerticalFlick))
                {
                    Console.WriteLine("From DoFingerState: A three finger vertical flick has been detected");
                }
            }
        }
        static private void doExtendedState2(SynMultiFingerGestureFlags multiFingerGestureState)
        {
            if (Enum.TryParse(packet.ExtendedState2.ToString(), out multiFingerGestureState))
            {
                if (multiFingerGestureState.HasFlag(SynMultiFingerGestureFlags.SF_ThreeFingerHorizontalFlick | SynMultiFingerGestureFlags.SF_ThreeFingerFlick))
                {
                    Console.WriteLine("From DoExtendedState2: A three finger horizontal flick has been detected");
                }
                if (multiFingerGestureState.HasFlag(SynMultiFingerGestureFlags.SF_FourFingerFlick))
                {
                    Console.WriteLine("From DoExtendedState2: A four finger horizontal flick has been detected");
                }
                if (multiFingerGestureState.HasFlag(SynMultiFingerGestureFlags.SF_FourFingerScrolling))
                {
                    Console.WriteLine("From DoExtendedState2: A four finger scrolling has been detected");
                }
                if (multiFingerGestureState.HasFlag(SynMultiFingerGestureFlags.SF_FourFingerTap))
                {
                    Console.WriteLine("From DoExtendedState2: A four finger tap has been detected");
                }
                if (multiFingerGestureState.HasFlag(SynMultiFingerGestureFlags.SF_FourFingerFlick))
                {
                    Console.WriteLine("From DoExtendedState2: A four finger horizontal flick has been detected");
                }
                if (multiFingerGestureState.HasFlag(SynMultiFingerGestureFlags.SF_ThreeFingerFlick))
                {
                    Console.WriteLine("From DoExtendedState2: A three finger flick has been detected");
                }
                if (multiFingerGestureState.HasFlag(SynMultiFingerGestureFlags.SF_ThreeFingerVerticalFlick))
                {
                    Console.WriteLine("From DoExtendedState2: A three finger vertical flick has been detected");
                }
            }
        }
        static private void doExtendedState(SynMultiFingerGestureFlags multiFingerGestureState)
        {
            if (Enum.TryParse(packet.ExtendedState.ToString(), out multiFingerGestureState))
            {
                if (multiFingerGestureState.HasFlag(SynMultiFingerGestureFlags.SF_ThreeFingerHorizontalFlick))
                {
                    Console.WriteLine("From DoExtendedState: A three finger horizontal flick has been detected");
                }
                if (multiFingerGestureState.HasFlag(SynMultiFingerGestureFlags.SF_FourFingerFlick))
                {
                    Console.WriteLine("From DoExtendedState: A four finger horizontal flick has been detected");
                }
                //if (multiFingerGestureState.HasFlag(SynMultiFingerGestureFlags.SF_FourFingerScrolling))
                //{
                //    Console.WriteLine("From DoExtendedState: A four finger scrolling has been detected");
                //}
                if (multiFingerGestureState.HasFlag(SynMultiFingerGestureFlags.SF_FourFingerTap))
                {
                    Console.WriteLine("From DoExtendedState: A four finger tap has been detected");
                }
                if (multiFingerGestureState.HasFlag(SynMultiFingerGestureFlags.SF_FourFingerFlick))
                {
                    Console.WriteLine("From DoExtendedState: A four finger horizontal flick has been detected");
                }
                if (multiFingerGestureState.HasFlag(SynMultiFingerGestureFlags.SF_ThreeFingerFlick))
                {
                    Console.WriteLine("From DoExtendedState: A three finger flick has been detected");
                }
                if (multiFingerGestureState.HasFlag(SynMultiFingerGestureFlags.SF_ThreeFingerVerticalFlick))
                {
                    Console.WriteLine("From DoExtendedState: A three finger vertical flick has been detected");
                }
            }
        }
    }

}
