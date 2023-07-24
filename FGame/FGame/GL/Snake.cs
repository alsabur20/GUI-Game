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

        public void move(GameCell gameCell)
        {
            if (this.CurrentCell != null)
            {
                this.CurrentCell.setGameObject(Game.getBlankGameObject());

            }
            CurrentCell = gameCell;
        }
        public GameCell nextCell()
        {

            GameCell currentCell = this.CurrentCell;

            GameCell nextCell = this.CurrentCell.nextCell(dir);

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
