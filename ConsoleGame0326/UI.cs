using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleGame0326.Character1;
using static ConsoleGame0326.GetawayVehicle;

namespace ConsoleGame0326
{
    public class UI
    {
        public void Run()
        {
            Console.WriteLine("Welcome to the Dungeon, we have fun and games...");
            Console.WriteLine("\nPlease enter the player's name. ");
            Character1 character = new Character1() { };
            character.name = Console.ReadLine();
            Console.WriteLine($"\nHello, {character.name}.");

            Rooms B1RA = new Rooms() { };
            Rooms B1RB = new Rooms() { };
            Rooms B1RC = new Rooms() { };
            Rooms B1RD = new Rooms() { };
            Rooms B1RE = new Rooms() { };
            Rooms B2RA = new Rooms() { };
            Rooms B2RB = new Rooms() { };
            Rooms B2RC = new Rooms() { };
            Rooms B2RD = new Rooms() { };
            Rooms B3RA = new Rooms() { };
            B1RA.Room("Room A", 1, null, B1RD, B1RC, B1RB, weapons.empty, vehicleParts.tire, Boss.empty);
            B1RB.Room("Room B", 1, null, B1RE, B1RA, null, weapons.sword, vehicleParts.empty, Boss.empty);
            B1RC.Room("Room C", 1, null, null, null, B1RA, weapons.shield, vehicleParts.tire, Boss.empty);
            B1RD.Room("Room D", 1, B1RA, B2RA, null, B1RE, weapons.empty, vehicleParts.tire, Boss.B1RD);
            B1RE.Room("Room E", 1, B1RB, null, B1RD, null, weapons.empty, vehicleParts.empty, Boss.empty);
            B2RA.Room("Room A", 2, null, B2RC, B3RA, B2RB, weapons.empty, vehicleParts.tire, Boss.empty);
            B2RB.Room("Room B", 2, null, B2RD, B2RA, null, weapons.ammo, vehicleParts.empty, Boss.empty);
            B2RC.Room("Room C", 2, B2RA, null, null, B2RD, weapons.gun, vehicleParts.engine, Boss.empty);
            B2RD.Room("Room D", 2, B2RB, null, B2RC, null, weapons.empty, vehicleParts.transmission, Boss.empty);
            B3RA.Room("Room A", 3, B1RD, null, null, B2RA, weapons.empty, vehicleParts.empty, Boss.B3RA);
            
            Rooms start = new Rooms();
            start.GoToRoom(B1RA, character);
        }
    }
}
