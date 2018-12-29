using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model
{
    public interface MoveableObject
    {
        bool IsRound { get; set; }
        char DrawChar { get; set; }
        void move(int direction);
    }
}
