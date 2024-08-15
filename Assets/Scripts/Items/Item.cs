using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Item
{
    public string Name {  get; set; }
    public string Description { get; set; }
    public float Weight {  get; set; }
    public float Volume {  get; set; }
    public bool Stackable => !(this is Weapon);

    public virtual ItemTemplate GetTemplate()
    {
        return new ItemTemplate() { ItemType = this.GetType() };
    }
}

