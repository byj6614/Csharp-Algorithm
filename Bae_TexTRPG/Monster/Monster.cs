using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bae_TexTRPG
{
    public abstract class Monster
    {
        public Position pos;
        public string image;
        public int hp;
        public int ap;
        public int dp;
        public char icon;
        public string name;
        public abstract void MoveAction();

        public void Move(Direction dir)
        {
            Position prevPos = pos;

            switch (dir)
            {
                case Direction.Up:
                    pos.y--;
                    break;
                case Direction.Down:
                    pos.y++;
                    break;
                case Direction.Left:
                    pos.x--;
                    break;
                case Direction.Right:
                    pos.x++;
                    break;
            }
            if (!Data.map[pos.y, pos.x])
            {
                pos=prevPos;
            }
        }
    }
}
