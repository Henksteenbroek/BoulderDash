﻿using BoulderDash.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class Explosive : MoveableObject
    {
        public Explosive(Game game) : base(game)
        {
            DrawChar = 'X';
        }

        public override void move()
        {
            //Tile target = Location.Right;

            //target.StaticObject.moveableObject = this;
            //Location.StaticObject.moveableObject = null;
            //Location = target;
        }
    }
}
