using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace FGame.GL
{
    public class Game
    {
        GameGrid grid;
        Form gameGUI;
        int archerHealth = 100;
        int canonHealth = 100;
        int snakeHealth = 100;
        int score = 0;
        Ninja ninja;
        LeftCanon leftCanon;
        RightCanon rightCanon;
        LeftArcher leftArcher;
        RightArcher rightArcher;
        List<MovingObject> fires;
        List<MovingObject> coins;
        List<Snake> snakes;

        public LeftCanon LeftCanon { get => leftCanon; set => leftCanon = value; }
        public GameGrid Grid { get => grid; set => grid = value; }
        public List<Snake> Snakes { get => snakes; set => snakes = value; }
        public List<MovingObject> Fires { get => fires; set => fires = value; }
        public RightCanon RightCanon { get => rightCanon; set => rightCanon = value; }
        public LeftArcher LeftArcher { get => leftArcher; set => leftArcher = value; }
        public RightArcher RightArcher { get => rightArcher; set => rightArcher = value; }
        public int ArcherHealth()
        {
            if (archerHealth > 0)
                return archerHealth;
            else return 0;
        }
        public int CanonHealth()
        {
            if (canonHealth > 0)
                return canonHealth;
            else return 0;
        }
        public int SnakeHealth()
        {
            if (snakeHealth > 0)
                return snakeHealth;
            else return 0;
        }
        public Ninja Ninja { get => ninja; set => ninja = value; }
        public List<MovingObject> Coins { get => coins; set => coins = value; }
        public int Score { get => score; set => score = value; }

        public Game(Form gameGUI)
        {
            this.gameGUI = gameGUI;
            Grid = new GameGrid(30, 29);
            Ninja = GenerateNinja();
            Coins = new List<MovingObject>();
            Fires = new List<MovingObject>();
            Snakes = new List<Snake>();
            PrintMaze(Grid);
        }
        public void GenerateLeftCoin()
        {
            MovingObject lC = new MovingObject(FGame.Properties.Resources.coin, Grid.getCell(02, 02), GameDirection.DOWN);
            AddCoin(lC);
        }
        public void GenerateRightCoin()
        {
            MovingObject rC = new MovingObject(FGame.Properties.Resources.coin, Grid.getCell(02, 26), GameDirection.DOWN);
            AddCoin(rC);
        }
        public LeftArcher GenerateLeftArcher()
        {
            LeftArcher lA = new LeftArcher(FGame.Properties.Resources.archerLeft, Grid.getCell(02, 02));
            lA.IsPresent = true;
            return lA;
        }
        public void GenerateLeftArrow()
        {
            GameCell nCell = LeftArcher.CurrentCell.NextCell(GameDirection.DOWN);
            MovingObject f = new MovingObject(FGame.Properties.Resources.arrow, nCell, GameDirection.DOWN);
            AddFire(f);
        }
        public RightArcher GenerateRightArcher()
        {
            RightArcher rA = new RightArcher(FGame.Properties.Resources.archerRight, Grid.getCell(02, 26));
            rA.IsPresent = true;
            return rA;
        }
        public void GenerateRightArrow()
        {
            GameCell nCell = RightArcher.CurrentCell.NextCell(GameDirection.DOWN);
            MovingObject f = new MovingObject(FGame.Properties.Resources.arrow, nCell, GameDirection.DOWN);
            AddFire(f);
        }
        public LeftCanon GenerateLeftCanon()
        {
            LeftCanon lC = new LeftCanon(FGame.Properties.Resources.leftCanon, Grid.getCell(02, 02));
            lC.IsPresent = true;
            return lC;
        }
        public void GenerateLeftFire()
        {
            GameCell nCell = LeftCanon.CurrentCell.NextCell(GameDirection.DOWN);
            MovingObject f = new MovingObject(FGame.Properties.Resources.cFire, nCell, GameDirection.DOWN);
            AddFire(f);
        }
        public RightCanon GenerateRightCanon()
        {
            RightCanon rC = new RightCanon(FGame.Properties.Resources.rightCanon, Grid.getCell(02, 26));
            rC.IsPresent = true;
            return rC;
        }
        public void GenerateRightFire()
        {
            GameCell nCell = RightCanon.CurrentCell.NextCell(GameDirection.DOWN);
            MovingObject f = new MovingObject(FGame.Properties.Resources.cFire, nCell, GameDirection.DOWN);
            AddFire(f);
        }
        public Ninja GenerateNinja()
        {
            Ninja n = new Ninja(FGame.Properties.Resources.ninja, Grid.getCell(28, 26));
            n.IsPresent = true;
            return n;
        }
        public void GenerateLeftSnake()
        {
            Snake lS = new Snake(FGame.Properties.Resources.snake, Grid.getCell(02, 02));
            lS.IsPresent = true;
            AddSnake(lS);
        }
        public void GenerateRightSnake()
        {
            Snake rS = new Snake(FGame.Properties.Resources.snake, Grid.getCell(02, 26));
            rS.IsPresent = true;
            AddSnake(rS);
        }
        public void RemoveFire()
        {
            for (int i = 0; i < fires.Count; i++)
            {
                if (fires[i].X)
                {
                    fires[i].CurrentCell.SetGameObject(GetBlankGameObject());
                    fires.Remove(fires[i]);
                }
            }
        }
        public void RemoveCoin()
        {
            for (int i = 0; i < coins.Count; i++)
            {
                if (coins[i].X)
                {
                    coins[i].CurrentCell.SetGameObject(GetBlankGameObject());
                    coins.Remove(coins[i]);
                }
            }
        }
        public void RemoveSnakes()
        {
            for (int i = 0; i < snakes.Count; i++)
            {
                if (Snakes[i].X)
                {
                    Snakes[i].CurrentCell.SetGameObject(GetBlankGameObject());
                    Snakes.Remove(Snakes[i]);
                }
            }
        }
        public int GetHealth()
        {
            if (ninja.Health > 0)
            {
                return Ninja.Health;
            }
            else return 0;
        }
        public GameCell GetCell(int x, int y)
        {
            return Grid.getCell(x, y);
        }
        public Ninja GetNinja()
        {
            return this.Ninja;
        }
        public void AddFire(MovingObject f)
        {
            fires.Add(f);
        }
        public void AddSnake(Snake s)
        {
            Snakes.Add(s);
        }
        public void AddCoin(MovingObject c)
        {
            Coins.Add(c);
        }
        public void DecreaseNinjaHealth()
        {
            Ninja.Health -= 5;
        }
        public void DecreaseArcherHealth()
        {
            archerHealth -= 5;
        }
        public void DecreaseCanonHealth()
        {
            canonHealth -= 5;
        }
        public void DecreaseSnakeHealth()
        {
            snakeHealth -= 5;
        }
        void PrintMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {

                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    gameGUI.Controls.Add(cell.PictureBox);
                }

            }
        }

        public static GameObject GetBlankGameObject()
        {
            GameObject blankGameObject = new GameObject(GameObjectType.NONE, FGame.Properties.Resources.none);
            return blankGameObject;
        }


        public static Image GetGameObjectImage(char displayCharacter)
        {
            Image img = FGame.Properties.Resources.none;
            if (displayCharacter == '|')
            {
                img = FGame.Properties.Resources.wall1;
            }
            return img;
        }

    }
}
