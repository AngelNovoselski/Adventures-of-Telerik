using AdventuresOfTelerik.Models.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventuresOfTelerik.Models.Hero;
using System.Media;

namespace AdventuresOfTelerik.Models
{
    public static class FightMode
    {
        public static void Fight(Hero.Hero hero, Enemy enemy)
        {
            bool SpUsed = false;
            hero.FightMonster += new EventHandler(OnFightedMonster);
            hero.OnFightMonster();

            var message = "You engage a " + enemy.GetType().Name + "!!!";
            var heroType = hero.GetType().Name;

            if (heroType == "Hunter")
            {
                while (hero.Hp > 0 && enemy.Hp > 0)
                {
                    Console.Clear();
                    Console.WriteLine(message);
                    Console.WriteLine("Hero Hp:" + hero.Hp + ", " + "Hero Energy:" + hero.SpecialEnergy + ", " + "Bow Ammo:" + hero.Weapon.Ammo);
                    Console.WriteLine("Enemy Hp:" + enemy.Hp + ", " + "Enemy Energy:" + enemy.Energy);
                    Console.WriteLine("Enter 1 to Shoot with your " + hero.Weapon.GetType().Name);
                    Console.WriteLine("Enter 2 to Run for your Life");
                    Console.WriteLine("Enter 3 for FocusShot");
                    Console.WriteLine("Enter 4 to Stab with your " + hero.WeaponSecond.GetType().Name);
                    var a = Console.ReadLine();
                    switch (a)
                    {
                        case "1":
                            if (hero.Weapon.Ammo == 0)
                            {
                                Console.WriteLine($"No more ammo, try something else!");
                                break;
                            }
                            else
                            {
                                enemy.Hp -= hero.Weapon.Dmg;
                                if (hero.Weapon.Ammo > 0)
                                {
                                    hero.Weapon.Ammo -= 1;
                                }
                                Console.WriteLine($"The monster loses {hero.Weapon.Dmg} HP!");
                                break;
                            }
                        case "2":
                            hero.Hp -= 5;
                            Console.WriteLine($"It is too late to run!");
                            break;
                        case "3":
                            if (hero.SpecialEnergy < 44)
                            {
                                Console.WriteLine($"Not enough energy for FocusShot!");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }
                            else
                            {
                                enemy.Hp -= hero.SpecialAttack();
                                Console.WriteLine($"The monster loses {hero.SpecialAttack()} HP!");
                                break;
                            }
                        case "4":
                            enemy.Hp -= hero.WeaponSecond.Dmg;
                            Console.WriteLine($"The monster loses {hero.WeaponSecond.Dmg} HP!");
                            break;
                        default:
                            Console.WriteLine("You wasted your turn dummy! Now face the consequences!");
                            break;
                    }

                    if (enemy.Hp <= 0)
                    {
                        break;
                    }
                    

                    Console.WriteLine("WAIT FOR ENEMY TURN");
                    System.Threading.Thread.Sleep(1000);
                    if (enemy.Energy < 5)
                    {
                        if (enemy.Hp <= 100 && !SpUsed)
                        {
                            SpUsed = true;
                            enemy.SecondWind();
                            Console.WriteLine($"You lose {enemy.Dmg + enemy.SpecialAttack()} HP!");
                            System.Threading.Thread.Sleep(2000);
                            hero.Hp -= enemy.Dmg + enemy.SpecialAttack();
                        }
                        else
                        {
                            Console.WriteLine($"You lose {enemy.Dmg} HP!");
                            System.Threading.Thread.Sleep(2000);
                            hero.Hp -= enemy.Dmg;
                        }
                    }
                    else
                    {
                        if (enemy.Hp <= 100 && !SpUsed)
                        {

                            SpUsed = true;
                            enemy.SecondWind();
                            Console.WriteLine($"The Monster Roars!");
                            Console.WriteLine($"You lose {enemy.Dmg + enemy.Roar() + enemy.SpecialAttack()} HP!");
                            System.Threading.Thread.Sleep(2000);
                            hero.Hp -= enemy.Dmg + enemy.Roar() + enemy.SpecialAttack();
                        }
                        else
                        {
                            int score = enemy.Roar();
                            Console.WriteLine($"The Monster Roars!");
                            Console.WriteLine($"You lose {enemy.Dmg + score} HP!");
                            System.Threading.Thread.Sleep(2000);
                            hero.Hp -= enemy.Dmg + score;
                        }
                    }
                }
            }

            if (heroType == "Warrior")
            {
                while (hero.Hp > 0 && enemy.Hp > 0)
                {
                    Console.Clear();
                    Console.WriteLine(message);
                    Console.WriteLine("Hero Hp:" + hero.Hp + ", " + "Hero Fury:" + hero.SpecialEnergy);
                    Console.WriteLine("Enemy Hp:" + enemy.Hp + ", " + "Enemy Energy:" + enemy.Energy);
                    Console.WriteLine("Enter 1 for hit with " + hero.Weapon.GetType().Name);
                    Console.WriteLine("Enter 2 to Run for your Life");
                    Console.WriteLine("Enter 3 for RageAnger");
                    Console.WriteLine("Enter 4 to Stab with your " + hero.WeaponSecond.GetType().Name);

                    var a = Console.ReadLine();
                    switch (a)
                    {
                        case "1":
                            enemy.Hp -= hero.Weapon.Dmg;
                            if (hero.SpecialEnergy < 100)
                            {
                                hero.SpecialEnergy += 20;
                            }
                            Console.WriteLine($"The monster loses {hero.Weapon.Dmg} HP!");
                            break;
                        case "2":
                            hero.Hp -= 5;
                            Console.WriteLine($"It is too late to run!");
                            break;
                        case "3":
                            if (hero.SpecialEnergy < 40)
                            {
                                Console.WriteLine($"Not enough fury for RageAnger!");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }
                            else
                            {
                                enemy.Hp -= hero.SpecialAttack();
                                Console.WriteLine($"The monster loses {hero.SpecialAttack()} HP!");
                                break;
                            }
                        case "4":
                            enemy.Hp -= hero.WeaponSecond.Dmg;
                            Console.WriteLine($"The monster loses {hero.WeaponSecond.Dmg} HP!");
                            break;
                        default:
                            Console.WriteLine("You wasted your turn dummy! Now face the consequences!");
                            break;
                    }

                    if (enemy.Hp <= 0)
                    {
                        break;
                    }

                    Console.WriteLine("WAIT FOR ENEMY TURN");
                    System.Threading.Thread.Sleep(1000);
                    
                    if (enemy.Energy < 5)
                    {
                        if (enemy.Hp <= 100 && !SpUsed)
                        {
                            SpUsed = true;
                            enemy.SecondWind();
                            Console.WriteLine($"You lose {enemy.Dmg + enemy.SpecialAttack()} HP!");
                            System.Threading.Thread.Sleep(2000);
                            hero.Hp -= enemy.Dmg + enemy.SpecialAttack();
                        }
                        else
                        {
                            Console.WriteLine($"You lose {enemy.Dmg} HP!");
                            System.Threading.Thread.Sleep(2000);
                            hero.Hp -= enemy.Dmg;
                        }
                    }
                    else
                    {
                        if (enemy.Hp <= 100 && !SpUsed)
                        {

                            SpUsed = true;
                            enemy.SecondWind();
                            Console.WriteLine($"The Monster Roars!");
                            Console.WriteLine($"You lose {enemy.Dmg + enemy.Roar() + enemy.SpecialAttack()} HP!");
                            System.Threading.Thread.Sleep(2000);
                            hero.Hp -= enemy.Dmg + enemy.Roar() + enemy.SpecialAttack();
                        }
                        else
                        {
                            int score = enemy.Roar();
                            Console.WriteLine($"The Monster Roars!");
                            Console.WriteLine($"You lose {enemy.Dmg + score} HP!");
                            System.Threading.Thread.Sleep(2000);
                            hero.Hp -= enemy.Dmg + score;
                        }
                    }
                }
            }

            if (heroType == "Mage")
            {
                while (hero.Hp > 0 && enemy.Hp > 0)
                {
                    Console.Clear();
                    Console.WriteLine(message);
                    Console.WriteLine("Hero Hp:" + hero.Hp + ", " + "Hero Mana:" + hero.SpecialEnergy);
                    Console.WriteLine("Enemy Hp:" + enemy.Hp + ", " + "Enemy Energy:" + enemy.Energy);
                    Console.WriteLine("Enter 1 for hit with " + hero.Weapon.GetType().Name);
                    Console.WriteLine("Enter 2 to Run for your Life");
                    Console.WriteLine("Enter 3 for FireBlast");
                    Console.WriteLine("Enter 4 to Stab with your " + hero.WeaponSecond.GetType().Name);

                    var a = Console.ReadLine();
                    switch (a)
                    {
                        case "1":
                            enemy.Hp -= hero.Weapon.Dmg;
                            Console.WriteLine($"The monster loses {hero.Weapon.Dmg} HP!");
                            break;
                        case "2":
                            hero.Hp -= 5;
                            Console.WriteLine($"It is too late to run!");
                            break;
                        case "3":
                            if (hero.SpecialEnergy < 35)
                            {
                                Console.WriteLine($"Not enough mana for CastSpell!");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }
                            else
                            {
                                enemy.Hp -= hero.SpecialAttack();
                                Console.WriteLine($"The monster loses {hero.SpecialAttack()} HP!");
                                break;
                            }
                        case "4":
                            enemy.Hp -= hero.WeaponSecond.Dmg;
                            Console.WriteLine($"The monster loses {hero.WeaponSecond.Dmg} HP!");
                            break;
                        default:
                            Console.WriteLine("You wasted your turn dummy! Now face the consequences!");
                            break;
                    }

                    if (enemy.Hp <= 0)
                    {
                        break;
                    }

                    Console.WriteLine("WAIT FOR ENEMY TURN");
                    System.Threading.Thread.Sleep(1000);
                    if (enemy.Energy < 5)
                    {
                        if (enemy.Hp <= 100 && !SpUsed)
                        {
                            SpUsed = true;
                            enemy.SecondWind();
                            Console.WriteLine($"You lose {enemy.Dmg + enemy.SpecialAttack()} HP!");
                            System.Threading.Thread.Sleep(2000);
                            hero.Hp -= enemy.Dmg + enemy.SpecialAttack();
                        }
                        else
                        {
                            Console.WriteLine($"You lose {enemy.Dmg} HP!");
                            System.Threading.Thread.Sleep(2000);
                            hero.Hp -= enemy.Dmg;
                        }
                    }
                    else
                    {
                        if (enemy.Hp <= 100 && !SpUsed)
                        {

                            SpUsed = true;
                            enemy.SecondWind();
                            Console.WriteLine($"The Monster Roars!");
                            Console.WriteLine($"You lose {enemy.Dmg + enemy.Roar() + enemy.SpecialAttack()} HP!");
                            System.Threading.Thread.Sleep(2000);
                            hero.Hp -= enemy.Dmg + enemy.Roar() + enemy.SpecialAttack();
                        }
                        else
                        {
                            int score = enemy.Roar();
                            Console.WriteLine($"The Monster Roars!");
                            Console.WriteLine($"You lose {enemy.Dmg + score} HP!");
                            System.Threading.Thread.Sleep(2000);
                            hero.Hp -= enemy.Dmg + score;
                        }
                    }
                }
            }
        }

        public static void OnFightedMonster(object sender, EventArgs args)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"..\..\..\monster2.wav");
            simpleSound.Play();
        }
    }
}
