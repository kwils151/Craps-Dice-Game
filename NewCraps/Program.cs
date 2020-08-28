using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Kyle Wilson
namespace NewCraps
{

        class Program
        {

            static void Main(string[] args)
            {

                //variables used to store info about the game
                int credits = 100;
                string input;
                int wager;


                int point = 0;
                int reRoll = 0;


                int gameNum = 1;


                //creates random numbers for die values
                Random rand = new Random();
                int[] face = new int[2];


                //holds the choices for the switch statement
                string choice = " ";
                string choice2 = " ";

                //loops the game until the quit choice is chosen
                do
                {

                    Console.WriteLine("P - To Play");
                    Console.WriteLine("Q - Quit");
                    choice = Console.ReadLine().ToUpper(); //converts to upercase so it doesnt crash the program with lowercase input
                    Console.WriteLine("\n");


                    switch (choice)
                    {
                        //ends the game if quit is chosen
                        case "Q":
                            Console.WriteLine("GOODBYE");
                            Console.WriteLine("Credits: " + credits);
                            Console.ReadLine();
                            break;


                        //case P is to play the game
                        case "P":


                            int roundNum = 1;


                            //visual for the user
                            Console.WriteLine("------------");
                            Console.WriteLine("|  Game " + gameNum + "  |" + "   Credits: " + credits);
                            Console.WriteLine("------------");
                            gameNum++;


                            Console.Write("Make a wager: ");


                            //converts the string input to an integer
                            input = Console.ReadLine();
                            wager = Int32.Parse(input);
                            Console.WriteLine();


                            //loop to check the credit ballance against the wager
                            if (wager > credits)
                            {
                                do 
                                {
                                    Console.WriteLine("Insufficient Credits");
                                    Console.Write("Make A Wager: ");
                                    input = Console.ReadLine();
                                    wager = Int32.Parse(input);
                                    Console.WriteLine();

                                } while (wager > credits);
                            }


                            //visual for the user to see the dice values
                            for (int i = 0; i < 2; i++)
                            {
                                face[i] = rand.Next(6);
                                Console.WriteLine((i + 1) + ") Die: " + face[i]);
                            }


                            //sums the die for the users "point" value
                            point = (face[0] + face[1]);
                            Console.WriteLine("Total:  " + point);


                            //if the user wins
                            if (point == 7 || point == 11)
                            {
                                Console.WriteLine("You Win!\n\n\n\n");
                                credits = (credits + wager);
                                break;
                            }

                            //if the user loses
                            if (point == 2 || point == 3 || point == 12)
                            {
                                Console.WriteLine("You Lose!\n\n\n\n");
                                credits = (credits - wager);

                                //checks if the user has enough credits to play again. If not the choice is set to quit
                                if (credits == 0)
                                {
                                    Console.WriteLine("Out of credits. GAME OVER");
                                    choice = "Q";
                                    Console.ReadLine();
                                }

                                break;
                            }


                            //the "reroll" section if the user does not win or lose on the first roll
                            else
                            {

                                //visual for the users "point" value going into the reroll
                                Console.WriteLine("\n\n** Point: " + point + " **\n");


                                do
                                {

                                    Console.WriteLine("R - Roll Again");
                                    choice2 = Console.ReadLine();


                                    //creates new dice values
                                    for (int i = 0; i < 2; i++)
                                    {
                                        face[i] = rand.Next(6);
                                        Console.WriteLine("Die (" + (i + 1) + "): " + face[i]);
                                    }

                                    //visual for the user to see reroll values and totals
                                    reRoll += (face[0] + face[1]);
                                    Console.WriteLine("Reroll Total: " + reRoll + "\n\n");

                                    //if the user wins the reroll
                                    if (reRoll == point)
                                    {
                                        Console.WriteLine("Point, You Win!\n\n\n\n");
                                        credits = (credits + wager);
                                        break;
                                    }

                                    //if the user loses the reroll
                                    if (reRoll == 7)
                                    {
                                        Console.WriteLine("Rolled 7, You Lose!\n\n\n\n");
                                        credits = (credits - wager);
                                        
                                        //checks if the user has enough credits to play again
                                        if (credits == 0)
                                        {
                                            Console.WriteLine("Out of credits. GAME OVER");
                                            choice = "Q";
                                            Console.ReadLine();
                                        }

                                        break;
                                    }

                                    //resets the reroll value
                                    reRoll = 0;


                                } while (choice2 != "QH"); //continues the do loop until the game is won or lost

                            }

                            break;

                    }


                } while (choice != "Q"); // loops the game until "Q" is chosen to quit the game

            }

        }
    }