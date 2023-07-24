using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGame.GL
{
    public class LeftCanon:GameObject
    {
        public LeftCanon(Image img,GameCell startCell) : base(GameObjectType.CANON,img)
        {
            this.CurrentCell= startCell;
        }
    }
}
