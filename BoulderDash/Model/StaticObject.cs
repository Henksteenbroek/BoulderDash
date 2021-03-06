﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Model
{
    public interface StaticObject
    {
        MoveableObject moveableObject { get; set; }
        char DrawChar { get; set; }
        bool IsWalkable { get; }
        bool IsEmpty { get; }
        bool Supportive { get; }
        bool Destroyable { get; }
    }
}
