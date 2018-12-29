using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.StaticObjects
{
    public class Empty : StaticObject
    {
        public char drawChar = ' ';
        public char DrawChar
        {
            get { if (moveableObject == null)
                {
                    return drawChar;
                }
                else return moveableObject.DrawChar;
            }
            set { drawChar = value; }
        }

        public MoveableObject moveableObject { get; set; }

        public Empty(MoveableObject moveableObject)
        {
            this.moveableObject = moveableObject;
        }

        public void move(int direction)
        {
            throw new NotImplementedException();
        }
    }
}
