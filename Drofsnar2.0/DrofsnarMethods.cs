using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drofsnar2._0
{
    public class Drofsnar
    {


        private Random _calcPosition = new Random();



        //Encounters:
        //        Bird: 10 points each
        //Crested Ibis: 100 points
        //Great Kiskudee: 300 points
        //Red Crossbill: 500 points
        //Red-necked Phalarope: 700 points
        //Evening Grosbeak: 1000 points
        //Greater Prairie Chicken: 2000 points
        //Iceland Gull: 3000 points
        //Orange-Bellied Parrot: 5000 points
        //Vulnerable Bird Hunters: - 4
        //reduce by 1 every time you encounter one following a stopper
        //increase score for subsequent encounters
        //#1 in succession: 200 points 
        //#2 in succession: 400 points
        //#3 in succession: 800 points
        //#4 in succession: 1600 points  
        //Stopper
        // toggle vulnerability, how long?
        //reset counter for vulnerable encountered
        //Invincible Bird Hunters - 4

  
        public int Score { get; set; }
        public int VulnBHCounter { get; set; }
        public int LifeCounter { get; set; }
        public int GainLife { get; set; }
        public bool IsVulnerable { get; set; }

        public int XPosition { get; set; }
        public int YPosition {get; set;}

        public Drofsnar()
        {
            Score = 0;
            GainLife = 1;
            LifeCounter = 3;
            VulnBHCounter = 0;
            IsVulnerable = false;
            XPosition = _calcPosition.Next(1, 7);
            YPosition = _calcPosition.Next(1, 7);
        }

        public void BirdEncounter()
        {
            Score += 10;
            Console.WriteLine("You encountered a bird and gained 10 points\n" +
                "Press any key to continue.");
            Console.ReadKey();
        }
        public void IbisEncounter()
        {
            Score += 100;
            Console.WriteLine("You encountered a Crested Ibis and gained 100 points\n" +
                "Press any key to continue.");
            Console.ReadKey();
        }
        public void KiskudeeEncounter()
        {
            Score += 300;
            Console.WriteLine("You encountered a Great Kiskudee and gained 300 points\n" +
                "Press any key to continue.");
            Console.ReadKey();
        }
        public void CrosbillEncounter()
        {
            Score += 500;
            Console.WriteLine("You encountered a Red Crossbill and gained 500 points\n" +
                "Press any key to continue.");
            Console.ReadKey();
        }
        public void PhalaropeEncounter()
        {
            Score += 700;
            Console.WriteLine("You encountered a Red-necked Phalarope and gained 700 points\n" +
                "Press any key to continue.");
            Console.ReadKey();
        }
        public void GrosbeakEncounter()
        {
            Score += 1000;
            Console.WriteLine("You encountered an Evening Grosbeak and gained 1000 points\n" +
                "Press any key to continue.");
            Console.ReadKey();
        }
        public void ChickenEncounter()
        {
            Score += 2000;
            Console.WriteLine("You encountered a Greater Prairie Chicken and gained 2000 points\n" +
                "Press any key to continue.");
            Console.ReadKey();
        }
        public void GullEncounter()
        {
            Score += 3000;
            Console.WriteLine("You encountered an Iceland Gull and gained 3000 points\n" +
                "Press any key to continue.");
            Console.ReadKey();
        }
        public void ParrotEncounter()
        {
            Score += 5000;
            Console.WriteLine("You encountered an Orange-Bellied Parrot and gained 5000 points\n" +
                "Press any key to continue.");
            Console.ReadKey();
        }
        public void VulnBirdHunterEncounter()
        {
            int points = Convert.ToInt32((200 * Math.Pow(2, VulnBHCounter)));
            Score += points;
            VulnBHCounter++;
            Console.WriteLine($"You encountered a vulnerable bird hunter and gained {points} points\n" +
                $"Press any key to continue.");
            Console.ReadKey();

        }
        public void InvincibleBirdHunterEncounter()
        {
            Console.WriteLine("You were attacked by a bird hunter and lost 1 life \n" +
                "Press any key to continue");
            LifeCounter -= 1;
            Console.ReadKey();
        }
        public void StopperEncounter()
        {
            IsVulnerable = true;

        }


    }
}
