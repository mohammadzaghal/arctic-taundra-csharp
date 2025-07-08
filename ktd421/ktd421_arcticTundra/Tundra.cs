using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktd421_arcticTundra
{
     public class Tundra
    {
        public int turn;
        public bool endSim;
        public List<Predator> predators;
        public List<Prey> preys;

        public Tundra()
        {
            turn = 1;
            endSim = false;
            predators = new List<Predator>();
            preys = new List<Prey>();
        }

        public int TotalPreyCount()
        {
            return preys.Sum(p => p.GetCntAnim());
        }

        public int TotalPredatorCount()
        {
            return predators.Sum(p => p.GetCntAnim());
        }

        public void startSim()
        {
            Random random = new Random();
            Console.WriteLine("Simulation Started");
            Console.WriteLine("Predator Colonies:");

            foreach (var p in predators)
            {
                Console.WriteLine(p.GetName() + " :" + p.GetCntAnim());
            }
            Console.WriteLine();
            Console.WriteLine("Prey Colonies:");

            foreach (Prey pre in preys)
            {
                Console.WriteLine(pre.GetName() + " :" + pre.GetCntAnim());
            }

            int predCount = 0;
            Prey[] preyCount = new Prey[preys.Count];

            foreach (var pr in predators)
            {
                predCount += pr.GetCntAnim();
            }
            int t = 0;
            foreach (var p in preys)
            {
                preyCount[t++] = p;
            }

            while (!endSim)
            {
                Console.WriteLine("turn: " + turn);
                Console.WriteLine();
                foreach (var pr in predators)
                {
                    if (turn % 8 == 0)
                    {
                        Console.WriteLine(pr.GetName() + " has offspring.");
                        pr.Offspring(this); // Pass Tundra instance to Offspring method
                        Console.WriteLine("New population is " + pr.GetCntAnim());
                    }
                }

                foreach (var pre in preys)
                {
                    if (turn % 2 == 0 && (pre.GetSpecies() == "l" || pre.GetSpecies() == "h"))
                    {
                        pre.Offspring();
                        Console.WriteLine(pre.GetName() + " new population: " + pre.GetCntAnim());
                    }
                    if (turn % 4 == 0 && pre.GetSpecies() == "g")
                    {
                        pre.Offspring();
                        Console.WriteLine(pre.GetName() + " new population: " + pre.GetCntAnim());
                    }
                    if (pre.GetCntAnim() < 1)
                    {
                        Console.WriteLine(pre.GetName() + " colony called " + pre.GetName() + " are eliminated");
                        preys.Remove(pre);
                        break;
                    }
                }

                if (preys.Count == 0)
                {
                    Console.WriteLine("all preys are eliminated");
                    endSim = true;
                }
                else
                {
                    foreach (var pr in predators)
                    {
                        int currentPrey = random.Next(preys.Count);
                        preys[currentPrey].gAttacked(pr);

                        if (preys[currentPrey].GetCntAnim() <= 0)
                        {
                            Console.WriteLine(preys[currentPrey].GetSpecies() + " colony called " + preys[currentPrey].GetName() + " are eliminated");
                            preys.RemoveAt(currentPrey);
                        }
                    }

                    EndSim(preys, preyCount);

                    if (preys.Count() == 0)
                    {
                        Console.WriteLine("all preys are eliminated");
                        endSim = true;
                    }
                    foreach (Prey pre in preys)
                    {
                        Console.WriteLine(pre.GetName() + " :" + pre.GetCntAnim());
                    }
                    foreach (Predator pred in predators)
                    {
                        Console.WriteLine(pred.GetName() + " :" + pred.GetCntAnim());
                    }

                    turn++;
                }
            }

            Console.WriteLine("simulation finished");
            Console.WriteLine("remaining colonies");
            Console.WriteLine("Predator Colonies");

            foreach (var pred in predators)
            {
                Console.WriteLine(pred.GetName() + " :" + pred.GetCntAnim());
            }

            Console.WriteLine("Prey Colonies");
            foreach (var pre in preys)
            {
                Console.WriteLine(pre.GetName() + " :" + pre.GetCntAnim());
            }
        }

        public void EndSim(List<Prey> prey, Prey[] preNum)
        {
            bool less = true;
            bool end = true;

            for (int i = 0; i < preys.Count; i++)
            {
                foreach (Prey pre in preNum)
                {
                    if (preys[i].GetName() == pre.GetName())
                    {
                        less = less && (pre.GetCntAnim() * 4 <= preys[i].GetCntAnim());
                    }
                }
            }

            foreach (var p in prey)
            {
                end = end && (p.GetCntAnim() == 0);
            }

            endSim = (end || less);
        }
    }
}
