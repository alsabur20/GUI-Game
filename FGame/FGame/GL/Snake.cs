using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGame.GL
{
    public class Snake : GameObject
    {
        GameDirection dir = GameDirection.DOWN;
        bool x = false;
        public Snake(Image img, GameCell startCell) : base(GameObjectType.SNAKE, img)
        {
            this.CurrentCell = startCell;
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
