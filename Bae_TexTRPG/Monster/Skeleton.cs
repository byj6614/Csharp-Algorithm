using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bae_TexTRPG
{
    public class Skeleton : Monster
    {
        
        private int moveCount=0;
        private int count = 0;
        public Skeleton() 
        {
            name = "스켈레톤";
            hp = 1;
            ap = 6;
            dp = 3;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("      .-.");
            sb.AppendLine("     (o.o)");
            sb.AppendLine("      |=|");
            sb.AppendLine("     __ | __");
            sb.AppendLine("   //.=|=.\\");
            sb.AppendLine("  // .=|=. \\");
            image=sb.ToString();
            icon = '♥';
        }
        public override void MoveAction()
        {
            if (moveCount++%2 != 0)
                return;
            if(count==0)
            {
                Move(Direction.Left);
                if (!Data.map[pos.y, pos.x-1])
                    count = 1;
            }
            else
            {
                Move(Direction.Right);
                if (!Data.map[pos.y, pos.x+1])
                    count = 0;
            }
        }
    }
}
