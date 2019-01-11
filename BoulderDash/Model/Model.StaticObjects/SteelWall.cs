using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.StaticObjects
{
    public class SteelWall : StaticObject
    {
        public char drawChar = 'S';
        public char DrawChar
        {
            get
            {
                if (moveableObject == null)
                {
                    return drawChar;
                }
                else return moveableObject.DrawChar;
            }
            set { drawChar = value; }
        }

        public MoveableObject moveableObject { get; set; }
        public bool IsWalkable { get { return false; } }
        public bool IsEmpty { get { return false; } }
        public bool Destroyable { get { return false; } }
        public bool Supportive { get { return false; } }

        public SteelWall(MoveableObject moveableObject)
        {
            this.moveableObject = moveableObject;
        }

        public void move(int direction)
        {
            throw new NotImplementedException();
        }
    }
}
