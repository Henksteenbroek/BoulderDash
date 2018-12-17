using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.GameObjects
{
    public class Mud : GameObject
    {
        public char drawChar = 'M';
        public char DrawChar
        {
            get { return drawChar; }
            set { drawChar = value; }
        }
    }
}
