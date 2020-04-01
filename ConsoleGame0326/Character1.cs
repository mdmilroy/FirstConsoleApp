using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleGame0326.Character1;

namespace ConsoleGame0326
{
    public class Character1
    {
        public string name;
        public int maxHealth = 20;
        public int currentHealth = 20;
        public int attackValue = 2;
        public bool sword = false;
        public bool gun = false;
        public bool ammo = false;
        public bool shield = false;
        public bool upgradedShield = false;
        public bool readyToFight = false;
        public bool readyToEscape = false;
        public int parts = 0;
        public enum Boss { empty, B1RD, B3RA }

        public enum weapons { empty = 0, ammo = 2, sword = 5, gun = 10, shield = 3, upgradedShield = 8 };
        public Dictionary<string, int> inventory = new Dictionary<string, int>();
        public int monstersKilled = 0;

        public void character(string _name)
        {
            name = _name;
        }

        public void Attack(Beast monster)
        {
            Random damage = new Random();

            if (monstersKilled < 1)
            {
                monster.currentHealth -= attackValue;
                if (monster.currentHealth <= 0)
                {
                    Console.WriteLine("You have attacked the monster! \nIts health is now 0");
                }
                else
                {
                    Console.WriteLine($"You have attacked the monster! \nIts health is now {monster.currentHealth}");
                }
            }
            else
            {
                monster.currentHealth -= attackValue - damage.Next(0, 4); 
                if (monster.currentHealth <= 0)
                {
                    Console.WriteLine("You have attacked the monster! \nIts health is now 0");
                }
                else
                {
                    Console.WriteLine($"You have attacked the monster! \nIts health is now {monster.currentHealth}");
                }
            }
        }
    }

    public class Beast
    {
        public string name;
        public int currentHealth;
        public int attackValue;
        public Random damage = new Random();

        public void monster(string _name, int _health, int _attack)
        {
            name = _name;
            currentHealth = _health;
            attackValue = _attack;
        }

        public void FoundMonster(Character1 character, Beast monster, Rooms room)
        {

            Console.WriteLine("You have found a monster. \nWill you fight? [yes / no]");
            string response = Console.ReadLine().ToLower();
            if (response == "yes")
            {
                Console.WriteLine("Ok... it's your funeral. Let's FIGHT!");
                Battle battle = new Battle();
                battle.Fight(character, monster, room);
            }
            else if (response == "no")
            {
                Console.WriteLine($"Wow {character.name}... you ran away like a scared child.");
            }
            else
            {
                Console.WriteLine("Please try again.");
            }
        }
        public void Attack(Character1 character)
        {
            if (!character.shield && !character.upgradedShield)
            {
            character.currentHealth -= attackValue;
            Console.WriteLine($"The monster attacked you. Your current health is: {character.currentHealth}" +
                                    $"\nPress enter to attack again!");
                Console.ReadLine();
            }
            else if (character.shield && !character.upgradedShield)
            {
                character.currentHealth -= attackValue - damage.Next(0, (int) Character1.weapons.shield);
                Console.WriteLine($"The monster attacked you. But your shield decreased the damage;" +
                                    $"Your current health is: {character.currentHealth}" +
                                    $"\nPress enter to attack again!");
                Console.ReadLine();
            }
            else
            {
                character.currentHealth -= attackValue - damage.Next(0, (int)Character1.weapons.upgradedShield);
                Console.WriteLine($"The monster attacked you. But your new shield decreased the damage;" +
                                    $"Your current health is: {character.currentHealth}" +
                                    $"\nPress enter to attack again!");
                Console.ReadLine();
            }
        }
    }

    public class BigGuns
    {
        public void Bosses(Rooms room, Character1 character)
        {
            if (room.boss == Boss.B1RD && character.monstersKilled == 0)
            {
                Battle battle = new Battle();
                Beast boss1 = new Beast() { };
                boss1.monster("Boss 1", 20, 3);
                Console.WriteLine($"\n{character.name}, you have found the first boss!");
                battle.Fight(character, boss1, room);
            }
            else if (room.boss == Boss.B3RA && character.monstersKilled == 1)
            {
                Battle battle = new Battle();
                Beast boss2 = new Beast() { };
                boss2.monster("Boss 2", 30, 5);
                Console.WriteLine($"\n{character.name}, you have found the second boss!");
                battle.Fight(character, boss2, room);
            }
            else
            {
                room.GoToRoom(room, character);
            }
        }
    }
}
