using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bae_TexTRPG
{
    public class Mage : Job
    {
        
        public Mage()
        {
            this.hp = 80;
            this.mp = 130;
            this.jobNow = "마법사";
            this.ad = 10;
            this.dp = 3;
            sp = 0;
            skname = " ";
        }

        public override void Skill()
        {
            skname = "파이어볼";
            sp = 25;
            mp -= 13;
        }

        public override char Icon()
        {
            return '★'; 
        }
    }
}
