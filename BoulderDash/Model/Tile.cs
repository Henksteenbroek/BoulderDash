using BoulderDash.Model.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model
{
    public class Tile
    {
        public GameObject GameObject { get; set; }
        public Tile Left;
        public Tile Right;
        public Tile Up;
        public Tile Down;
        
        public Tile(GameObject gameObject)
        {
            GameObject = gameObject;
        }
    }
}
