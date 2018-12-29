using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.GameObjects
{
    public class Wall : StaticObject
    {
        public char drawChar = 'W';
        public char DrawChar
        {
            get { return drawChar; }
            set { drawChar = value; }
        }

        public void move(int direction)
        {
            throw new NotImplementedException();
        }
    }
}
