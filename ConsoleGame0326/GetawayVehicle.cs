using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame0326
{
    public class GetawayVehicle
    {
        public enum vehicleParts { empty, tire, engine, transmission }

        public void FindParts(Rooms room, Character1 character)
        {
                Console.WriteLine($"You have found a {Convert.ToString(room.vehiclePart)}");
                character.parts++;
                room.vehiclePart = vehicleParts.empty;
        }
        public void Escape()
        {
            Console.WriteLine("\nYou have found a vehicle! But it is missing several parts.\n" +
                "Go back through the buildings to find the needed parts and escape this dump.");
        }

        public void Victory()
        {

            Console.WriteLine("\n\n\nCongrats, you have found all the parts!!!!" +
                "\nPress Enter to repair the vehicle...");
            Console.ReadLine();
            Console.WriteLine("YOU HAVE ESCAPED THE DUNGEON!!! \nPress Enter to exit.");
            Console.ReadLine();
            Console.Clear();
            Environment.Exit(1);
        }
    }
}
