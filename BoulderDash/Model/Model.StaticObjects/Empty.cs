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
            get { return drawChar; }
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
