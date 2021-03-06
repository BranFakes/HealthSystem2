using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HealthSystem
{





    using System;

    namespace HealthSytem
    {
        class Program
        {
            static int healthPotion;



            static int lives = 3;

            static string[] HPStates = new string[6];

            static int health = 100;
            static int shield = 100;


            static bool Attacking = false;
            static bool Healing = false;
            static bool gameOn = false;


            static int enemyHealth = 450;

            static System.Random Random = new System.Random();

            static int playerState = 0;
            static int Pdmg;
            static int Edmg;





            static void CurrentPlayerState()
            {
                // Good states, keep this for extra mile.

                playerState = Random.Next(1, 2);


                if (playerState == 1)
                {

                    Attacking = true;
                    Healing = false;
                }
                if (playerState == 2)
                {

                    Attacking = false;
                    Healing = true;
                }
            }

            static void HealthState()
            {
                if (health >= 75)
                {
                    Console.WriteLine(HPStates[0]);
                }
                if (health <= 74 && health >= 55)
                {
                    Console.WriteLine(HPStates[1]);
                }
                if (health <= 54 && health >= 35)
                {
                    Console.WriteLine(HPStates[2]);
                }
                if (health <= 34 && health >= 20)

                {
                    Console.WriteLine(HPStates[3]);
                }
                if (health <= 19 && health >= 1)
                {
                    Console.WriteLine(HPStates[4]);
                }
                if (health <= 0)
                {
                    Console.WriteLine(HPStates[5]);

                }
                if (lives <= 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine(" YOU DIED!! *Dark Souls Death Sound* ");
                    Console.WriteLine("");
                }
                if (enemyHealth <= 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine(" You Won The Battle! + 1,000,000 GOLD COINS!!! ");
                    Console.WriteLine("");
                }

            }

            static void Punch()
            {
                if (Attacking == true)
                {
                    if (enemyHealth <= 0)
                    {
                        Console.WriteLine("You Won The Battle!");
                        Console.WriteLine("You Beat The Game!");
                        gameOn = false;
                    }

                    Pdmg = Random.Next(1, 75);

                    enemyHealth = enemyHealth - Pdmg;

                    Console.WriteLine("You Attack! " + Pdmg + " Damage.");
                    Console.WriteLine(" Enemy Has " + enemyHealth + " Current Hp ");
                    Console.WriteLine("");
                }
            }

            static void DamageTaken()
            {
                Edmg = Random.Next(1, 50);

                shield = shield - Edmg;

                Console.WriteLine(" You take " + Edmg + " damage.");
                Console.WriteLine("");



                if (shield <= 0)
                {
                    health = health + shield;

                    shield = 0;
                }

                if (health <= 0)
                {
                    lives = lives - 1;
                    if (lives >= 1)
                    {
                        health = 100;
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Life -1");
                    Console.WriteLine("");
                }
            }

            static void Heal()
            {
                if (Healing == true)
                {
                    // randomizing is EXTREAMLY DANGEROUS for UNIT TESTING
                    // if you want to do randomize put it outside. Good extra mile tho.
                    healthPotion = Random.Next(1, 50);

                    health = health + healthPotion;

                    Console.WriteLine("Hp Up! " + healthPotion + " Hp.");

                    if (health >= 100)
                    {
                        shield = shield + health - 100;

                        health = 100;
                    }
                    if (shield > 100)
                    {
                        Console.WriteLine("Sheild Maxed ");
                        shield = 100;
                    }
                }
            }

            
            static void UnitTest()
            {
          
                
                health = 100;
                Heal();
                Debug.Assert(health == 100);
                Console.WriteLine("Healed up");
                
                                         
                              
                              
                
                Console.WriteLine("Player has less than 0 sheild");
                shield = 1;
                Debug.Assert(health == 0);
                
                
                Console.WriteLine("Player has less than 0 health. ");
                shield = 0;
                Debug.Assert(health == 0);
                                               
               

                Console.WriteLine("Player will have under 0 lives. will break below 0");
                lives = 0;
                health = 0;
                shield = 0;
                Debug.Assert(lives == 0);


                Console.ReadKey(true);
                

                Console.WriteLine("Player has more than 3 lives. Methoed will break above 3");
                lives = 3;

                Debug.Assert(lives <= 3);
                        
                          
            }





            static void ShowHud()
            {

                Console.WriteLine(" ============");
                Console.WriteLine("");
                HealthState();
                Console.WriteLine(" Current Health: " + health + "  " + "Shield: " + shield);
                Console.WriteLine("");
                Console.WriteLine(" Current Lives: " + lives);
                Console.WriteLine("");
                Console.WriteLine(" ============");
                Console.WriteLine("");
                Console.WriteLine("Press Any Key");
                Console.WriteLine("");
                Console.ReadKey();

            }

            static void Array()
            {
                HPStates[0] = " Health In Green Zone ";
                HPStates[1] = " You took a bit of damage ";
                HPStates[2] = " You're Hurt ";
                HPStates[3] = " You Must Do Something Quick! ";
                HPStates[4] = " You Feel Like Theres Only One More Chance ";
                HPStates[5] = " *Dark Souls Death Sound* YOU DIED... ";
            }








            static void Main(string[] args)
            {
                Console.WriteLine("Press Any Key To Survive");
                Console.ReadKey();
                UnitTest();
                ShowHud();
                gameOn = true;

                while (gameOn == true)
                {
                    if (enemyHealth <= 0) break;                   
                                   
                    if (lives <= 0) break;
                                                    
                    Array();
                    CurrentPlayerState();
                    Punch();
                    Heal();
                    DamageTaken();
                    ShowHud();
                }

            }
        }
    }


}
