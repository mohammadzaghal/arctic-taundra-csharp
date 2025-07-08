using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktd421_arcticTundra
{
     public class Colony
    {
        protected string name;
        protected int cnt;
        protected string spec;

        public Colony(string name, string spec, int cnt)
        {
            this.name = name;
            this.cnt = cnt;
            this.spec = spec;
        }
        public string GetName()
        {
            return name;
        }
        public string GetSpecies()
        {
            return spec;
        }
        public int GetCntAnim()
        {
            return cnt;
        }
        public void SetCnt(int sna)
        {
            cnt = sna;
        }

        public virtual void Offspring() { }


    }
}

    


