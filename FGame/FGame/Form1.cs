using FGame.GL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;

namespace FGame
{
    public partial class Form1 : Form
    {
        Game game;
        GameCollisionDetector collider;
        char moveStatus = 's';
        public Form1()
        {
            InitializeComponent();
            game = new Game(this);
            collider = new GameCollisionDetector();
        }
        private void ShowHealth()
        {
            health.Text = game.GetHealth().ToString();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            game.RemoveFire();
            game.RemoveSnakes();
            TakeKeyInput();
            MoveNinja();
            MoveFire();
            MoveSnake();
            ShowHealth();
        }
        private void TakeKeyInput()
        {
            Ninja ninja = game.GetNinja();
            LeftCanon canon = game.Canon;
            GameCell potentialNewCell = ninja.CurrentCell;
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                moveStatus = 'l';
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                moveStatus = 'r';
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                potentialNewCell = ninja.CurrentCell.NextCell(GameDirection.UP);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                potentialNewCell = ninja.CurrentCell.NextCell(GameDirection.DOWN);
            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                /* GameCell NewCell = canon.CurrentCell.nextCell(GameDirection.DOWN);
                 Fire f = new Fire(FGame.Properties.Resources.cFire, NewCell);
                 game.addCanonFire(f);*/

                Snake s = new Snake(FGame.Properties.Resources.snake, game.Grid.getCell(3, 26));
                game.AddSnake(s);
            }
            GameCell currentCell = ninja.CurrentCell;
            currentCell.SetGameObject(Game.GetBlankGameObject());
            ninja.Move(potentialNewCell);
        }

        private void MoveNinja()
        {
            Ninja ninja = game.GetNinja();
            GameCell potentialNewCell = ninja.CurrentCell;
            GameCell nextCell;
            if (moveStatus == 'l')
            {
                nextCell = ninja.CurrentCell.NextCell(GameDirection.LEFT);
                if (nextCell != potentialNewCell)
                {
                    GameCell currentCell = ninja.CurrentCell;
                    currentCell.SetGameObject(Game.GetBlankGameObject());
                    ninja.Move(nextCell);
                }
                else
                {
                    moveStatus = 's';
                }
            }
            if (moveStatus == 'r')
            {
                nextCell = ninja.CurrentCell.NextCell(GameDirection.RIGHT);
                if (nextCell != potentialNewCell)
                {
                    GameCell currentCell = ninja.CurrentCell;
                    currentCell.SetGameObject(Game.GetBlankGameObject());
                    ninja.Move(nextCell);
                }
                else
                {
                    moveStatus = 's';
                }
            }
        }
        private void MoveSnake()
        {
            foreach (Snake s in game.Snakes)
            {
                if (collider.SnakeWithNinja(s))
                {
                    game.DecreaseHealth();
                }
                s.Move(s.NextCell());
            }
        }
        private void MoveFire()
        {
            foreach (Fire f in game.CFires)
            {
                if (collider.FireWithNinja(f))
                {
                    game.DecreaseHealth();
                }
                f.Move(f.NextCell());
            }
        }
    }
}
