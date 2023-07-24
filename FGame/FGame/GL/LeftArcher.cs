using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace FGame.GL
{
    public class LeftArcher : GameObject
    {
        public LeftArcher(Image img, GameCell startCell) : base(GameObjectType.ARCHER, img)
        {
            this.CurrentCell = startCell;
        }

    }
}
