using UnityEngine;

public enum EntityAction
{
    Move,
    DistantAttack,
    PickObject,
    GetObjectFromContainer
}

public class TransferItemInfo
{
    public DropSlot Source {  get; private set; }
    public DropSlot Destination { get; private set; }
    public int SourceItemIndex {  get; private set; } 
    public int DestinationItemIndex { get; private set; }

    public Item Item { get; private set; }

    public TransferItemInfo(DropSlot source, DropSlot destination, Item item, int sourceItemIndex, int destinationItemIndex)
    {
        Source = source;
        Destination = destination;
        Item = item;
        SourceItemIndex = sourceItemIndex;
        DestinationItemIndex = destinationItemIndex;
    }
}
public class Quant
{
    public EntityAction Action { get; private set; }
    public object Object {  get; private set; }

    public Vector3? LastPosition {  get; private set; }
    public Quaternion LastRotation { get; private set; }

    public Quant(EntityAction _action, object _object, Vector3? lastPosition, Quaternion lastRotation)
    {
        Action = _action;
        Object = _object;
        LastPosition = lastPosition;
        LastRotation = lastRotation;
    }

    public Vector3? GetPosition()
    {
        switch (Action) 
        { 
            case EntityAction.Move:
                {
                    return Object as Vector3?;
                }
            default: return null;
        }
    }
}

