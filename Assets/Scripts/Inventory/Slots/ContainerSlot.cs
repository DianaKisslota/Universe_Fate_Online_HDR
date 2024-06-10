using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ContainerSlot : StorageSlot
{
    public float MaxVolume { get; set; }

    public override void OnItemLeave(Item item)
    {
        Storage.RemoveItem(item);
        base.OnItemLeave(item);
    }
}

