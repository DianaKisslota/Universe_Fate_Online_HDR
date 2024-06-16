using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : AvatarController
{
    [SerializeField] private Material AccessMoveMaterial;
    [SerializeField] private Material RestrictMoveMaterial;
    [SerializeField] private CharacterInventoryPresenter _inventoryPanel;
    [SerializeField] private ContainerPresenter _containerPresenter;
    [SerializeField] private Transform _originInventoryPlaceHolder;
    [SerializeField] private Transform _containerInventoryPlaceHolder;
    [SerializeField] private GameObject _FinishBattleButton;

    [SerializeField] private PointerController _pointer;
    //   [SerializeField] protected LineRenderer _pathDrawer;

    [SerializeField] private List<UIItem> _uiItems;

    private Vector3 _originPoint;
    private Vector3 _originAngle;

    private Vector3 _lastPoint;
    private Vector3 _lastAngle;

    private Item _itemDragging;
    private DropSlot _slotDraggingFrom;

    private bool _mouseOverUI;

    private CharacterAvatar _playerAvatar => _avatar as CharacterAvatar;

    private List<GameObject> _navPoints = new List<GameObject>();


    private bool _canMove;

    private bool _avatarMoving;
    private bool _avatarApplyingQants;
    private bool AvatarBusy => _avatarMoving || _avatarApplyingQants;

    private void Start()
    {
        _originInventoryPlaceHolder = _inventoryPanel.transform.parent;
        _containerPresenter.gameObject.SetActive(false);
        _inventoryPanel.gameObject.SetActive(false);
        _playerAvatar.StartMoving += () => _avatarMoving = true;
        _playerAvatar.EndMoving += () => _avatarMoving = false;
        _playerAvatar.StartApplainQuants += () => _avatarApplyingQants = true;
        _playerAvatar.EndApplainQuants += () =>
        {
            _originPoint = _playerAvatar.transform.position;
            _originAngle = _playerAvatar.transform.eulerAngles;
            _avatarApplyingQants = false;
        };

        _originPoint = _playerAvatar.transform.position;
        _originAngle = _playerAvatar.transform.eulerAngles;
        _lastPoint = _playerAvatar.transform.position;
        _lastAngle = _playerAvatar.transform.eulerAngles;

        foreach(var item in _uiItems)
        {
            item.MouseOver += UIMouseInteract;
        }

        _inventoryPanel.Inventory.ItemLeave += ItemLeave;
        _inventoryPanel.Inventory.ItemSet += ItemSet;
        foreach (var itemSlot in _inventoryPanel.ItemSlots)
        {
            itemSlot.ItemLeave += ItemLeave;
            itemSlot.ItemSet += ItemSet;
        }

        _inventoryPanel.Inventory.WeaponReloaded += OnWeaponReloaded;
    }

    private void OnDestroy()
    {
        foreach (var itemSlot in _inventoryPanel.ItemSlots)
        {
            itemSlot.ItemLeave -= ItemLeave;
            itemSlot.ItemSet -= ItemSet;
        }
        _inventoryPanel.Inventory.WeaponReloaded -= OnWeaponReloaded;
    }

    public override void BindAvatar(EntityAvatar avatar)
    {
        base.BindAvatar(avatar);
        _playerAvatar.InventoryPresenter = _inventoryPanel;
    }

    public void UIMouseInteract(bool mouseOverUI)
    {
        _mouseOverUI = mouseOverUI;
    }

    private void Update()
    {
        _FinishBattleButton.SetActive(!(_containerPresenter.gameObject.activeSelf ||
                                        (_inventoryPanel.gameObject.activeSelf && _inventoryPanel.transform.parent == _originInventoryPlaceHolder)));

        if (Input.GetMouseButtonDown(0))
        {
            var itemObject = GetItemUnderMousePoint();
            if (itemObject != null  && Vector3.Distance(_playerAvatar.transform.position, itemObject.transform.position) < 1.2f)                
            {
                _playerAvatar.AddPickObjectQuant(itemObject);
                _playerAvatar.TakeItem(itemObject);
                return;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            var containerObject = GetContainerUnderMousePoint();
            if (containerObject != null && Vector3.Distance(_playerAvatar.transform.position, containerObject.transform.position) < 1.5f)
            {
                _containerPresenter.BindToContainer(containerObject.Container);
                _inventoryPanel.transform.SetParent(_containerInventoryPlaceHolder);
                _inventoryPanel.transform.localPosition = Vector3.zero;
                var rt = _inventoryPanel.GetComponent<RectTransform>();
                rt.offsetMax = Vector2.zero;
                rt.offsetMin = Vector2.zero;
                _inventoryPanel.gameObject.SetActive(true);
                _containerPresenter.gameObject.SetActive(true);
                _containerPresenter.Slot.ItemLeave += ItemLeave;
                _containerPresenter.Slot.ItemSet += ItemSet;
                _containerPresenter.Slot.WeaponReloaded += OnWeaponReloaded;
                return;
            }
        }

        if (Input.GetMouseButtonDown(0) && !_mouseOverUI && _canMove && PlayerCanReach(AllignPoint.ToMid(GetPointerPositionOnMap())) 
                   && !AvatarBusy &&!_containerPresenter.gameObject.activeSelf)
        {
            var navPoint = Instantiate(Global.NavPointPrefab);
            navPoint.transform.position = _pointer.position;
            _navPoints.Add(navPoint);

            _lastPoint = _playerAvatar.transform.position;
            _lastAngle = _playerAvatar.transform.eulerAngles;

            var path = new NavMeshPath();

            if (_playerAvatar.CalculateCompletePath(_pointer.position, path))
            {
                //DrawPath(path);
                _playerAvatar.AddMoveQuant(_pointer.position);
                _playerAvatar.MoveTo(_pointer.position);
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            ApplyQuants();
        }

        if (Input.GetKey(KeyCode.Backspace)) 
        { 
            ClearLastQuant();
        }
    }

    private Vector3 GetPointerPositionOnMap() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        return hit.point;
    }

    private ItemObject GetItemUnderMousePoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (hit.rigidbody != null && hit.rigidbody.gameObject.TryGetComponent<ItemObject>(out var itemObject))
        {
            return itemObject;
        }
        return null;
    }

    private ContainerObject GetContainerUnderMousePoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (hit.rigidbody != null && hit.rigidbody.gameObject.TryGetComponent<ContainerObject>(out var containerObject))
        {
            return containerObject;
        }
        return null;
    }

    private void OnMouseOver()
    {
        if (_pointer != null)
        {
            var pointerPosition = GetPointerPositionOnMap();
            var movePosition = AllignPoint.ToMid(pointerPosition);

            _canMove = PlayerCanReach(movePosition) && !_mouseOverUI;
            _pointer.SetActive(_canMove && !AvatarBusy);
            if (_pointer.activeSelf && _pointer.position != movePosition)
            {
                _pointer.position = movePosition;

                //if (playerController.PlayerCanReach(_pointer.transform.position))
                _pointer.SetPointerMaterial(AccessMoveMaterial);
                //else
                //    _pointer.SetPointerMaterial(RestrictMoveMaterial);
            }
        }
    }

    void OnMouseExit()
    {
        _pointer.SetActive(false);
    }

    //private void DrawPath(NavMeshPath path)
    //{
    //    var startPosition = _pathDrawer.positionCount;
    //    _pathDrawer.positionCount += path.corners.Length;
    //    for (var i = startPosition; i < _pathDrawer.positionCount; i++)
    //    {
    //        _pathDrawer.SetPosition(i, path.corners[i - startPosition]);
    //    }
    //}

    private bool PlayerCanReach(Vector3 point)
    {
        return _playerAvatar.CalculateCompletePath(point, new NavMeshPath());
    }

    private void ApplyQuants()
    {
        RevertAllQuants();
        _playerAvatar.ApplyQuants();        
    }

    private void RevertQuant(Quant quant)
    {
        switch (quant.Action)
        {
            case EntityAction.Move:
                {
                    if (_navPoints.Count > 0)
                    {
                        Destroy(_navPoints[_navPoints.Count - 1]);
                        _navPoints.RemoveAt(_navPoints.Count - 1);
                    }
                    if (quant.LastPosition != null)
                    {
                        _playerAvatar.SetToPosition(quant.LastPosition.Value);
                        _playerAvatar.transform.rotation = quant.LastRotation;
                    }
                    break;
                }
            case EntityAction.PickObject:
                {
                    var itemObject = quant.Object as ItemObject;                    
                    itemObject.transform.SetParent(null);
                    itemObject.transform.position = quant.LastPosition.Value;
                    itemObject.transform.rotation = quant.LastRotation;
                    itemObject.Drop();
                    _playerAvatar.Character.UnEquip(itemObject.Item);
                    itemObject.gameObject.SetActive(true);
                    break;
                }
            case EntityAction.TransferItem:
                {
                    var transferItemInfo = quant.Object as TransferItemInfo;
                    var sourceSlot = transferItemInfo.Source;
                    var destinationSlot = transferItemInfo.Destination;
                    var item = transferItemInfo.Item;

                    _playerAvatar.TransferItem(destinationSlot, sourceSlot, item);

                    break;
                }
                case EntityAction.ReloadWeapon:
                {
                    var reloadWeaponInfo = quant.Object as ReloadWeaponInfo;
                    var weapon = reloadWeaponInfo.WeaponPresenter.Item as RangeWeapon;
                    var loadedAmmo = reloadWeaponInfo.AmmoUsed;
                    var sourceSlot = reloadWeaponInfo.SourceSlot;
                    var ammoPresenter = reloadWeaponInfo.AmmoPresenter;
                    if (ammoPresenter == null)
                    {
                        ammoPresenter = ItemFactory.CreateItemPresenter(reloadWeaponInfo.AmmoType);
                        ammoPresenter.Count = loadedAmmo;
                        sourceSlot.InsertItem(ammoPresenter);
                    }
                    else
                    {
                        ammoPresenter.Count += loadedAmmo;
                        sourceSlot.Storage.AddItem(ammoPresenter.Item, loadedAmmo);
                    }
                    weapon.UnLoad(loadedAmmo);
                    sourceSlot.FillSlots();

                    break;
                }
        }
    }

    private void RevertLastQuant()
    {
        if (_playerAvatar.Quants.Count > 0)
            RevertQuant(_playerAvatar.Quants.Last());
    }

    private void RevertAllQuants()
    {
        if (AvatarBusy)
            return;
        _playerAvatar.Quants.Reverse();
        foreach (var quant in _playerAvatar.Quants) 
        {
            RevertQuant(quant);
        }
        _playerAvatar.Quants.Reverse();
    }

    private void ClearLastQuant()
    {
        if (AvatarBusy)
            return;
        RevertLastQuant();
        _playerAvatar.RemoveLastQuant();
    }

    private void ClearAllQuants()
    {
        if (AvatarBusy)
            return;
        do
        {
            ClearLastQuant();
        }
        while (_playerAvatar.Quants.Any());
    }

    public void ButtonApplyQuantsClick()
    {
        if (AvatarBusy)
            return;
        ApplyQuants();
    }

    public void ButtonClearLastClick()
    {
        if (AvatarBusy)
            return;
        ClearLastQuant();
    }

    public void ButtonClearAll()
    {
        ClearAllQuants();
    }

    public void InventoryPanelSwitch()
    {
        if (_containerPresenter.gameObject.activeSelf)
            return;
        

        if (_inventoryPanel.transform.parent != _originInventoryPlaceHolder)
        {
            _inventoryPanel.transform.SetParent(_originInventoryPlaceHolder, false);
            _inventoryPanel.transform.localPosition = Vector3.zero;
            var rt = _inventoryPanel.GetComponent<RectTransform>();
            rt.offsetMax = Vector2.zero;
            rt.offsetMin = Vector2.zero;
            _inventoryPanel.gameObject.SetActive(true);
        }
        else
            _inventoryPanel.gameObject.SetActive(!_inventoryPanel.gameObject.activeSelf);
    }
    private void ItemLeave(Item item, DropSlot slot)
    {
        _itemDragging = item;
        _slotDraggingFrom = slot;
    }

    private void ItemSet(Item item, DropSlot slot)
    {
        var transferItemInfo = new TransferItemInfo(_slotDraggingFrom, slot, item);
        _playerAvatar.AddItemtransferQuant(transferItemInfo);
    }

    public void ContainerCloseClick()
    {
        _containerPresenter.Slot.ItemLeave -= ItemLeave;
        _containerPresenter.Slot.ItemSet -= ItemSet;
        _containerPresenter.Slot.WeaponReloaded -= OnWeaponReloaded;
    }

    public void OnWeaponReloaded(ItemPresenter weaponPresenter, ItemPresenter ammoPresenter, int num, StorageSlot slot)
    {
        var quantInfo = new ReloadWeaponInfo(weaponPresenter, ammoPresenter, num, slot);
        _playerAvatar.AddReloadWeaponQuant(quantInfo);
    }
}
