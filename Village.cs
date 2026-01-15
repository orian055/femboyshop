using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Game
{
    class Village
    {
        public void runVillage()
        {
            Console.Clear();
            Console.WriteLine("The village seems crowded.");
            Thread.Sleep(3000);
            Console.WriteLine("=== Village ===");
            Console.WriteLine("[1] Talk to the village priest");
            Console.WriteLine("[2] Talk to the village hero");
            Console.WriteLine("[3] Talk to the village baker");
            Console.WriteLine("[4] Talk to the village blacksmith");
            Console.WriteLine("[5] Talk to the village wizard");
            Console.WriteLine("[6] Go back");
            
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int talk))
            {
                Console.WriteLine("1-6");
            }

            else
            {
                switch (talk)
                {
                    case 1:
                        Console.WriteLine("village priest: THE DRAGON IS SATAN!");
                        Thread.Sleep(3000);
                        Console.WriteLine("village priest: HE WAS SENT BY GOD TO KILL US ALL!");
                        Thread.Sleep(2500);
                        Console.WriteLine("village priest: WE SHALL OBEY GOD AND DIE!!!!");
                        Thread.Sleep(2500);
                        Console.WriteLine("you: calm down bruh...");
                        Thread.Sleep(2500);
                        Console.WriteLine("who gave you those drugs");
                        Thread.Sleep(2500);
                        Console.WriteLine("village priest: the wizard gang, he got some magical stuff frfr");
                        Console.ReadLine();
                        break;

                    case 2:
                        Console.WriteLine("the hero is looking at the dragon in the sky");
                        Thread.Sleep(2500);
                        Console.WriteLine("you: Are you okay?");
                        Thread.Sleep(2500);
                        Console.WriteLine("village hero: no.");
                        Thread.Sleep(2500);
                        Console.WriteLine("you: what happend?");
                        Thread.Sleep(2500);
                        Console.WriteLine("village hero: this damn dragon, i didnt even know dragons are real.");
                        Thread.Sleep(2500);
                        Console.WriteLine("village hero: i used to be respected around here, people looked up to me.");
                        Thread.Sleep(2500);
                        Console.WriteLine("village hero: i kept them safe, i was their hero.");
                        Thread.Sleep(2500);
                        Console.WriteLine("village hero: this dragon took everything from me, he is too strong to be stopped");
                        Thread.Sleep(2500);
                        Console.WriteLine("village hero: everyone will die, begging for me to help");
                        Thread.Sleep(2500);
                        Console.WriteLine("village hero: but i cant face this dragon, no one can...");
                        Thread.Sleep(2500);
                        Console.WriteLine("you: im gonna kill him");
                        Thread.Sleep(2500);
                        Console.WriteLine("village hero: you? sure buddy");
                        Thread.Sleep(2500);
                        Console.WriteLine("you: i swear ill give my all to kill this dragon!");
                        Thread.Sleep(2500);
                        Console.WriteLine("village hero: Well then. good luck");
                        Console.ReadLine();
                        break;

                    case 3:
                        Console.WriteLine("the baker is making a pizza");
                        Console.WriteLine("you: YOOO THIS LOOKS FIRE");
                        Console.WriteLine("village baker: merci beaucoup! you want a pizza too?");
                        Console.WriteLine("you: a pizza would be nice");
                        Console.WriteLine("village baker: aucun probleme!");
                        Thread.Sleep(2500);
                        Console.Clear();
                        Console.WriteLine("you ate pizza with the baker and drank beers.");
                        Thread.Sleep(2500);
                        Console.WriteLine("hes a nice guy");
                        Console.ReadLine();
                        break;

                    case 4:
                        
                        Console.WriteLine("the blacksmith is doing something");
                        Thread.Sleep(2500);
                        Console.WriteLine("you: what are you building there?");
                        Thread.Sleep(2500);
                        Console.WriteLine("blacksmith: an armor, if the hero wont kill this dragon, i will");
                        Thread.Sleep(2500);
                        Console.WriteLine("you: could you make me an armor too? im going after the dragon aswell");
                        Thread.Sleep(2500);
                        Console.WriteLine("blacksmith: im out of iron, get me some and ill make armors for both us");
                        Thread.Sleep(2500);
                        Console.WriteLine("you: are you inviting me to a dragon killing date?");
                        Thread.Sleep(2500);
                        Console.WriteLine("blacksmith: go get the iron, im waiting");
                        Thread.Sleep(2500);
                        Console.WriteLine("(yes the blackmith is a woman)");
                        Console.ReadLine();
                        break;

                    case 5:
                        Console.WriteLine("the wizard is yelling magic stuff.");
                        Thread.Sleep(2500);
                        Console.WriteLine("you: YO! your drugs fucked the priest up");
                        Thread.Sleep(2500);
                        Console.WriteLine("village wizard: Perhaps my drugs allow one to see his true self?");
                        Thread.Sleep(2500);
                        Console.WriteLine("you: what?");
                        Thread.Sleep(2500);
                        Console.WriteLine("village wizard: just take it idiot");
                        Thread.Sleep(2500);
                        Console.Clear();
                        Console.WriteLine("you smoked some weed");
                        Thread.Sleep(2500);
                        Console.WriteLine("it turned out to be laced");
                        Thread.Sleep(2500);
                        Console.WriteLine("you feel like shit.");
                        Console.ReadLine();
                        break;

                    case 6:
                        Console.WriteLine("You turned back");
                        Thread.Sleep(2500);
                        break;

                    default:
                        Console.WriteLine("1-6");
                        Thread.Sleep(2500);
                        break;

                                                
                }
            }
        }
    }
}