using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGame.GL
{
    public class Ninja:GameObject
    {
        int health = 100;
        public Ninja(Image img, GameCell startCell) : base(GameObjectType.PLAYER,img)
        {
            this.CurrentCell = startCell;
        }

        public int Health { get => health; set => health = value; }

        public void move(GameCell gameCell)
        {
            CurrentCell = gameCell;
        }
    }
}
