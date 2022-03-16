using System;
using System.Collections.Generic;
using System.Management;

namespace DWC_VoiceAssistent.handler.projects.systeminformation.hardware
{
    class USB
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        /// <summary>
        /// Show the pluged in USB Sticks and there Information
        /// </summary>
        public static void Usb()
        {
            List<USB> devices = new List<USB>();

            ManagementObjectCollection collection;
            var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub");
            collection = searcher.Get();

            foreach (var device in collection)
            {

                Console.WriteLine((string)device.GetPropertyValue("DeviceID"));
                Console.WriteLine((string)device.GetPropertyValue("PNPDeviceID"));
                Console.WriteLine((string)device.GetPropertyValue("Description"));

            }

            collection.Dispose();

            //await _programmator.SendRandomMessage();
        }

    }
}
