using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bae_TexTRPG
{
    public class InventoryScene : Scene
    {
        public InventoryScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            Console.WriteLine("나약한 물약 : {0}");
            Console.WriteLine("쓸만한 물약 : {0}");
            Console.WriteLine("희귀한 물약 : {0}");
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
