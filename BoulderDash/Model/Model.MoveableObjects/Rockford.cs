﻿using BoulderDash.Controller;
using BoulderDash.Model.StaticObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class Rockford : MoveableObject
    {

        public Rockford(Game Game) : base(Game)
        {
            DrawChar = 'R';
            Destroyable = true;
            CanExplode = true;
            GivesPoints = false;
            Supportive = false;
        }

        public override bool move(int direction)
        {
            Tile target = null;

            switch (direction)
            {
                case 1:
                    target = Location.Up;
                    break;
                case 2:
                    target = Location.Down;
                    break;
                case 3:
                    target = Location.Left;
                    break;
                case 4:
                    target = Location.Right;
                    break;
                default:
                    return false;
            }

            if (target == Game.Exit.Location)
            {
                if (Game.Exit.IsActive)
                    finalizeMove(target, false);


                return true;
            }

            if (target.StaticObject.moveableObject?.IsPushable == true)
            {
                if (target.StaticObject.moveableObject.move(direction))
                {
                    return finalizeMove(target, true);
                }
                return false;
            }

            if (target.StaticObject.moveableObject?.IsWalkable == false)
            {
                target.StaticObject.moveableObject?.move(direction);
                return false;
            }

            if (target.StaticObject.IsWalkable)
            {
                return finalizeMove(target, false);
            }

            return false;
        }

        public bool finalizeMove(Tile target, bool IsPushable)
        {
            if (!IsPushable)
                Game.tempList.Remove(target.StaticObject.moveableObject);

            if (target.StaticObject.moveableObject?.GivesPoints == true)
                Game.AmountOfPoints += 10;

            target.StaticObject.moveableObject = this;
            Location.StaticObject.moveableObject = null;
            Location.StaticObject = new Empty(null);
            Location = target;
            return true;
        }

        public override bool Explode()
        {
            Game.Rockford = null;
            return base.Explode();
        }
    }
}

