using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bae_TexTRPG
{
    public class Archer : Job
    {
        
        public Archer()
        {
            this.hp = 100;
            this.mp = 100;
            this.jobNow = "궁수";
            this.ad = 8;
            this.dp = 5;
            sp = 0;
            skname = " ";
        }

        public override void Skill()
        {
            skname = "강력한 화살";
            sp = 20;
            mp -= 7;
        }

        public override char Icon()
        {
            return '▼';
        }
        
    }
}
