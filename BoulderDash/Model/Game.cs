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
        public int AmountOfPoints { get; set; }
        public List<MoveableObject> moveableObjects { get; set; }
        public List<MoveableObject> tempList { get; set; }

        public Game()
        {
            moveableObjects = new List<MoveableObject>();
            tempList = new List<MoveableObject>();
            AmountOfPoints = 0;
        }
    }
}
