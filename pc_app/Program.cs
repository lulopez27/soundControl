using System;
using System.Diagnostics;
using System.Collections.Generic;
namespace pc_app
{
    class Program
    {
        static void Main (string[] args)
        {
            AudioUtilities.SetMasterVolume(75f);
            System.Console.WriteLine($"This is system audio {AudioUtilities.GetMasterVolume()}" );
            System.Threading.Thread.Sleep(5000);
            AudioUtilities.SetMasterVolume(50f);
            System.Console.WriteLine($"This is system audio {AudioUtilities.GetMasterVolume()}" );
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Friendly names:");
            List<AudioDevice> soundDevices = new List<AudioDevice>();
            foreach (AudioDevice device in AudioUtilities.GetAllDevices())
            {
                Console.WriteLine(device.FriendlyName);
                soundDevices.Add(device);
            }

            // dump all audio sessions
            List<Process> audioSess = new List<Process>();
            Console.WriteLine("Process names:");
            foreach (AudioSession session in AudioUtilities.GetAllSessions())
            {
                if (session.Process != null)
                {
                    // only the one associated with a defined process
                    audioSess.Add(session.Process);
                }
            }
            AudioUtilities.SetApplicationVolume(audioSess[0].Id,50);
            System.Threading.Thread.Sleep(5000);
            AudioUtilities.SetApplicationVolume(audioSess[0].Id,100);
        }
    }
}