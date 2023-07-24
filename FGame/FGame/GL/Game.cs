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
        Ninja ninja;
        LeftCanon canon;
        List<Fire> cFires;
        List<Snake> snakes;

        public List<Fire> CFires { get => cFires; set => cFires = value; }
        public LeftCanon Canon { get => canon; set => canon = value; }
        public GameGrid Grid { get => grid; set => grid = value; }
        public List<Snake> Snakes { get => snakes; set => snakes = value; }

        public Game(Form gameGUI)
        {
            this.gameGUI = gameGUI;
            Grid = new GameGrid(30, 29);
            ninja = new Ninja(FGame.Properties.Resources.ninja, Grid.getCell(28, 26));
            Canon = new LeftCanon(FGame.Properties.Resources.leftCanon, Grid.getCell(03, 2));
            CFires = new List<Fire>();
            Snakes = new List<Snake>();
            printMaze(Grid);
        }
        public void RemoveFire()
        {
            for (int i = 0; i < CFires.Count; i++)
            {
                if (cFires[i].X)
                {
                    CFires[i].CurrentCell.setGameObject(getBlankGameObject());
                    cFires.Remove(cFires[i]);
                }
            }
        }
        public void RemoveSnakes()
        {
            for (int i = 0; i < snakes.Count; i++)
            {
                if (Snakes[i].X)
                {
                    Snakes[i].CurrentCell.setGameObject(getBlankGameObject());
                    Snakes.Remove(Snakes[i]);
                }
            }
        }
        public int getHealth()
        {
            return ninja.Health;
        }
        public GameCell getCell(int x, int y)
        {
            return Grid.getCell(x, y);
        }
        public Ninja getNinja()
        {
            return this.ninja;
        }
        public void addCanonFire(Fire f)
        {
            CFires.Add(f);
        }
        public void addSnake(Snake s)
        {
            Snakes.Add(s);
        }
        public void decreaseHealth()
        {
            ninja.Health -= 5;
        }
        void printMaze(GameGrid grid)
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

        public static GameObject getBlankGameObject()
        {
            GameObject blankGameObject = new GameObject(GameObjectType.NONE, FGame.Properties.Resources.none);
            return blankGameObject;
        }


        public static Image getGameObjectImage(char displayCharacter)
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
