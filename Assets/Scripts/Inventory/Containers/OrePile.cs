﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class OrePile : SmallContainer
{
    public OrePile()
    {
        DeleteOnEmpty = true;
    }
}
