using Drofsnar2._0;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drofsnar2._0ConsoleUI.UI
{
    public class ProgramUI
    {
        private bool continueToRun = true;
        private string userInput;
        private Random rand = new Random();
        private int randomNumber;
        private string encounter;
        private int isVulnerableCount;
        Drofsnar drofsnar = new Drofsnar();
        private int _stopperOneXPosition;
        private int _stopperOneYPosition;
        private int _stopperTwoXPosition;
        private int _stopperTwoYPosition;
        private int _stopperThreeXPosition;
        private int _stopperThreeYPosition;
        private int _stopperFourXPosition;
        private int _stopperFourYPosition;
        private HashSet<int> _positions = new HashSet<int>();



        private List<string> _stopperOffList = new List<string>()
        {
            "Nothing",
            "Nothing",
            "Nothing",
            "Nothing",
            "Bird",
            "Bird",
            "Bird",
            "Bird",
            "Crested Ibis",
            "Crested Ibis",
            "Crested Ibis",
            "Great Kiskudee",
            "Great Kiskudee",
            "Great Kiskudee",
            "Red Crossbill",
            "Red Crossbill",
            "Red-necked Phalarope",
            "Red-necked Phalarope",
            "Evening Grosbeak",
            "Greater Prairie Chicken",
            "Iceland Gull",
            "Orange-Bellied Parrot",
            "Invincible Bird Hunter",
            "Invincible Bird Hunter",
            "Invincible Bird Hunter",
            "Invincible Bird Hunter"
        };
        private List<string> _stopperOnList = new List<string>()
        {
            "Nothing",
            "Nothing",
            "Nothing",
            "Nothing",
            "Bird",
            "Bird",
            "Bird",
            "Bird",
            "Crested Ibis",
            "Crested Ibis",
            "Crested Ibis",
            "Great Kiskudee",
            "Great Kiskudee",
            "Great Kiskudee",
            "Red Crossbill",
            "Red Crossbill",
            "Red-necked Phalarope",
            "Red-necked Phalarope",
            "Evening Grosbeak",
            "Greater Prairie Chicken",
            "Iceland Gull",
            "Orange-Bellied Parrot",
            "Vulnerable Bird Hunter",
            "Vulnerable Bird Hunter",
            "Vulnerable Bird Hunter",
            "Vulnerable Bird Hunter"
        };
        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            Console.WriteLine("Would you like to play a game? Y/N");
            userInput = (Console.ReadLine()).ToUpper();
            Console.Clear();
            switch (userInput)
            {
                case "Y":
                    EnterTheRoom();
                    break;
                case "N":
                    break;
            }
        }

        private void EnterTheRoom()
        {

            _positions = GetStopperPositions();
            var positionsAsList = _positions.ToList();

            _stopperOneXPosition = GetStopperXPosition(positionsAsList[0]);
            _stopperOneYPosition = GetStopperYPosition(positionsAsList[0]);
            _stopperTwoXPosition = GetStopperXPosition(positionsAsList[1]);
            _stopperTwoYPosition = GetStopperYPosition(positionsAsList[1]);
            _stopperThreeXPosition = GetStopperXPosition(positionsAsList[2]);
            _stopperThreeYPosition = GetStopperYPosition(positionsAsList[2]);
            _stopperFourXPosition = GetStopperXPosition(positionsAsList[3]);
            _stopperFourYPosition = GetStopperYPosition(positionsAsList[3]);

            //_stopperOneXPosition = GetStopperXPosition(/*value from hashset*/);



            Console.WriteLine("You have been placed in a  \n" +
                "random spot in a room. Maneuver around \n" +
                "the room looking for birds, but BEWARE of \n" +
                "the bird hunters. They will try to take your \n" +
                "life. Lose too many lives and the GAME IS OVER\n" +
                "Press any key to continue");
            Console.ReadKey();
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine($"Score: {drofsnar.Score}");
                Console.WriteLine($"Lives: {drofsnar.LifeCounter}");
                Console.WriteLine("Which way would you like to go?\n" +
                    "Choose from\n" +
                    "RIGHT\n" +
                    "LEFT\n" +
                    "FORWARD\n" +
                    "BACKWARD\n");
                userInput = (Console.ReadLine()).ToUpper();
                if (userInput == "RIGHT" && drofsnar.XPosition == 6)
                {
                    Console.Clear();
                    Console.WriteLine("You have reached the right-most wall.\n" +
                        "Press any key to choose a different direction.");
                    File.ReadAllLines(@"C:\Users\konra\OneDrive\Documents\ElevenFiftyProjects\GoldBadge\Drofsnar2\Drofsnar2.0\Drofsnar2.0ConsoleUI\assets\wall.txt").ToList().ForEach(c => Console.WriteLine(c));
                    Console.ReadKey();
                    continue;
                }
                else if (userInput == "LEFT" && drofsnar.XPosition == 1)
                {
                    Console.WriteLine("You have reached the left-most wall.\n" +
                        "Press any key to choose a different direction.");
                    Console.ReadKey();
                    continue;
                }
                else if (userInput == "FORWARD" && drofsnar.YPosition == 6)
                {
                    Console.WriteLine("You have reached the far wall.\n" +
                        "Press any key to choose a different direction.");
                    Console.ReadKey();
                    continue;
                }
                else if (userInput == "BACKWARD" && drofsnar.YPosition == 1)
                {
                    Console.WriteLine("You have backed into the wall.\n" +
                        "Press any key to choose a different direction.");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    switch (userInput)
                    {
                        case "RIGHT":
                            drofsnar.XPosition += 1;
                            break;
                        case "LEFT":
                            drofsnar.XPosition -= 1;
                            break;
                        case "FORWARD":
                            drofsnar.YPosition += 1;
                            break;
                        case "BACKWARD":
                            drofsnar.YPosition -= 1;
                            break;
                    }
                }

                if ((drofsnar.XPosition == _stopperOneXPosition && drofsnar.YPosition == _stopperOneYPosition) || (drofsnar.XPosition == _stopperTwoXPosition && drofsnar.YPosition == _stopperTwoYPosition) || (drofsnar.XPosition == _stopperThreeXPosition && drofsnar.YPosition == _stopperThreeYPosition) || (drofsnar.XPosition == _stopperFourXPosition && drofsnar.YPosition == _stopperFourYPosition))
                {
                    drofsnar.IsVulnerable = true;
                    Console.WriteLine("The hunters are vulnerable\n" +
                        "Press any key to continue");
                    Console.ReadKey();
                }

                else
                {
                    randomNumber = rand.Next(0, _stopperOffList.Count());

                    if (drofsnar.IsVulnerable)
                    {
                        encounter = _stopperOnList[randomNumber];
                        isVulnerableCount += 1;
                        if (isVulnerableCount == 4)
                        {
                            drofsnar.IsVulnerable = false;
                            drofsnar.VulnBHCounter = 1;
                            while (_stopperOnList.Count < _stopperOffList.Count)
                            {
                                _stopperOnList.Add("Vulnerable Bird Hunter");
                            }
                        }

                    }
                    else
                    {
                        encounter = _stopperOffList[randomNumber];
                    }

                    switch (encounter)
                    {
                        case "Nothing":
                            Console.WriteLine("You did not encounter anything. Press any key to continue on your journey");
                            Console.ReadKey();
                            break;

                        case "Bird":
                            drofsnar.BirdEncounter();
                            break;
                        case "Crested Ibis":
                            drofsnar.IbisEncounter();
                            break;
                        case "Great Kiskudee":
                            drofsnar.KiskudeeEncounter();
                            break;
                        case "Red Crossbill":
                            drofsnar.CrosbillEncounter();
                            break;
                        case "Red-necked Phalarope":
                            drofsnar.PhalaropeEncounter();
                            break;
                        case "Evening Grosbeak":
                            drofsnar.GrosbeakEncounter();
                            break;
                        case "Greater Prairie Chicken":
                            drofsnar.ChickenEncounter();
                            break;
                        case "Iceland Gull":
                            drofsnar.GullEncounter();
                            break;
                        case "Orange-Bellied Parrot":
                            drofsnar.ParrotEncounter();
                            break;
                        case "Vulnerable Bird Hunter":
                            drofsnar.VulnBirdHunterEncounter();
                            break;
                        case "Invincible Bird Hunter":
                            drofsnar.InvincibleBirdHunterEncounter();
                            break;
                        default:
                            break;
                    }

                }
                CheckConditions();
            }


        }
        public void CheckConditions()
        {
            if (drofsnar.LifeCounter == 0)
            {
                Console.WriteLine("YOU ARE DEAD");
            }
            if (drofsnar.Score >= 10000 * drofsnar.GainLife)
            {
                Console.WriteLine($"You reached {drofsnar.Score} points and gained a life!");
                drofsnar.GainLife += 1;
            }
            if (drofsnar.Score >= 50000)
            {
                Console.WriteLine($"You reached {drofsnar.Score} points. \n" +
                  $"YOU WIN");
                continueToRun = false;
            }
        }

        public HashSet<int> GetStopperPositions()
        {
            HashSet<int> positions = new HashSet<int>();
            while (positions.Count() < 4)
            {
                positions.Add(rand.Next(1, 37));
            }
            return positions;
        }

        public int GetStopperXPosition(int x)
        {
            if (x == 1 || x == 7 || x == 13 || x == 19 || x == 25 || x == 31)
            {
                return 1;
            }
            else if (x == 2 || x == 8 || x == 14 || x == 20 || x == 26 || x == 32)
            {
                return 2;
            }
            else if (x == 3 || x == 9 || x == 15 || x == 21 || x == 27 || x == 33)
            {
                return 3;
            }
            else if (x == 4 || x == 10 || x == 16 || x == 22 || x == 28 || x == 34)
            {
                return 4;
            }
            else if (x == 5 || x == 11 || x == 17 || x == 23 || x == 29 || x == 35)
            {
                return 5;
            }
            else if (x == 6 || x == 12 || x == 18 || x == 24 || x == 30 || x == 36)
            {
                return 6;
            }
            else
            {
                return 0;
            }
        }
        public int GetStopperYPosition(int y)
        {
            if (y >= 1 && y <= 6)
            {
                return 6;
            }
            else if (y >= 7 && y <= 12)
            {
                return 5;
            }
            else if (y >= 13 && y <= 18)
            {
                return 4;
            }
            else if (y >= 19 && y <= 24)
            {
                return 3;
            }
            else if (y >= 25 && y <= 30)
            {
                return 2;
            }
            else if (y >= 31 && y <= 36)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

    }
}

