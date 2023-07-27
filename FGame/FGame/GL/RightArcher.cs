using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace FGame.GL
{
    public class RightArcher : GameObject
    {
        private int health = 100;
        public RightArcher(Image img, GameCell startCell) : base(GameObjectType.ARCHER, img)
        {
            this.CurrentCell = startCell;
        }

        public int Health { get => health; set => health = value; }
    }
}
