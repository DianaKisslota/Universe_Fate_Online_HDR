using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine.Rendering;
using UnityEngine;

public class IronOre : Ingridient
{
    public IronOre()
    {
        Name = "Железная руда";
        Description = "Минерал, содержащий железо и его соединения.";
        Weight = 1;
        Volume = 1;
    }
}

