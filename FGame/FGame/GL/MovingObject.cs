using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGame.GL
{
    public class MovingObject : GameObject
    {
        GameDirection dir;
        bool x = false;

        public MovingObject(Image image, GameCell startCell, GameDirection dir) : base(GameObjectType.FIRE, image)
        {
            base.CurrentCell = startCell;
            this.dir = dir;
        }

        public bool X { get => x; set => x = value; }

        public void Move(GameCell gameCell)
        {
            if (this.CurrentCell != null)
            {
                this.CurrentCell.SetGameObject(Game.GetBlankGameObject());
            }
            CurrentCell = gameCell;
        }
        public GameCell NextCell()
        {

            GameCell currentCell = this.CurrentCell;

            GameCell nextCell = this.CurrentCell.NextCell(dir);

            if (nextCell == currentCell)
            {
                x = true;
            }
            else
            {
                currentCell = nextCell;
            }
            return currentCell;

        }
    }
}
