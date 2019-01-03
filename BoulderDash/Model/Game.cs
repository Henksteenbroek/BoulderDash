using BoulderDash.Model.MoveableObjects;
using BoulderDash.Model.StaticObjects;
using BoulderDash.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Controller
{
    public class Game
    {
        public Tile First { get; set; }
        public Tile Last { get; set; }
        public Rockford Rockford { get; set; }

        public Game()
        {

        }

        public void MoveObject(MoveableObject moveableObject, int direction)
        {
            Tile target = null;

            switch (direction)
            {
                case 1:
                    target = moveableObject.Location.Up;
                    break;
                case 2:
                    target = moveableObject.Location.Down;
                    break;
                case 3:
                    target = moveableObject.Location.Left;
                    break;
                case 4:
                    target = moveableObject.Location.Right;
                    break;
            }

            moveableObject.Location.StaticObject.moveableObject = null;
            moveableObject.Location = target;
            target.StaticObject.moveableObject = moveableObject;

        }
    }
}
