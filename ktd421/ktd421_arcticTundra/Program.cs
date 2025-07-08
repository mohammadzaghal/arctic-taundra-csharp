using TextFile;

namespace ktd421_arcticTundra
{
    class Program
    {
        class NoPredatorException : Exception { }

        static void Main(string[] args)
        {
           try 
           {
                Tundra tundra = new Tundra();
                Console.Write("enter filename: ");
                var filename = Console.ReadLine();
    
                TextFileReader reader = new(filename);
                string str = reader.ReadLine();
                string[] xox = str.Split(new char[] { ' ' });

                if (int.Parse(xox[1]) < 1)
                { 
                    throw new NoPredatorException();
                }

                int ColoniesNum = int.Parse(xox[0]) + int.Parse(xox[1]);

                for (int i = 0; i < ColoniesNum; i++)
                {
                    str = reader.ReadLine();
                    xox = str.Split(new char[] { ' ' });

                    switch (xox[1])
                    {
                        case "l":
                            tundra.preys.Add(new Lemming(xox[0], int.Parse(xox[2])));
                            break;
                        case "f":
                            tundra.predators.Add(new Fox(xox[0], int.Parse(xox[2])));
                            break;
                        case "o":
                            tundra.predators.Add(new Owl(xox[0], int.Parse(xox[2])));
                            break;
                        case "w":
                            tundra.predators.Add(new Wolf(xox[0], int.Parse(xox[2])));
                            break;
                        case "g":
                            tundra.preys.Add(new Gopher(xox[0], int.Parse(xox[2])));
                            break;
                        case "h":
                            tundra.preys.Add(new Hare(xox[0], int.Parse(xox[2])));
                            break;
                        default:
                            break;
                    }
                }
                while (!tundra.endSim)
                {
                    tundra.startSim();
                }
                Console.WriteLine("simulation finished");
           }
            catch (FileNotFoundException) 
           { 
                Console.WriteLine("file not found");
           }
            catch (NoPredatorException) 
           { 
                Console.WriteLine("invalid input.. no predator"); 
           }
        }
    }

}
