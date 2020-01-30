using EventService.Interfaces;
using System;

namespace EventService
{
    public class DisplayInfoService : IDisplayInfoService
    {
        public void ListDisplayInfo(string[] arrDisplay)
        {
            foreach (string item in arrDisplay)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public void DisplayMessage(string cMessage)
        {
            Console.WriteLine(cMessage);
            Console.ReadLine();
        }
    }
}
