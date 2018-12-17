using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.GameObjects
{
    public class Empty : GameObject
    {
        public char drawChar = ' ';
        public char DrawChar
        {
            get { return drawChar; }
            set { drawChar = value; }
        }
    }
}
