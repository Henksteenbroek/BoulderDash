using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.StaticObjects
{
    public class Mud : StaticObject
    {
        public char drawChar = '.';
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
        public bool IsWalkable { get { return true; } }
        public bool IsEmpty { get { return false; } }

        public Mud(MoveableObject moveableObject)
        {
            this.moveableObject = moveableObject;
        }

        public void move(int direction)
        {
            throw new NotImplementedException();
        }
    }
}
