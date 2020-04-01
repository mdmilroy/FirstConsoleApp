using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleGame0326.Character1;

namespace ConsoleGame0326
{
    public class FoundItem
    {
        public void Items(Rooms room, Character1 character)
        {
            Console.WriteLine($"You have found a {Convert.ToString(room.weapon)}");
            Console.WriteLine($"The {room.weapon} has been added to your inventory");
            character.inventory.Add(Convert.ToString(room.weapon), Convert.ToInt32(room.weapon));

            if (room.weapon == weapons.shield)
            {
                character.shield = true;
            }
            else if (room.weapon == weapons.upgradedShield)
            {
                character.upgradedShield = true;
            }
            else if (room.weapon == weapons.sword)
            {
                character.readyToFight = true;
            }
            else if (room.weapon == weapons.gun)
            {
                character.readyToFight = true;
                character.gun = true;
            }
            room.weapon = weapons.empty;
        }
    }
}
