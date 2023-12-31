﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FGame.GL
{
    public class LeftArcher : GameObject
    {
        private int health = 100;
        public LeftArcher(Image img, GameCell startCell) : base(GameObjectType.ARCHER, img)
        {
            this.CurrentCell = startCell;
        }

        public int Health { get => health; set => health = value; }
    }
}
