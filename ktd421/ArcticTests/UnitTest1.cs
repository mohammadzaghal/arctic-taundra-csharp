using ktd421_arcticTundra;
namespace ArcticTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSimulationEndsWhenPreyExtinct()
        {
            Tundra tundra = new Tundra();
           
            tundra.preys.Add(new Lemming("Lemmy", 1));  
            tundra.predators.Add(new Owl("Owly", 5));   

            tundra.startSim();

            Assert.IsTrue(tundra.endSim);
            Assert.AreEqual(0, tundra.preys.Count);
        }


        [TestMethod]
        public void TestSimulationEndsWhenPreyQuadruples()
        {
            Tundra tundra = new Tundra();
            tundra.preys.Add(new Lemming("Lemmy", 50)); 
            tundra.predators.Add(new Owl("Owly", 2));  

            tundra.startSim();

            Assert.IsTrue(tundra.endSim);
            Assert.IsTrue(tundra.preys[0].GetCntAnim() >= 200);  
        }

        [TestMethod]
        public void TestMultipleCreatures()
        {
            Tundra tundra = new Tundra();
            tundra.preys.Add(new Lemming("Lemmy", 10));
            tundra.preys.Add(new Hare("Harry", 5));
            tundra.predators.Add(new Owl("Owly", 3));

            Assert.AreEqual(2, tundra.preys.Count);
            Assert.AreEqual(1, tundra.predators.Count);
        }

        [TestMethod]
        public void TestTotalPreyCount()
        {
            Tundra tundra = new Tundra();
            tundra.preys.Add(new Lemming("Lemmy", 50));
            tundra.preys.Add(new Hare("Harry", 20));

            int totalPreyCount = tundra.TotalPreyCount();

            Assert.AreEqual(70, totalPreyCount);
        }

        [TestMethod]
        public void TestTotalPredatorCount()
        {
            Tundra tundra = new Tundra();
            tundra.predators.Add(new Owl("Owly", 5));
            tundra.predators.Add(new Fox("Foxy", 15));

            int totalPredatorCount = tundra.TotalPredatorCount();

            Assert.AreEqual(20, totalPredatorCount);
        }
        [TestMethod]
        public void TestPredatorOffspring()
        {
            Tundra tundra = new Tundra();
            var owl = new Owl("Owly", 4);
            tundra.predators.Add(owl);
            tundra.preys.Add(new Lemming("Lemmy", 50));

            owl.Offspring(tundra);
            Assert.AreEqual(6, owl.GetCntAnim()); 
        }

        [TestMethod]
        public void TestLemmingReproduction()
        {
          
            Tundra tundra = new Tundra();
            var lemming = new Lemming("Lemmy", 10);  
            tundra.preys.Add(lemming);

            tundra.startSim();

            Assert.IsTrue(lemming.GetCntAnim() > 10);
        }

    }
}