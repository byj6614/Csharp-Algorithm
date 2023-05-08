using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bae_TexTRPG
{
    public abstract class Job
    {
        public int hp;
        public int mp;
        public int ad;
        public int dp;
        public int sp;
        public string skname;
        public string jobNow;
        public abstract char Icon();
        public abstract void Skill();
    }
}
