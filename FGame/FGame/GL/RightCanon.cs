using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace FGame.GL
{
    public class RightCanon : GameObject
    {
        public RightCanon(Image img, GameCell startCell) : base(GameObjectType.CANON, img)
        {
            this.CurrentCell = startCell;
        }
    }
}
