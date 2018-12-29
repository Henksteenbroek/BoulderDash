using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.StaticObjects
{
    public class Exit : StaticObject
    {
        public char drawChar = 'E';
        public char DrawChar
        {
            get { return drawChar; }
            set { drawChar = value; }
        }

        public MoveableObject moveableObject { get; set; }

        public Exit(MoveableObject moveableObject)
        {
            this.moveableObject = moveableObject;
        }

        public void move(int direction)
        {
            throw new NotImplementedException();
        }
    }
}
