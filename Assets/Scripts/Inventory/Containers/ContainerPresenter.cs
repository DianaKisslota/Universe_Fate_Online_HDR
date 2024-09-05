using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ContainerPresenter : MonoBehaviour
{
    private ContainerSlot _slot;
    [SerializeField] ContainerSlot _containerSlot;
    [SerializeField] LootContainerSlot _lootContainerSlot;
    public void BindToContainer(Container container)
    {
        _containerSlot.gameObject.SetActive(false);
        _lootContainerSlot.gameObject.SetActive(false);
        CurrentContainer = container;
        if (CurrentContainer is LootContainer)
            _slot = _lootContainerSlot;
        else
            _slot = _containerSlot;

        _slot.gameObject.SetActive(true);
        _slot.Storage = container.Storage;
    }

    public Container CurrentContainer { get; set; }
    public ContainerSlot Slot => _slot;

    public void Close()
    {
        gameObject.SetActive(false);
    }
}

