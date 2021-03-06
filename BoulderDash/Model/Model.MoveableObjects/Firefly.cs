﻿using BoulderDash.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.MoveableObjects
{
    public class Firefly : MoveableObject
    {
        public int direction;
        public bool IsDead;

        public Firefly(Game Game) : base(Game)
        {
            DrawChar = '§';
            IsWalkable = false;
            direction = 2;
            Destroyable = true;
            CanExplode = true;
            Supportive = false;
            IsDead = false;
            GivesPoints = false;
        }

        public override bool move()
        {
            Tile target = null;
            if (IsDead)
                return false;

            direction = Turn(direction);

            switch (direction)
            {
                case 1:
                    target = Location.Up;
                    break;
                case 2:
                    target = Location.Left;
                    break;
                case 3:
                    target = Location.Down;
                    break;
                case 4:
                    target = Location.Right;
                    break;
            }

            if (target.StaticObject.IsEmpty && target.StaticObject.moveableObject == null)
            {
                target.StaticObject.moveableObject = this;
                Location.StaticObject.moveableObject = null;
                Location = target;
            }

            if (CheckForRockFord())
            {
                Explode();
                Game.Rockford = null;
                return false;
            }

            return false;
        }

        private int Turn(int direction)
        {
            switch (direction)
            {
                case 1:
                    if (TryLeft())
                        return direction = 2;

                    if (TryUp())
                        return direction;

                    if (TryRight())
                        return direction = 4;

                    if (TryDown())
                        return direction = 3;
                    break;

                case 2:
                    if (TryDown())
                        return direction = 3;

                    if (TryLeft())
                        return direction;

                    if (TryUp())
                        return direction = 1;

                    if (TryRight())
                        return direction = 4;
                    break;

                case 3:
                    if (TryRight())
                        return direction = 4;

                    if (TryDown())
                        return direction;

                    if (TryLeft())
                        return direction = 2;

                    if (TryUp())
                        return direction = 1;
                    break;

                case 4:
                    if (TryUp())
                        return direction = 1;

                    if (TryRight())
                        return direction;

                    if (TryDown())
                        return direction = 3;

                    if (TryLeft())
                        return direction = 2;
                    break;
            }
            return direction;
        }

        private bool TryUp()
        {
            if (Location.Up.StaticObject.IsEmpty && Location.Up.StaticObject.moveableObject == null)
            {
                return true;
            }
            return false;
        }

        private bool TryLeft()
        {
            if (Location.Left.StaticObject.IsEmpty && Location.Left.StaticObject.moveableObject == null)
            {
                return true;
            }
            return false;
        }

        private bool TryDown()
        {
            if (Location.Down.StaticObject.IsEmpty && Location.Down.StaticObject.moveableObject == null)
            {
                return true;
            }
            return false;
        }

        private bool TryRight()
        {
            if (Location.Right.StaticObject.IsEmpty && Location.Right.StaticObject.moveableObject == null)
            {
                return true;
            }
            return false;
        }

        private bool CheckForRockFord()
        {
            if (Location.Up == Game.Rockford?.Location)
                return true;

            if (Location.Left == Game.Rockford?.Location)
                return true;

            if (Location.Down == Game.Rockford?.Location)
                return true;

            if (Location.Right == Game.Rockford?.Location)
                return true;

            return false;
        }

        public override bool Explode()
        {
            IsDead = true;
            Game.AmountOfPoints += 250;
            return base.Explode();
        }
    }
}
