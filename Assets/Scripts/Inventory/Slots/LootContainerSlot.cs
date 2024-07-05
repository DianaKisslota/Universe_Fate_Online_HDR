using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LootContainerSlot : ContainerSlot
{
    protected override bool ItemAccepted(ItemPresenter itemPresenter)
    {
        return false;
    }
}

