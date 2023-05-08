using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bae_TexTRPG
{
    public class Knight : Job
    {
       
        public Knight() 
        {
            this.hp = 150;
            this.mp = 50;
            this.jobNow = "기사";
            this.ad = 5;
            this.dp = 8;
            sp = 0;
            skname = " ";
        }

        public override void Skill()
        {
            skname = "강타";
            sp = 15;
            mp -= 5;
        }

        public override char Icon()
        {
            return '◆';
        }

    }
}
