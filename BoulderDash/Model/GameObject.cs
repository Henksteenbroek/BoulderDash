using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model.GameObjects
{
    public interface GameObject
    {
        char DrawChar { get; set; }
        void move(int direction);
    }
}
