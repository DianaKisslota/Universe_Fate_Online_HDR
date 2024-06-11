using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ContainerPresenter : MonoBehaviour
{
    [SerializeField] ContainerSlot _slot;
    public void BindToContainer(Container container)
    {
        _slot.Storage = container.Storage;
    }

    public ContainerSlot Slot => _slot;

    public void Close()
    {
        gameObject.SetActive(false);
    }
}

