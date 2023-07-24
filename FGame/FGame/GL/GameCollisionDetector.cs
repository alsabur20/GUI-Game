using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGame.GL
{
    public class GameCollisionDetector
    {
        public bool fireWithNinja(Fire f)
        {
            bool flag = false;
            //Write your Code Here
            if (f.CurrentCell.CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
            {
                flag = true;
                f.X = true;
            }
            return flag;
        }
        public bool snakeWithNinja(Snake snake)
        {
            bool flag = false;
            //Write your Code Here
            if (snake.CurrentCell.CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
            {
                flag = true;
                snake.X = true;
            }
            return flag;
        }
    }
}
