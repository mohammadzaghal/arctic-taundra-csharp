using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktd421_arcticTundra
{
    public abstract class Predator : Colony
    {
        public Predator(string name, string spec, int cnt) : base(name, spec, cnt) { }
        public abstract void AttackLemming(Lemming l);
        public abstract void AttackHare(Hare h);
        public abstract void AttackGopher(Gopher g);
        public abstract void Offspring(Tundra tundra);
    }

    public class Owl : Predator
    { 
        public Owl(string name, int cnt) : base(name, "o", cnt) { }

        public override void AttackGopher(Gopher g)
        {
            if (g.GetCntAnim() >= (2 * cnt))
            {
                int n = g.GetCntAnim() - (2 * cnt);
                g.SetCnt(n);
            }
            else
            {
                cnt = (cnt - (cnt - GetCntAnim()) / 2);
                g.SetCnt(0);
            }
        }

        public override void AttackLemming(Lemming l)
        {
            if (l.GetCntAnim() >= (4 * cnt))
            {
                int n = l.GetCntAnim() - (4 * cnt);
                l.SetCnt(n);
            }
            else
            {
                cnt = cnt - (cnt - l.GetCntAnim()) / 4;
                l.SetCnt(0);
            }
        }

        public override void AttackHare(Hare h)
        {
            if (h.GetCntAnim() >= (2 * cnt))
            {
                int n = h.GetCntAnim() - (2 * cnt);
                h.SetCnt(n);
            }
            else
            {
                cnt = cnt - (cnt - h.GetCntAnim()) / 2;
                h.SetCnt(0);
            }
        }

        public override void Offspring(Tundra tundra)
        {
            int totalPrey = tundra.TotalPreyCount();
            int totalPredators = tundra.TotalPredatorCount();
            if (totalPrey > 10 * totalPredators)
            {
                cnt += (2 * (cnt / 4)); // 2 offspring per 4 animals
            }
            else
            {
                cnt += (cnt / 4); // 1 offspring per 4 animals
            }
        }
    }

    public class Fox : Predator
    {
        public Fox(string name, int cnt) : base(name, "f", cnt) { }

        public override void AttackGopher(Gopher g)
        {
            if (g.GetCntAnim() >= (2 * cnt))
            {
                int n = g.GetCntAnim() - (2 * cnt);
                g.SetCnt(n);
            }
            else
            {
                cnt = cnt - ((cnt - g.GetCntAnim()) / 2);
                g.SetCnt(0);
            }
        }

        public override void AttackLemming(Lemming l)
        {
            if (l.GetCntAnim() >= (4 * cnt))
            {
                int n = l.GetCntAnim() - (4 * cnt);
                l.SetCnt(n);
            }
            else
            {
                cnt = cnt - (cnt - l.GetCntAnim()) / 4;
            }
        }

        public override void AttackHare(Hare h)
        {
            if (h.GetCntAnim() >= (2 * cnt))
            {
                int n = h.GetCntAnim() - (2 * cnt);
                h.SetCnt(n);
            }
            else
            {
                cnt = cnt - ((cnt - h.GetCntAnim()) / 2);
                h.SetCnt(0);
            }
        }

        public override void Offspring(Tundra tundra)
        {
            int totalPrey = tundra.TotalPreyCount();
            int totalPredators = tundra.TotalPredatorCount();
            if (totalPrey > 10 * totalPredators)
            {
                cnt += (4 * (cnt / 4)); // 4 offspring per 4 animals
            }
            else
            {
                cnt += 3 * (cnt / 4); // 3 offspring per 4 animals
            }
        }
    }

    class Wolf : Predator
    {
        public Wolf(string name, int cnt) : base(name, "w", cnt) { }

        public override void AttackGopher(Gopher g)
        {
            int n = g.GetCntAnim() - (2 * cnt);
            g.SetCnt(n);
        }

        public override void AttackLemming(Lemming l)
        {
            if (l.GetCntAnim() >= (4 * cnt))
            {
                int n = l.GetCntAnim() - (4 * cnt);
                l.SetCnt(n);
            }
            else
            {
                cnt = cnt - (cnt - l.GetCntAnim()) / 4;
                l.SetCnt(0);
            }
        }

        public override void AttackHare(Hare h)
        {
            if (h.GetCntAnim() >= (2 * cnt))
            {
                int n = h.GetCntAnim() - (2 * cnt);
                h.SetCnt(n);
            }
            else
            {
                cnt = cnt - ((cnt - h.GetCntAnim()) / 2);
                h.SetCnt(0);
            }
        }

        public override void Offspring(Tundra tundra)
        {
            int totalPrey = tundra.TotalPreyCount();
            int totalPredators = tundra.TotalPredatorCount();
            if (totalPrey > 10 * totalPredators)
            {
                cnt += (3 * (cnt / 4)); // 3 offspring per 4 animals
            }
            else
            {
                cnt += 2 * (cnt / 4); // 2 offspring per 4 animals
            }
        }
    }
}
