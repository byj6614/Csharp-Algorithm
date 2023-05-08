using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bae_TexTRPG
{
    public class Slime : Monster
    {
        public Slime()
        {
            name = "슬라임";
            this.hp = 10;
            this.ap = 3;
            this.dp = 3;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("        ██████████        ");
            sb.AppendLine("    ████▒▒▒▒░░░░░░████    ");
            sb.AppendLine("  ██▒▒▒▒░░░░░░      ░░██  ");
            sb.AppendLine("  ██▒▒▒▒░░░░░░░░    ░░██  ");
            sb.AppendLine("██▒▒▒▒▒▒░░░░░░░░░░░░░░▒▒██");
            sb.AppendLine("██▒▒▒▒▒▒▒▒▒▒░░░░░░░░▒▒▒▒██");
            sb.AppendLine("  ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██  ");
            sb.AppendLine("    ██████████████████    ");
            image=sb.ToString();
            icon = '♣';
        }
        private int moveCount=0;
        
        public override void MoveAction()
        {
            if (moveCount++%3 != 0)
                return;
            Random random = new Random();
            switch(random.Next(0,4)) 
            {
                case 0:
                    Move(Direction.Up); break;
                case 1:
                    Move(Direction.Down); break;
                case 2:
                    Move(Direction.Left); break;
                case 3:
                    Move(Direction.Right); break;
            }
        }
    }
}
