using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktd421_arcticTundra
{
     public abstract class Prey : Colony
    {
        public Prey(string name, string spec, int cnt) : base(name, spec, cnt) { }
        public virtual bool AboveLimit() { return false; }
        public abstract void NewCnt();
        public abstract void gAttacked(Predator predator);

    }
    public class Lemming : Prey
    {
        public Lemming(string name, int cnt) : base(name, "l", cnt) { }
        public override bool AboveLimit()
        {
            return cnt > 200;
        }

        public override void gAttacked(Predator predator)
        {
            predator.AttackLemming(this);
        }

        public override void NewCnt()
        {
            cnt = 30;
        }

        public override void Offspring()
        {
            cnt = cnt * 2;
        }

    }
    public class Hare : Prey
    {
        public Hare(string name, int cnt) : base(name, "h", cnt) { }
        public override bool AboveLimit()
        {
            return cnt > 100;
        }

        public override void gAttacked(Predator predator)
        {
            predator.AttackHare(this);
        }

        public override void NewCnt()
        {
            cnt = 20;
        }
        public override void Offspring()
        {
            cnt += cnt / 2 + cnt % 2;

        }
    }

    public class Gopher : Prey
    {
        public Gopher(string name, int cnt) : base(name, "g", cnt) { }
        public override bool AboveLimit()
        {
            return cnt > 200;
        }

        public override void gAttacked(Predator predator)
        {
            predator.AttackGopher(this);
        }

        public override void NewCnt()
        {
            cnt = 40;
        }
        public override void Offspring()
        {
            cnt = cnt * 2;
        }
    }
}

