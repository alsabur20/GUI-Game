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
        private void showHealth()
        {
            health.Text = game.getHealth().ToString();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            game.RemoveFire();
            game.RemoveSnakes();
            TakeKeyInput();
            MoveNinja();
            moveFire();
            moveSnake();
            showHealth();
        }
        private void TakeKeyInput()
        {
            Ninja ninja = game.getNinja();
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
                potentialNewCell = ninja.CurrentCell.nextCell(GameDirection.UP);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                potentialNewCell = ninja.CurrentCell.nextCell(GameDirection.DOWN);
            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                /* GameCell NewCell = canon.CurrentCell.nextCell(GameDirection.DOWN);
                 Fire f = new Fire(FGame.Properties.Resources.cFire, NewCell);
                 game.addCanonFire(f);*/

                Snake s = new Snake(FGame.Properties.Resources.snake, game.Grid.getCell(3, 26));
                game.addSnake(s);
            }
            GameCell currentCell = ninja.CurrentCell;
            currentCell.setGameObject(Game.getBlankGameObject());
            ninja.move(potentialNewCell);
        }

        private void MoveNinja()
        {
            Ninja ninja = game.getNinja();
            GameCell potentialNewCell = ninja.CurrentCell;
            GameCell nextCell;
            if (moveStatus == 'l')
            {
                nextCell = ninja.CurrentCell.nextCell(GameDirection.LEFT);
                if (nextCell != potentialNewCell)
                {
                    GameCell currentCell = ninja.CurrentCell;
                    currentCell.setGameObject(Game.getBlankGameObject());
                    ninja.move(nextCell);
                }
                else
                {
                    moveStatus = 's';
                }
            }
            if (moveStatus == 'r')
            {
                nextCell = ninja.CurrentCell.nextCell(GameDirection.RIGHT);
                if (nextCell != potentialNewCell)
                {
                    GameCell currentCell = ninja.CurrentCell;
                    currentCell.setGameObject(Game.getBlankGameObject());
                    ninja.move(nextCell);
                }
                else
                {
                    moveStatus = 's';
                }
            }
        }
        private void moveSnake()
        {
            foreach (Snake s in game.Snakes)
            {
                if (collider.snakeWithNinja(s))
                {
                    game.decreaseHealth();
                }
                s.move(s.nextCell());
            }
        }
        private void moveFire()
        {
            foreach (Fire f in game.CFires)
            {
                if (collider.fireWithNinja(f))
                {
                    game.decreaseHealth();
                }
                f.move(f.nextCell());
            }
        }
    }
}
