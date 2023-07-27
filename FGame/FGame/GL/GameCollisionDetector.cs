using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGame.GL
{
    public class GameCollisionDetector
    {
        public bool FireWithNinja(MovingObject f)
        {
            bool flag = false;
            //Write your Code Here
            if (f.NextCell().CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
            {
                flag = true;
                f.X = true;
            }
            return flag;
        }
        public bool CoinWithNinja(MovingObject c)
        {
            bool flag = false;
            //Write your Code Here
            if (c.NextCell().CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
            {
                flag = true;
                c.X = true;
            }
            return flag;
        }
        public bool BladeWithArcher(MovingObject f)
        {
            bool flag = false;
            //Write your Code Here
            if (f.NextCell().CurrentGameObject.GameObjectType == GameObjectType.ARCHER)
            {
                flag = true;
                f.X = true;
            }
            return flag;
        }
        public bool BladeWithCanon(MovingObject f)
        {
            bool flag = false;
            //Write your Code Here
            if (f.NextCell().CurrentGameObject.GameObjectType == GameObjectType.CANON)
            {
                flag = true;
                f.X = true;
            }
            return flag;
        }
        public bool BladeWithSnake(MovingObject f)
        {
            bool flag = false;
            //Write your Code Here
            if (f.NextCell().CurrentGameObject.GameObjectType == GameObjectType.SNAKE)
            {
                flag = true;
                f.X = true;
            }
            return flag;
        }
        public bool SnakeWithNinja(Snake snake)
        {
            bool flag = false;
            //Write your Code Here
            if (snake.NextCell().CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
            {
                flag = true;
                snake.X = true;
            }
            return flag;
        }
    }
}
