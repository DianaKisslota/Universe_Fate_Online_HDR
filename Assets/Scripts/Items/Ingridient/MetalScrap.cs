using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MetalScrap : Ingridient
{
    public MetalScrap()
    {
        Name = "Металлолом";
        Description = "Лом черных металлов. Умелый мастер может дать ему вторую жизнь.";
        Weight = 1;
        Volume = 0.5f;
    }
}

