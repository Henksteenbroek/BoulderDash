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
        public List<MoveableObject> moveableObjects;

        public Game()
        {
            moveableObjects = new List<MoveableObject>();
        }
    }
}
