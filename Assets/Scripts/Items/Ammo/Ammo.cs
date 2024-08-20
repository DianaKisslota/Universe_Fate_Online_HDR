using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Caliber
{
    bullet9x18,
    bullet545x39,
    bullet762x39,
    bullet045ACP
}
public abstract class Ammo : Item
{
    public Caliber Caliber { get; set; }
    public float BaseDamage {  get; set; }
    public float ArmorPiercing {  get; set; }
}

