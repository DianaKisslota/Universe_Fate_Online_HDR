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
    
    public ContainerObject ContainerObject { get; set; }
    public void BindToContainer(ContainerObject containerObject)
    {
        _containerSlot.gameObject.SetActive(false);
        _lootContainerSlot.gameObject.SetActive(false);
        ContainerObject = containerObject;
        CurrentContainer = containerObject.Container;
        if (CurrentContainer is LootContainer)
            _slot = _lootContainerSlot;
        else
            _slot = _containerSlot;

        _slot.gameObject.SetActive(true);
        _slot.Storage = containerObject.Container.Storage;
    }

    public Container CurrentContainer { get; set; }
    public ContainerSlot Slot => _slot;

    public void Close()
    {
        gameObject.SetActive(false);
        ContainerObject.CheckVisibility();
    }
}

