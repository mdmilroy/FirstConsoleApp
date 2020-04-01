using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame0326
{
    class Battle
    {
        public void Fight(Character1 character, Beast monster, Rooms room)
        {
            Console.WriteLine("Select your weapon: \n");
            foreach (KeyValuePair<string, int> weapon in character.inventory)
            {
                if (weapon.Key == "sword" || weapon.Key == "gun")
                {
                    string item = Convert.ToString(weapon.Key).ToUpper();
                    Console.WriteLine(item);
                }
                else
                {
                    continue;
                }
            }
            string weaponChoice = Console.ReadLine().ToLower();

            if (weaponChoice == "sword")
            {
                character.attackValue = (int)Character1.weapons.sword;
            }
            else if (weaponChoice == "gun" && character.gun)
            {
                character.attackValue = (int)Character1.weapons.gun;
            }
            else
            {
                Console.WriteLine("Please enter a valid option");
                Fight(character, monster, room);
            }


            while (character.currentHealth > 0 && monster.currentHealth > 0)
            {
                character.Attack(monster);
                if (monster.currentHealth <= 0)
                {
                    character.currentHealth = character.maxHealth;
                    Console.WriteLine("\n\n\nYou have killed the monster!" +
                        $"\nThe monster dropped a potion. Your health is now back to {character.currentHealth}/{character.maxHealth}");
                    character.monstersKilled++;
                    character.readyToFight = false;

                    
                    if (character.monstersKilled == 2)
                    {
                        Console.WriteLine("Press Enter to go back outside");
                        Console.ReadLine();
                        Console.Clear();
                        character.readyToEscape = true;
                        GetawayVehicle car = new GetawayVehicle();
                        car.Escape();
                    }
                }
                else
                {
                    monster.Attack(character);
                }

                if (character.currentHealth <= 0)
                {
                    Console.WriteLine("You have been killed... \nGAME OVER.");
                    Console.ReadLine();
                    Environment.Exit(1);
                }
            }
        }
    }
}
