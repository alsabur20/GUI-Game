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
        Random enemy = new Random();
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
            ninjaHealth.Text = game.GetHealth().ToString();
            progressBar1.Value = game.GetHealth();
            archerHealth.Text = game.ArcherHealth().ToString();
            progressBar2.Value = game.ArcherHealth();
            canonHealth.Text = game.CanonHealth().ToString();
            progressBar3.Value = game.CanonHealth();
            snakeHealth.Text = game.SnakeHealth().ToString();
            progressBar4.Value = game.SnakeHealth();
            score.Text = game.Score.ToString();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = enemy.Next(0, 100);
            GenerateEnemy(i);
            ShowHealth();
            game.RemoveCoin();
            game.RemoveFire();
            game.RemoveSnakes();
            TakeKeyInput();
            MoveNinja();
            MoveFire();
            MoveCoins();
            MoveSnake();
            if (game.Score == 500)
            {
                timer1.Enabled = false;
                this.Hide();
                MessageBox.Show("Congratulations 🥳 !!!! You have won the game.");
                Application.Exit();
            }
            if (game.GetHealth() == 0)
            {
                timer1.Enabled = false;
                this.Hide();
                MessageBox.Show("OOPS 🥺 !!! You lost the game.");
                Application.Exit();
            }
        }
        private void GenerateEnemy(int i)
        {
            if (i == 30 && game.RightCanon == null && game.ArcherHealth() > 0)
            {
                game.RightArcher = game.GenerateRightArcher();
            }
            else if (i == 40 && game.LeftArcher == null && game.CanonHealth() > 0)
            {
                game.LeftCanon = game.GenerateLeftCanon();
            }
            else if (i == 20 && game.SnakeHealth() > 0)
            {
                if (game.LeftCanon == null && game.LeftArcher == null)
                    game.GenerateLeftSnake();
            }
            else if (i == 50 && game.SnakeHealth() > 0)
            {
                if (game.RightCanon == null && game.RightArcher == null)
                    game.GenerateRightSnake();
            }
            else if (i == 70 && game.RightArcher == null && game.CanonHealth() > 0)
            {
                game.RightCanon = game.GenerateRightCanon();
            }
            else if (i == 80 && game.LeftCanon == null && game.ArcherHealth() > 0)
            {
                game.LeftArcher = game.GenerateLeftArcher();
            }
            else if (i == 10 && game.RightArcher == null && game.RightCanon == null)
            {
                game.GenerateRightCoin();
            }
            else if (i == 25 && game.LeftArcher == null && game.LeftCanon == null)
            {
                game.GenerateLeftCoin();
                game.GenerateLeftCoin();
                game.GenerateLeftCoin();
            }
            if (game.RightArcher != null)
            {
                if (game.RightArcher.IsPresent)
                {
                    int j = enemy.Next(0, 100);
                    if (j == 10 || j == 50 || j == 100)
                    {
                        game.GenerateRightArrow();
                    }
                    if (j == 70)
                    {
                        game.RightArcher.IsPresent = false;
                        GameCell c = game.RightArcher.CurrentCell;
                        game.RightArcher = null;
                        c.SetGameObject(Game.GetBlankGameObject());
                    }

                }
            }
            if (game.LeftArcher != null)
            {
                if (game.LeftArcher.IsPresent)
                {
                    int j = enemy.Next(0, 100);
                    if (j == 10 || j == 50 || j == 100)
                    {
                        game.GenerateLeftArrow();
                    }
                    if (j == 70)
                    {
                        game.LeftArcher.IsPresent = false;
                        GameCell c = game.LeftArcher.CurrentCell;
                        game.LeftArcher = null;
                        c.SetGameObject(Game.GetBlankGameObject());
                    }
                }
            }
            if (game.LeftCanon != null)
            {
                if (game.LeftCanon.IsPresent)
                {
                    int j = enemy.Next(0, 100);
                    if (j == 10 || j == 50 || j == 100)
                    {
                        game.GenerateLeftFire();
                    }
                    if (j == 70)
                    {
                        game.LeftCanon.IsPresent = false;
                        GameCell c = game.LeftCanon.CurrentCell;
                        game.LeftCanon = null;
                        c.SetGameObject(Game.GetBlankGameObject());
                    }
                }
            }
            if (game.RightCanon != null)
            {
                if (game.RightCanon.IsPresent)
                {
                    int j = enemy.Next(0, 100);
                    if (j == 10 || j == 50 || j == 100)
                    {
                        game.GenerateRightFire();
                    }
                    if (j == 70)
                    {
                        game.RightCanon.IsPresent = false;
                        GameCell c = game.RightCanon.CurrentCell;
                        game.RightCanon = null;
                        c.SetGameObject(Game.GetBlankGameObject());
                    }
                }
            }
        }
        private void TakeKeyInput()
        {
            Ninja ninja = game.GetNinja();
            GameCell potentialNewCell = ninja.CurrentCell;
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                if (moveStatus == 's')
                    moveStatus = 'l';
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                if (moveStatus == 's')
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
            if (Keyboard.IsKeyPressed(Key.A))
            {
            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                GameCell nCell = ninja.CurrentCell.NextCell(GameDirection.UP);
                MovingObject f = new MovingObject(FGame.Properties.Resources.blade, nCell, GameDirection.UP);
                game.AddFire(f);
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
                    game.DecreaseNinjaHealth();
                }
                s.Move(s.NextCell());
            }
        }
        private void MoveFire()
        {
            foreach (MovingObject f in game.Fires)
            {
                if (collider.FireWithNinja(f))
                {
                    game.DecreaseNinjaHealth();
                }
                if (collider.BladeWithArcher(f))
                {
                    game.DecreaseArcherHealth();
                }
                if (collider.BladeWithCanon(f))
                {
                    game.DecreaseCanonHealth();
                }
                if (collider.BladeWithSnake(f))
                {
                    game.DecreaseSnakeHealth();
                }
                f.Move(f.NextCell());
            }
        }
        private void MoveCoins()
        {
            foreach (MovingObject c in game.Coins)
            {
                if (collider.CoinWithNinja(c))
                {
                    game.Score += 5;
                }
                c.Move(c.NextCell());
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}